using Client.Models;
using Client.Windows;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
    class LoginViewModel:ViewModelBase
    {
        #region 属性
        // 添加Window属性
        private static LoginWindow window { get; set; }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string userPassWord;

        public string UserPassWrod
        {
            get { return userPassWord; }
            set
            {
                userPassWord = value;
                OnPropertyChanged("UserPassWrod");
            }
        }
        #endregion

        #region 方法
        public DelegateCommand LoginCommand { get; private set; }
        /// <summary>
        /// 登陆
        /// </summary>
        private void login()
        {
            //string mes = string.Format("{0},{1}", userName, userPassWord);
            //MessageBox.Show(mes);
            try
            {
                if (userName == null || userName == "")
                {
                    CloseLoading("请输入账号！");
                    window.tbUserName.Focus();
                    return;
                    
                }
                else if (userPassWord == null || userPassWord == "")
                {
                    CloseLoading("请输入密码！");
                    window.pbUserPWD.Focus();
                    return;
                }
                window._loading.Visibility = Visibility.Visible;
                using (HealthManagementEntities db = new HealthManagementEntities())
                {
                    var user = from u in db.User
                               where u.UserID == userName
                               select u;
                    foreach (var u in user)
                    {
                        if (u.UserID == userName && u.UserPassWord == Encode_MD5.MD5Encrypt(userPassWord))
                        {
                            Auth.IsLogin = true;
                            Auth.User = userName;
                        }
                    }
                }
                if (Auth.IsLogin == false)
                {
                    CloseLoading("请检查用户名和密码");
                    UserPassWrod = null;
                    window.pbUserPWD.Focus();
                }
                else
                {
                    window.Close();
                    //new MainWindow().Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                CloseLoading();
            }
        }
        /// <summary>
        /// 构造函数，接收window作为参数
        /// </summary>
        public LoginViewModel(object win)
        {
            LoginCommand = new DelegateCommand(login);
            window = (LoginWindow)win;
        }
        /// <summary>
        /// 关闭遮罩控件
        /// </summary>
        public static void CloseLoading()
        {
            window._loading.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// 关闭遮罩控件，并提示错误
        /// </summary>
        /// <param name="err">错误信息字符</param>
        public static void CloseLoading(string err)
        {
            MessageBox.Show(err);
            window._loading.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
