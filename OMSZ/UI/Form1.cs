using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;
using MIL.Html;
using OMSZ.App;
using System.Globalization;
using OMSZ.App.Model;

namespace OMSZ
{
    public partial class Form1 : Form
    {
        private string url;
        private string email;
        private string proxy;
        private string userId, password, Domain;       

        public Form1()
        {
            InitializeComponent();
            int interval = Convert.ToInt32(ConfigurationManager.AppSettings["TimerInterval"]);
            this.timer1.Interval = interval;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lblPressure.Text = "1024";
            //url = "http://www.met.hu/idojaras/aktualis_idojaras/mert_adatok/main.php?vn=0&v=Budapest&c=tablazat&ful=hom";
            //email = ConfigurationManager.AppSettings["Email"];
            //proxy = ConfigurationManager.AppSettings["Proxy"];
            //userId = ConfigurationManager.AppSettings["UserId"];
            //password = ConfigurationManager.AppSettings["Password"];
            //Domain = ConfigurationManager.AppSettings["Domain"];

            Display();

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

        //private string FetchWebPage()
        //{
        //    HttpWebResponse response = null;
        //    // used to build entire input
        //    StringBuilder sb = new StringBuilder();

        //    // used on each read operation
        //    byte[] buf = new byte[8192];

           
        //    // prepare the web page we will be asking for            
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

        //    if (CheckIpAddress())
        //    {
        //        request.PreAuthenticate = true;
        //        WebProxy Proxy = new WebProxy(proxy, true);
        //        Proxy.Credentials = new NetworkCredential(userId, password, Domain);

        //        request.Proxy = Proxy;
        //        //request.ProtocolVersion. = 1;
        //        //request.ProtocolVersion.Minor = 0;
        //    }

        //    try
        //    {
        //        // execute the request
        //        response = (HttpWebResponse)request.GetResponse();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Hiba! " + e.Message);
        //    }

        //    // we will read data via the response stream
        //    Stream resStream = response.GetResponseStream();


        //    string tempString = null;
        //    int count = 0;

        //    do
        //    {
        //        // fill the buffer with data
        //        count = resStream.Read(buf, 0, buf.Length);

        //        // make sure we read some data
        //        if (count != 0)
        //        {
        //            // translate from bytes to ASCII text
        //            tempString = Encoding.UTF8.GetString(buf, 0, count);

        //            // continue building the string
        //            sb.Append(tempString);
        //        }
        //    }
        //    while (count > 0); // any more data to read?

        //    // print out page source
        //    //Console.WriteLine(sb.ToString());
        //    return sb.ToString();
        //}

        //private List<Meres> GetData(string html)
        //{
        //    List<Meres> MeresList = new List<Meres>();

        //    if (html.Equals(string.Empty))
        //        return MeresList;

        //    html = html.Replace("rbg1", "rbg0");
        //    html = html.Replace("T rbg0", "rbg0");
        //    html = html.Replace("Wikon rbg0", "rbg0");
        //    html = html.Replace("Wd rbg0", "rbg0");
        //    html = html.Replace("Wf rbg0", "rbg0");
        //    html = html.Replace("P rbg0", "rbg0");
        //    html = html.Replace("H rbg0", "rbg0");
        //    html = html.Replace("R rbg0", "rbg0");

        //    MIL.Html.HtmlDocument mDocument = MIL.Html.HtmlDocument.Create(html, false);
        //    HtmlNodeCollection tdcoll = mDocument.Nodes.FindByAttributeNameValue("class", "rbg0", true);

        //    List<DateTime> dateList = GetDateTimeList(mDocument);

        //    int index = 0;
        //    int rowIndex = 0;
        //    string idopont = String.Empty;
        //    string homerseklet = String.Empty;
        //    string legnyomas = String.Empty;
        //    string szelirany = String.Empty;
        //    string szelsebesseg = String.Empty;
        //    string csapadek = String.Empty;
        //    DateTime dte = DateTime.Now;
        //    var szeliranyok = new List<string>
        //    {
        //        "északi",
        //        "északkeleti",
        //        "keleti",
        //        "délkeleti",
        //        "déli",
        //        "délnyugati",
        //        "nyugati",
        //        "északnyugati",
        //        "szélcsend"
        //    };

        //    var szeliranyok2 = new List<string>
        //    {
        //        "É",
        //        "ÉK",
        //        "K",
        //        "DK",
        //        "D",
        //        "DNY",
        //        "NY",
        //        "ÉNY",
        //        "-"
        //    };

        //    foreach (MIL.Html.HtmlElement td in tdcoll)    //td értékek
        //    {
        //        if (index % 9 == 0)
        //        {
        //            // in UTC
        //            dte = dateList[rowIndex];
        //            rowIndex++;
        //        }
        //        if (index % 9 == 1)
        //        {
        //            homerseklet = ((MIL.Html.HtmlElement)td.FirstChild).Text;
        //        }
        //        if ( index % 9 == 3 )
        //        {
        //            string htmlText = td.Attributes.FindByName("onmouseover").Value;
        //            string[] splitchars = { "<br>" };
        //            string[] tmp = htmlText.Split(splitchars, StringSplitOptions.None);
        //            szelirany = tmp[1];
        //        }

        //        if ( index % 9 == 4 )
        //        {
        //            szelsebesseg = ((MIL.Html.HtmlElement)td.FirstChild).Text;
        //        }

        //        if (index % 9 == 6)
        //        {
        //            legnyomas = ((MIL.Html.HtmlElement)td.FirstChild).Text;
        //        }

        //        if (index % 9 == 8)
        //        {
        //            csapadek = ((MIL.Html.HtmlElement)td.FirstChild).Text;
        //            csapadek = csapadek.Replace('.', ',');
        //            csapadek = csapadek.Replace("-", "0,0");
        //        }

        //        if (index % 9 == 8)
        //        {
        //            Meres meres = new Meres();
        //            meres.Datum = dte;
        //            try
        //            {
        //                meres.Homerseklet = Convert.ToInt32(homerseklet);
        //                meres.Legnyomas = Convert.ToInt32(legnyomas);
        //                int szelindex = szeliranyok.IndexOf(szelirany.Trim());
        //                meres.Szelirany = szelindex > -1 ? szeliranyok2[szelindex] : " - ";
        //                meres.Szelsebesseg = Convert.ToInt32( szelsebesseg );
        //                meres.Csapadek = Convert.ToDouble(csapadek);
        //                MeresList.Add(meres);
        //            }
        //            catch
        //            {
        //                continue;
        //            }
        //        }
        //        index++;
        //    }
        //    return MeresList;
        //}

        #region Getting DateTime

        //private static List<DateTime> GetDateTimeList(MIL.Html.HtmlDocument mDocument)
        //{
        //    List<DateTime> dateTimeList = new List<DateTime>();

        //    HtmlNodeCollection optionColl = mDocument.Nodes.FindByName("option");

        //    DateTime convertedDateTime;

        //    foreach (var option in optionColl)
        //    {
        //        if (TryParseDateTime((option as MIL.Html.HtmlElement).Text, out convertedDateTime))
        //        {
        //            dateTimeList.Add(convertedDateTime);
        //        }
        //    }

        //    return dateTimeList;
        //}

        //private static bool TryParseDateTime(string p_idopont, out DateTime parsedDateTime)
        //{
        //    bool isSuccess = true;
        //    parsedDateTime = DateTime.MinValue;

        //    if (p_idopont.Length < 30)
        //    {
        //        isSuccess = false;
        //        return isSuccess;
        //    }

        //    string[] tmp = p_idopont.Split(" ".ToCharArray());
        //    tmp[0] = tmp[0].Substring(0, 4);                         //year
        //    tmp[1] = tmp[1];                                        //month
        //    tmp[2] = tmp[2].Substring(0, tmp[2].Length - 1);        //day
        //    tmp[5] = tmp[5].Substring(1, 2);                         //hour

        //    int year = 0;
        //    int month = 0;
        //    int day = 0;
        //    int hour = 0;

        //    try
        //    {
        //        year = Int32.Parse(tmp[0]);
        //        month = tmp[1].ToInt();
        //        day = Int32.Parse(tmp[2]);
        //        hour = Int32.Parse(tmp[5]);
        //        parsedDateTime = new DateTime(year, month, day);
        //        parsedDateTime = parsedDateTime.AddHours(hour);
        //    }
        //    catch (Exception)
        //    {
        //        isSuccess = false;
        //    }
        //    return isSuccess;
        //}

        #endregion

        private void Display()
        {
            var app = new App.AppMain();
            ViewModel viewModel = app.GetViewModel();

            this.Text = viewModel.FormTitle;
            lblPressure.Text = viewModel.Pressure.ToString();
            lblTemp.Text = viewModel.Temperature.ToString();
            lblSzelirany.Text = viewModel.WindDirection;
            lblSzelsebesseg.Text = viewModel.WindSpeed.ToString();
            lblDP.Text = viewModel.DeltaPressure.ToString();
            lblDT.Text = viewModel.DeltaTemperature.ToString();
            lblDP.ForeColor = viewModel.DeltaPressureColor;
            lblDT.ForeColor = viewModel.DeltaTemperatureColor;

            ////string html = OpenFile(@"D:\Kuka\idojaras3.htm");
            //string html = FetchWebPage();
            //if (!html.Equals(String.Empty))
            //{
            //    List<Meres> MeresList = GetData(html);
            //    DateTime Now = MeresList[0].Datum;
            //    if (DateTime.Today.IsDaylightSavingTime())
            //    {
            //        Now = Now.AddHours(2);
            //    }
            //    else
            //        Now = Now.AddHours(1);

            //    string ido0 = String.Empty;
            //    if (Now.Hour < 10)
            //        ido0 = "0" + Now.Hour.ToString();
            //    else
            //        ido0 = Now.Hour.ToString();

            //    string ido = ido0 + ":00";
            //    lblPressure.Text = MeresList[0].Legnyomas.ToString();
            //    lblTemp.Text = MeresList[0].Homerseklet.ToString();
            //    lblTime.Text = ido;

            //    int dp = MeresList[0].Legnyomas - MeresList[1].Legnyomas;
            //    int dt =  MeresList[0].Homerseklet - MeresList[1].Homerseklet;
            //    lblDP.Text = dp.ToString();
            //    lblDT.Text = dt.ToString();

            //    if ( dp > 0 )
            //        lblDP.ForeColor = Color.Blue;

            //    if ( dp == 0 )                
            //        lblDP.ForeColor = Color.Black;

            //    if ( dp < 0 )
            //        lblDP.ForeColor = Color.Red;

            //    if ( dt > 0 )
            //        lblDT.ForeColor = Color.Red;

            //    if ( dt == 0 )
            //        lblDT.ForeColor = Color.Black;

            //    if ( dt < 0 )
            //        lblDT.ForeColor = Color.Blue;

            //    lblSzelirany.Text = MeresList[0].Szelirany;
            //    lblSzelsebesseg.Text = MeresList[0].Szelsebesseg.ToString();

            //    this.Text = String.Format("{0} {1} {2}", lblPressure.Text, lblTemp.Text, ido);
            //    //this.Text = String.Format( "{0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute );
           // }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int minute = DateTime.Now.Minute;

            if ( minute >= 15 && minute < 23 )
            {
                Display();
            }
            
        }

        //private bool CheckIpAddress()
        //{
        //    bool proxy = true;
        //    string strHostName = Dns.GetHostName();

        //    IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
        //    IPAddress[] addr = ipEntry.AddressList;

        //    if (addr[0].ToString().StartsWith("192"))   //Home use
        //        proxy = false;

        //    //return proxy;
        //    return false;
        //}
    }

    #region Extension methods

    //public static class Month
    //{
    //    public static int ToInt(this string month)
    //    {
    //        return Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, month.ToLower(CultureInfo.CurrentCulture)) + 1;
    //    }
    //}

    #endregion

}