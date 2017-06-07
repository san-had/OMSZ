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
 
    }
}
