﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MIL.Html;
//using System.Windows.Forms;
using OMSZ.App.Model;
using System.Drawing;
using OMSZ.Model;

namespace OMSZ.App
{
    public class AppMain
    {
        private static string url = "http://www.met.hu/idojaras/aktualis_idojaras/mert_adatok/main.php?vn=0&v=Budapest&c=tablazat&ful=hom";
        private string email;
        private bool useProxy;
        private string proxy;
        private string userId, password, Domain;

        private IRepository _repository;

        public AppMain() 
            : this( new Repository(url))
        { }

        public AppMain(IRepository repository)
        {
            _repository = repository;
            Init();            
        }
        
        private void Init()
        {
            email = ConfigurationManager.AppSettings["Email"];
            useProxy = Convert.ToBoolean(ConfigurationManager.AppSettings["UseProxy"]);
            proxy = ConfigurationManager.AppSettings["Proxy"];
            userId = ConfigurationManager.AppSettings["UserId"];
            password = ConfigurationManager.AppSettings["Password"];
            Domain = ConfigurationManager.AppSettings["Domain"];
        }

        //private string OpenFile(string fileName)
        //{
        //    string html = string.Empty;
        //    using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8))
        //    {
        //        html = sr.ReadToEnd();
        //        sr.Close();
        //    }
        //    if (html == string.Empty)
        //    {
        //        Console.WriteLine("Nothing in the file");
        //    }
        //    return html;
        //}

        //public string GetWebContent(string p_url)
        //{            
        //    StringBuilder sb = new StringBuilder();
        //    byte[] buf = new byte[8192];
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(p_url);

        //    if (useProxy)
        //    {
        //        request.PreAuthenticate = true;
        //        WebProxy Proxy = new WebProxy(proxy, true);
        //        Proxy.Credentials = new NetworkCredential(userId, password, Domain);
        //        request.Proxy = Proxy;
        //    }

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream responseStream = response.GetResponseStream();

        //    string tempString = null;
        //    int count = 0;
        //    do
        //    {
        //        count = responseStream.Read(buf, 0, buf.Length);
        //        if (count != 0)
        //        {
        //            tempString = Encoding.UTF8.GetString(buf, 0, count);
        //            sb.Append(tempString);
        //        }
        //    }
        //    while (count > 0);
        //    return sb.ToString();
        //}

        private HtmlDocument PreProcessHtml(string html)
        {
            if (html.Equals(string.Empty))
                throw new InvalidDataException("Raw html response is empty");

            html = html.Replace("rbg1", "rbg0");
            html = html.Replace("T rbg0", "rbg0");
            html = html.Replace("Wikon rbg0", "rbg0");
            html = html.Replace("Wd rbg0", "rbg0");
            html = html.Replace("Wf rbg0", "rbg0");
            html = html.Replace("P rbg0", "rbg0");
            html = html.Replace("H rbg0", "rbg0");
            html = html.Replace("R rbg0", "rbg0");

            return HtmlDocument.Create(html, false);
        }

        private List<RawMeres> ParseHtmlData(string html)
        {
            List<RawMeres> MeresList = new List<RawMeres>();

            HtmlDocument mDocument = PreProcessHtml(html);
            HtmlNodeCollection tdcoll = mDocument.Nodes.FindByAttributeNameValue("class", "rbg0", true);

            List<DateTime> dateList = GetDateTimeList(mDocument);

            const int ROW_DATA_LENGTH = 9;

            int index = 0;
            int rowIndex = 0;

            string homerseklet = String.Empty;
            string legnyomas = String.Empty;
            string szelirany = String.Empty;
            string szelsebesseg = String.Empty;
            string csapadek = String.Empty;
            DateTime datum = DateTime.Now;            

            foreach (MIL.Html.HtmlElement td in tdcoll)    //td értékek
            {
                if (index % ROW_DATA_LENGTH == 0)
                {
                    // in UTC
                    datum = dateList[rowIndex];
                    rowIndex++;
                }
                if (index % ROW_DATA_LENGTH == 1)
                {
                    homerseklet = ((MIL.Html.HtmlElement)td.FirstChild).Text;
                }
                if (index % ROW_DATA_LENGTH == 3)
                {
                    string htmlText = td.Attributes.FindByName("onmouseover").Value;
                    string[] splitchars = { "<br>" };
                    string[] tmp = htmlText.Split(splitchars, StringSplitOptions.None);
                    szelirany = tmp[1];
                }

                if (index % ROW_DATA_LENGTH == 4)
                {
                    szelsebesseg = ((MIL.Html.HtmlElement)td.FirstChild).Text;
                }

                if (index % ROW_DATA_LENGTH == 6)
                {
                    legnyomas = ((MIL.Html.HtmlElement)td.FirstChild).Text;
                }

                if (index % ROW_DATA_LENGTH == 8)
                {
                    csapadek = ((MIL.Html.HtmlElement)td.FirstChild).Text;
                    csapadek = csapadek.Replace('.', ',');
                    csapadek = csapadek.Replace("-", "0,0");
                }

                if (index % ROW_DATA_LENGTH == 8)
                {
                    var rawMeres = new RawMeres();
                    rawMeres.Datum = datum;
                    try
                    {
                        rawMeres.Homerseklet = homerseklet;
                        rawMeres.Legnyomas = legnyomas;
                        rawMeres.Szelirany = szelirany;
                        rawMeres.Szelsebesseg = szelsebesseg;
                        rawMeres.Csapadek = csapadek;
                        MeresList.Add(rawMeres);
                    }
                    catch
                    {
                        continue;
                    }
                }
                index++;
            }
            return MeresList;
        }

        private List<RawMeres> GetData(string html)
        {
            List<RawMeres> MeresList = ParseHtmlData(html);

            return MeresList;
        }

        #region Getting DateTime

        private static List<DateTime> GetDateTimeList(HtmlDocument mDocument)
        {
            List<DateTime> dateTimeList = new List<DateTime>();

            HtmlNodeCollection optionColl = mDocument.Nodes.FindByName("option");

            DateTime convertedDateTime;

            foreach (var option in optionColl)
            {
                if (TryParseDateTime((option as HtmlElement).Text, out convertedDateTime))
                {
                    dateTimeList.Add(convertedDateTime);
                }
            }

            return dateTimeList;
        }

        private static bool TryParseDateTime(string p_idopont, out DateTime parsedDateTime)
        {
            bool isSuccess = true;
            parsedDateTime = DateTime.MinValue;

            if (p_idopont.Length < 30)
            {
                isSuccess = false;
                return isSuccess;
            }

            string[] tmp = p_idopont.Split(" ".ToCharArray());
            tmp[0] = tmp[0].Substring(0, 4);                         //year
            tmp[1] = tmp[1];                                        //month
            tmp[2] = tmp[2].Substring(0, tmp[2].Length - 1);        //day
            tmp[5] = tmp[5].Substring(1, 2);                         //hour

            int year = 0;
            int month = 0;
            int day = 0;
            int hour = 0;

            try
            {
                year = Int32.Parse(tmp[0]);
                month = tmp[1].ToInt();
                day = Int32.Parse(tmp[2]);
                hour = Int32.Parse(tmp[5]);
                parsedDateTime = new DateTime(year, month, day);
                parsedDateTime = parsedDateTime.AddHours(hour);
            }
            catch (Exception)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        #endregion

        public ViewModel GetViewModel()
        {
            ViewModel viewModel = new ViewModel();
            
            string html = _repository.GetWebContent();

            if (!html.Equals(String.Empty))
            {
                List<RawMeres> RawMeresList = GetData(html);
                List<Meres> MeresList = ProduceMeresList(RawMeresList);
                DateTime Now = MeresList[0].Datum;
                if (DateTime.Today.IsDaylightSavingTime())
                {
                    Now = Now.AddHours(2);
                }
                else
                    Now = Now.AddHours(1);

                string ido0 = String.Empty;
                if (Now.Hour < 10)
                    ido0 = "0" + Now.Hour.ToString();
                else
                    ido0 = Now.Hour.ToString();

                string ido = ido0 + ":00";


                viewModel.Pressure = MeresList[0].Legnyomas;
                viewModel.Temperature = MeresList[0].Homerseklet;
                viewModel.Time = ido;

                viewModel.DeltaPressure = MeresList[0].Legnyomas - MeresList[1].Legnyomas;
                viewModel.DeltaTemperature = MeresList[0].Homerseklet - MeresList[1].Homerseklet;

                if (viewModel.DeltaPressure > 0)
                    viewModel.DeltaPressureColor = Color.Blue;

                if (viewModel.DeltaPressure == 0)
                    viewModel.DeltaPressureColor = Color.Black;

                if (viewModel.DeltaPressure < 0)
                    viewModel.DeltaPressureColor = Color.Red;

                if (viewModel.DeltaTemperature > 0)
                    viewModel.DeltaTemperatureColor = Color.Red;

                if (viewModel.DeltaTemperature == 0)
                    viewModel.DeltaTemperatureColor = Color.Black;

                if (viewModel.DeltaTemperature < 0)
                    viewModel.DeltaTemperatureColor = Color.Blue;

                viewModel.WindDirection = MeresList[0].Szelirany;
                viewModel.WindSpeed = MeresList[0].Szelsebesseg;

                viewModel.FormTitle = String.Format("{0} {1} {2}", viewModel.Pressure.ToString(), viewModel.Temperature.ToString(), ido);
            }
            return viewModel;
        }

        private List<Meres> ProduceMeresList(List<RawMeres> rawMeresList)
        {
            List<Meres> meresList = new List<Meres>();

            foreach (var rawMeres in rawMeresList)
            {
                var meres = ParseRawData(rawMeres);
                meresList.Add(meres);
            }
            return meresList;
        }

        private Meres ParseRawData(RawMeres rawMeres)
        {
            var szeliranyok = new List<string>
            {
                "északi",
                "északkeleti",
                "keleti",
                "délkeleti",
                "déli",
                "délnyugati",
                "nyugati",
                "északnyugati",
                "szélcsend"
            };

            var szeliranyok2 = new List<string>
            {
                "É",
                "ÉK",
                "K",
                "DK",
                "D",
                "DNY",
                "NY",
                "ÉNY",
                "-"
            };

            var meres = new Meres();

            meres.Datum = rawMeres.Datum;
            try
            {
                meres.Homerseklet = Convert.ToInt32(rawMeres.Homerseklet);
                meres.Legnyomas = Convert.ToInt32(rawMeres.Legnyomas);
                int szelindex = szeliranyok.IndexOf(rawMeres.Szelirany.Trim());
                meres.Szelirany = szelindex > -1 ? szeliranyok2[szelindex] : " - ";
                meres.Szelsebesseg = Convert.ToInt32(rawMeres.Szelsebesseg);
                meres.Csapadek = Convert.ToDouble(rawMeres.Csapadek);
            }
            catch
            {

            }

            return meres;
        }
    }
}
