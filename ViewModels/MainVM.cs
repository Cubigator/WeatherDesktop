using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDesktop.ViewModels
{
    internal class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        WeatherHandler weatherHandler;
        Weather _weather;

        string _temperature;
        string _city;

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                Invoke("City");
            }
        }
        public string Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                Invoke("Temperature");
            }
        }

        public ButtonCommand ButtonClick
        {
            get
            {
                return new ButtonCommand(() =>
                {
                    weatherHandler = new WeatherHandler();
                    _weather = weatherHandler.GetActualWeather();
                    Temperature = _weather.Main.Temp.ToString();
                    City = _weather.Name;
                    Invoke("ButtonClick");
                });
            }
        }

        public void Invoke(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
