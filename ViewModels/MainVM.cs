using System.ComponentModel;

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
                    try
                    {
                        weatherHandler = new WeatherHandler();
                        _weather = weatherHandler.GetActualWeather(MainWindow.enteredCity);
                        Temperature = _weather.Main.Temp.ToString();
                        City = _weather.Name;
                        Invoke("ButtonClick");
                    }
                    catch { City = "Неверный ввод"; }
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
