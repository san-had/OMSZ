using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OMSZ.App.Model
{
    public class ViewModel
    {
        public string FormTitle { get; set; }
        public string Time { get; set; }

        public int Temperature { get; set; }

        public int Pressure { get; set; }

        public string WindDirection { get; set; }

        public int WindSpeed { get; set; }

        public int DeltaTemperature { get; set; }

        public int DeltaPressure { get; set; }

        public Color DeltaTemperatureColor { get; set; }

        public Color DeltaPressureColor { get; set; }

    }
}
