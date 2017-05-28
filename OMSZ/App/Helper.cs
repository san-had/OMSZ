using System;
using System.Globalization;
using System.Net;

namespace OMSZ.App
{
    #region Extension methods

    public static class Month
    {
        public static int ToInt(this string month)
        {
            return Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, month.ToLower(CultureInfo.CurrentCulture)) + 1;
        }
    }

    #endregion

    public static class Helper
    {
        public static bool CheckIpAddress()
        {
            bool proxy = true;
            string strHostName = Dns.GetHostName();

            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            if (addr[0].ToString().StartsWith("192"))   //Home use
                proxy = false;

            return proxy;
        }
    }
}
