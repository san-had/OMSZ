using System;
using System.Windows.Forms;
using System.Configuration;
using OMSZ.App.Model;

namespace OMSZ
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
            int interval = Convert.ToInt32(ConfigurationManager.AppSettings["TimerInterval"]);
            this.timer1.Interval = interval;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void Display()
        {
            var app = new App.AppMain();
            ViewModel viewModel = app.GetViewModel();

            this.Text = viewModel.FormTitle;
            lblPressure.Text = viewModel.Pressure.ToString();
            lblTemp.Text = viewModel.Temperature.ToString();
            lblSzelirany.Text = viewModel.WindDirection;
            lblSzelsebesseg.Text = viewModel.WindSpeed.ToString();
            lblTime.Text = viewModel.Time;
            lblDP.Text = viewModel.DeltaPressure.ToString();
            lblDT.Text = viewModel.DeltaTemperature.ToString();
            lblDP.ForeColor = viewModel.DeltaPressureColor;
            lblDT.ForeColor = viewModel.DeltaTemperatureColor;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int minute = DateTime.Now.Minute;

            if ( minute >= 15 && minute < 23 )
            {
                Display();
            }            
        }
    }
}