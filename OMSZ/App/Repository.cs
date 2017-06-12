namespace OMSZ.App
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    public class Repository : IRepository
    {
        private string _url;

        public Repository(string url)
        {
            _url = url;
        }

        public string GetWebContent()
        {
            if (string.IsNullOrEmpty(_url))
            {
                throw new ArgumentException("Url should be set up");
            }

            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);

            //if (useProxy)
            //{
            //    request.PreAuthenticate = true;
            //    WebProxy Proxy = new WebProxy(proxy, true);
            //    Proxy.Credentials = new NetworkCredential(userId, password, Domain);
            //    request.Proxy = Proxy;
            //}

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            string tempString = null;
            int count = 0;
            do
            {
                count = responseStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    tempString = Encoding.UTF8.GetString(buf, 0, count);
                    sb.Append(tempString);
                }
            }
            while (count > 0);
            return sb.ToString();
        }
    }
}
