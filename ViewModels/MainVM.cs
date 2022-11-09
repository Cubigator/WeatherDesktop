using System.ComponentModel;

namespace WeatherDesktop.ViewModels
{
    internal class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        WeatherHandler weatherHandler;
        WeatherInfo _weather;

        string _temperature;
        string _feelsLike;
        string _city;
        string _pressure; //давление
        string _humidity; //влажность
        string _imagePath;
        string _speedOfWind;
        public MainVM()
        {
            _weather = SavingsHandler.GetSettings();
            Temperature = _weather.Main.Temp.ToString();
            FeelsLike = _weather.Main.Feels_Like.ToString();
            Pressure = _weather.Main.Pressure.ToString();
            Humidity = _weather.Main.Humidity.ToString();
            SpeedOfWind = _weather.Wind.Speed.ToString();
            City = _weather.Name;
        }
        public string SpeedOfWind
        {
            get { return _speedOfWind; }
            set
            {
                _speedOfWind = value;
                Invoke("SpeedOfWind");
            }
        }
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                Invoke("ImagePath");
            }
        }
        public string Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                Invoke("Pressure");
            }
        }
        public string Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                Invoke("Humidity");
            }
        }
        public string FeelsLike
        {
            get { return _feelsLike; }
            set
            {
                _feelsLike = value;
                Invoke("FeelsLike");
            }
        }
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
                    try
                    {
                        weatherHandler = new WeatherHandler();
                        _weather = weatherHandler.GetActualWeather(MainWindow.enteredCity);
                        Temperature = _weather.Main.Temp.ToString();
                        FeelsLike = _weather.Main.Feels_Like.ToString();
                        City = _weather.Name;
                        Pressure = _weather.Main.Pressure.ToString();
                        Humidity = _weather.Main.Humidity.ToString();
                        SpeedOfWind = _weather.Wind.Speed.ToString();
                        ImagePath = GetImagePath.GetPath(_weather.Weather[0].Main);
                        Invoke("ButtonClick");

                        SavingsHandler.UpdateSettings(_weather);
                    }
                    catch { City = "Такого города у нас нет("; }
                    //try catch от неправильного ввода города
                }, () =>
                {
                    return MainWindow.enteredCity != null;
                    //В кнопке Command срабатывает только 1 раз (при инициализации?),
                    //и затем, когда текст изменяется, не отрабатывает (если изначально
                    //текст пустой, кнопка всегда будет неактивной
                });
            }
        }

        public void Invoke(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
