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

            using (FileStream file = new FileStream(path + "\\SavedData\\savings.json", FileMode.Open))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.Write(json);
                    writer.Flush();
                }
            }
        }
        public static Weather GetSettings()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            FileStream file = new FileStream(path + "\\SavedData\\savings.json", FileMode.Open);
            StreamReader reader = new StreamReader(file);

            string json = reader.ReadToEnd();

            Weather weather = JsonConvert.DeserializeObject(json, typeof(Weather)) as Weather;
            return weather;
        }
    }
}
