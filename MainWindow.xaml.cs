using System.Windows;

namespace WeatherDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static internal string enteredCity = ""; // введенный текст из TextBox, почему по умолчанию пустой в MainVM
        public MainWindow()
        {
            InitializeComponent();
        }

        private void enterCity_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            enteredCity = enterCity.Text;
        }
    }
}
