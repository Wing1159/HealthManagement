using Client.Models;
using DMSkin.WPF.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public MainWindow main;
        protected override void OnStartup(StartupEventArgs e)
        {
            //初始化UI Dispatcher
            Execute.InitializeWithDispatcher();
            //设置只有最后一个窗体关闭后，程序才进行关闭
            ShutdownMode = ShutdownMode.OnLastWindowClose;
            
            ////启动窗口
            main = new MainWindow();
            MainWindow = main;
            main.Show();
            ////Windows.RegisterWindow login = new Windows.RegisterWindow();
            //Windows.LoginWindow login = new Windows.LoginWindow();
            //login.ShowDialog();
            ////判断是否登陆
            //if (Auth.IsLogin)
            //{
            //    //启动主界面   
            //    main.Show();
            //}
            //else
            //{
            //    main.Close();
            //}
        }
    }
}
