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

            ShutdownMode = ShutdownMode.OnLastWindowClose;

            //启动窗口
            main = new MainWindow();
            //Windows.RegisterWindow login = new Windows.RegisterWindow();
            Windows.LoginWindow login = new Windows.LoginWindow();
            login.Show();
        }
    }
}
