using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WeatherDesktop
{
    internal class WeatherHandler
    {
        private string _token = "b4501ae65c6d19177e5600027f7ec06a";
        private string _lat = "55.0282171";  //Новосибирские координаты
        private string _lon = "82.9234509";  //Новосибирские координаты
        public WeatherHandler()
        {
           
        }
        public Weather GetActualWeather()
        {
            string _url = $"http://api.openweathermap.org/data/2.5/weather?lat={_lat}&lon={_lon}&appid={_token}";
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
