using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OMSZ.App
{
    public class AppMain
    {
        private string url;
        private string email;
        private string proxy;
        private string userId, password, Domain;

        private void Init()
        {
            url = "http://www.met.hu/idojaras/aktualis_idojaras/mert_adatok/main.php?vn=0&v=Budapest&c=tablazat&ful=hom";
            email = ConfigurationManager.AppSettings["Email"];
            proxy = ConfigurationManager.AppSettings["Proxy"];
            userId = ConfigurationManager.AppSettings["UserId"];
            password = ConfigurationManager.AppSettings["Password"];
            Domain = ConfigurationManager.AppSettings["Domain"];
        }
    }
}
