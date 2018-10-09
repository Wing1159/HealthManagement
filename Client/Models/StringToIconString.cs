using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public static class StringToIconString
    {
        /// <summary>
        /// WeatherWebService中天气文字转换成Icon文字
        /// </summary>
        /// <param name="weather">天气描述文字</param>
        /// <returns></returns>
        public static string Weather(string weather)
        {
            switch (weather)
            {
                case "晴":
                    return "&#xe684;";
                case "多云":
                    return "&#xe67f;";
                case "阴":
                    return "&#xe68e;";
                case "小雨":
                    return "&#xe691;";
                case "中雨":
                    return "&#xe689;";
                case "大雨":
                    return "&#xe697;";
                case "阵雨":
                    return "&#xe67a;";
                case "雷阵雨":
                    return "&#xe683;";
                case "雷阵雨并伴有冰雹":
                    return "&#xe682;";
                case "暴雨":
                    return "&#xe676;";
                case "大暴雨":
                    return "&#xe675;";
                case "特大暴雨":
                    return "&#xe685;";
                case "雨夹雪":
                    return "&#xe693;";
                case "冻雨":
                    return "&#xe67e;";
                case "小雪":
                    return "&#xe68d;";
                case "中雪":
                    return "&#xe68f;";
                case "大雪":
                    return "&#xe694;";
                case "阵雪":
                    return "&#xe678;";
                case "暴雪":
                    return "&#xe674;";
                case "雾":
                    return "&#xe688;";
                case "沙尘暴":
                    return "&#xe686;";
                case "浮尘":
                    return "&#xe681;";
                case "扬沙":
                    return "&#xe690;";
                case "强沙尘暴":
                    return "&#xe687;";
                case "雾霾":
                    return "&#xe68b;";
                case "晴转小雨":
                case "小雨转晴":
                    return "&#xe696;";
                case "中雨转小雨":
                case "小雨转中雨":
                    return "&#xe68c;";
                case "中雨转大雨":
                case "大雨转中雨":
                    return "&#xe698;";
                case "大雨转暴雨":
                case "暴雨转大雨":
                    return "&#xe67c;";
                case "暴雨转大暴雨":
                case "大暴雨转暴雨":
                    return "&#xe677;";
                case "特大暴雨转大暴雨":
                case "大暴雨转特大暴雨":
                    return "&#xe67b;";
                case "晴转小雪":
                case "小雪转晴":
                    return "&#xe692;";
                case "中雪转小雪":
                case "小雪转中雪":
                    return "&#xe68a;";
                case "中雪转大雪":
                case "大雪转中雪":
                    return "&#xe695;";
                case "大雪转暴雪":
                case "暴雪转大雪":
                    return "&#xe679;";
                default:
                    return "&#xe756;";
            }
        }
    }
}
