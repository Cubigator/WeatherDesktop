using System.Collections.Generic;

namespace WeatherDesktop
{
    internal class WeatherInfo
    {
        public string Name { get; set; }
        public List<Precipitation> Weather { get; set; }
        public Breeze Wind { get; set; }
        public Temperature Main { get; set; }
    }
}
