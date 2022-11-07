using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace WeatherDesktop
{
    internal class WeatherHandler
    {
        private string _token = "b4501ae65c6d19177e5600027f7ec06a";
        private string _lat = "55.0282171";  //Новосибирские координаты (по умолчанию)
        private string _lon = "82.9234509";  //Новосибирские координаты (по умолчанию)
        public WeatherHandler()
        {
           
        }
        private void UpdateCoords(string cityName)
        {
            
                string _url = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName},RUS&appid={_token}";
                HttpWebRequest request = WebRequest.Create(_url) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                string json;

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }
                List<Coordinates> coordinates = JsonConvert.DeserializeObject(json, typeof(List<Coordinates>)) as List<Coordinates>;
                //List, так как может быть несколько городов с одинаковым названием, а значит несколько координат
                _lat = coordinates[0].Lat.ToString();
                _lon = coordinates[0].Lon.ToString();
        }
        public Weather GetActualWeather(string cityName)
        {
            UpdateCoords(cityName);

            string _url = $"http://api.openweathermap.org/data/2.5/weather?lat={_lat}&lon={_lon}&appid={_token}&units=metric";
            HttpWebRequest request = WebRequest.Create(_url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            string json;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                json = reader.ReadToEnd();
            }
            Weather result = JsonConvert.DeserializeObject(json, typeof(Weather)) as Weather;
            return result;
        }
    }
}
