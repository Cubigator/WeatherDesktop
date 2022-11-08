using Newtonsoft.Json;
using System.IO;

namespace WeatherDesktop
{
    static internal class SavingsHandler
    {
        public static void UpdateSettings(Weather weather)
        {
            string json = JsonConvert.SerializeObject(weather);
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            FileStream file = new FileStream(path + "\\SavedData\\savings.json", FileMode.Truncate);
            StreamWriter writer = new StreamWriter(file);

            writer.Write(json);
            writer.Flush();

            writer.Close();
            file.Close();
        }
        public static Weather GetSettings()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            FileStream file = new FileStream(path + "\\SavedData\\savings.json", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            string json = reader.ReadToEnd();

            Weather weather = JsonConvert.DeserializeObject(json, typeof(Weather)) as Weather;
            file.Close();
            reader.Close();
            return weather;
        }
    }
}
