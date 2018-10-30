using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Client.Windows
{
    /// <summary>
    /// WindowHWeather.xaml 的交互逻辑
    /// </summary>
    public partial class WindowHWeather : UserControl
    {
        public WindowHWeather()
        {
            InitializeComponent();
            DataContext = new WeatherViewModel();
        }

        private void tbIconWeather_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //tbIconWeather.Text = StringToIconString.Weather(tbIconWeather.Text);
        }
    }
}
