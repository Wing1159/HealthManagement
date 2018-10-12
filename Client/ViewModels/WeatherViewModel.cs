using Client.Models;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

namespace Client.ViewModels
{
    class WeatherViewModel: ViewModelBase
    {
        #region 属性
        private string province;

        public string Province
        {
            get { return province; }
            set
            {
                province = value;
                OnPropertyChanged("Province");
            }
        }

        private string city;

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }
        private string temperature;

        public string Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        private string _UVIndex;

        public string UVIndex
        {
            get { return _UVIndex; }
            set
            {
                _UVIndex = value;
                OnPropertyChanged("UVIndex");
            }
        }

        private string airPollutionIndex;

        public string AirPollutionIndex
        {
            get { return airPollutionIndex; }
            set
            {
                airPollutionIndex = value;
                OnPropertyChanged("AirPollutionIndex");
            }
        }

        private string weather;

        public string Weather
        {
            get { return weather; }
            set
            {
                weather = value;
                OnPropertyChanged("Weather");
            }
        }

        private string weatherIcon;

        public string WeatherIcon
        {
            get { return weatherIcon; }
            set { weatherIcon = value; }
        }


        private string humidity;

        public string Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }


        private string wind;

        public string Wind
        {
            get { return wind; }
            set
            {
                wind = value;
                OnPropertyChanged("Wind");
            }
        }
        #endregion

        #region 方法
        public WeatherViewModel()
        {
            WebRequest wr = WebRequest.Create("http://pv.sohu.com/cityjson");
            Stream s = wr.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.Default);
            string weball = sr.ReadToEnd(); //读取网站的数据
            city = weball.Substring(weball.IndexOf('省') + 1, weball.IndexOf('市') - weball.IndexOf('省') - 1);

            using (WeatherService.WeatherWebService weatherSer = new WeatherService.WeatherWebService())
            {
                string[] str = new string[30];
                try
                {
                    str = weatherSer.getWeatherbyCityName(city);
                    province = str[0];
                    weather = str[6];
                    weather = weather.Replace(weather.Substring(0, weather.IndexOf(' ') + 1), null);
                    weather = weather.Trim();
                    //weatherIcon = StringToIconString.Weather(weather);
                    weatherIcon = weather;
                    string tmp = str[10];
                    tmp = tmp.Replace("。", "；");
                    tmp = tmp.Replace("今日天气实况：", null);
                    string[] weathers = tmp.Split('；');
                    temperature = weathers[0].Replace("气温：", null);
                    wind = weathers[1].Replace("风向/风力：", null);
                    humidity = weathers[2].Replace("湿度：", null);
                    _UVIndex = weathers[3].Replace("紫外线强度：", null);
                    airPollutionIndex = weathers[4].Replace("空气质量：", null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
    }
}
