namespace WeatherDesktop.ViewModels
{
    static internal class GetImagePath
    {
        public static string GetPath(string state)
        {
            if (state.ToLower().IndexOf("rain") != -1)
                return "https://png.pngtree.com/png-vector/20190216/ourmid/pngtree-vector-rain-icon-png-image_540906.jpg";
            if (state.ToLower().IndexOf("snow") != -1)
                return "https://cdn-icons-png.flaticon.com/512/2140/2140220.png";
            if (state.ToLower().IndexOf("haze") != -1 || state.ToLower().IndexOf("mist") != -1)
                return "https://png.pngtree.com/element_our/20200610/ourmid/pngtree-thick-fog-image_2248493.jpg";
            if (state.ToLower().IndexOf("clouds") != -1)
                return "https://thypix.com/wp-content/uploads/2021/06/clouds-transparent-background-77-700x700.png";
            if (state.ToLower().IndexOf("clear") != -1)
                return "http://pngimg.com//uploads//sun//small//sun_PNG13448.png";
            return "";
        }
    }
}
