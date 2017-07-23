using DailyFeed.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyFeed.Model
{
    class Weather : INotifyPropertyChanged
    {
        private const string API_KEY = "2db5a5da5c3a27d247f2423a226fd5bf";
        private const string CurrentUrl = "http://api.openweathermap.org/data/2.5/weather?" + "q=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;
        private const string ForecastUrl = "http://api.openweathermap.org/data/2.5/forecast?" + "q=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;
        private string CurrentDegrees { get; set; }
        private string CurrentDesc { get; set; }
        private string CurrentLocation { get; set; }
        private string ForecastTime { get; set; }
        // publicly currDegrees, privately CurrentDegrees
        public string currDegrees
        {
            get
            {
                return CurrentDegrees;
            }
            set
            {
                CurrentDegrees = value;
                OnPropertyChanged("currDegrees");
            }
        }

        // publicly currDesc, privately CurrentDesc
        public string currDesc
        {
            get
            {
                return CurrentDesc;
            }
            set
            {
                CurrentDesc = value;
                OnPropertyChanged("currDesc");
            }
        }

        // publicly currLocation, privately CurrentLocation
        public string currLocation
        {
            get
            {
                return CurrentLocation;
            }
            set
            {
                CurrentLocation = value;
                OnPropertyChanged("currLocation");
            }
        }

        public string forecastTime
        {
            get
            {
                return ForecastTime;
            }
            set
            {
                ForecastTime = value;
                OnPropertyChanged("forecastTime");
            }
        }



        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public void fetchCurrentWeather()
        {
            // Compose the query URL.
            string url = CurrentUrl.Replace("@LOC@", this.currLocation);
            Console.WriteLine("url is :" + url);

            WeatherParseXML parser = new WeatherParseXML();
            try
            {
                parser.GetFormattedXml(url);
            }
            catch (Exception e)
            {
                return;
            }
            Weather temp_weather = parser.parseXMLDoc();
            this.currDesc = temp_weather.currDesc;
            this.currDegrees = temp_weather.currDegrees + " °F";
            Console.WriteLine("nowweather curr_desc : " + this.currDesc);
        }


        //Update stuff
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater : ICommand
        {
            #region ICommand Members
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
            }
            #endregion
        }

            public static ObservableCollection<Weather> fetchWeatherForecast(string currLocation)
        {
            string url = ForecastUrl.Replace("@LOC@", currLocation);
            Console.WriteLine("forecast url is :" + url);

            WeatherParseXML parser = new WeatherParseXML();
            try
            {
                parser.GetFormattedXml(url);
            }
            catch (Exception e)
            {
                return null;
            }
            ObservableCollection<Weather> test = new ObservableCollection<Weather>();
            test = parser.parseForecastXMLDoc();
            return test;
        }

    
    }
}
