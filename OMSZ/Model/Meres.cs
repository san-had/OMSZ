using System;
using System.Collections.Generic;
using System.Text;

namespace OMSZ.App.Model
{
    public class Meres
    {
        /*** PROPERTIES ***/
        public DateTime Datum { get; set; }
        public int Homerseklet { get; set; }
        public int Legnyomas { get; set; }
        public string Szelirany { get; set; }
        public int Szelsebesseg { get; set; }
        public double Csapadek { get; set; }
    }
}
