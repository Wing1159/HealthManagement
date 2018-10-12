using Client.Models;
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
        /// <summary>
        /// 添加Window属性
        /// </summary>
        private DMSkin.WPF.DMSkinSimpleWindow window { get; set; }
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
                    MessageBox.Show("请检查用户名和密码");
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
            }
        }
        /// <summary>
        /// 构造函数，接收window作为参数
        /// </summary>
        public LoginViewModel(object win)
        {
            LoginCommand = new DelegateCommand(login);
            window = (DMSkin.WPF.DMSkinSimpleWindow)win;
        }
        #endregion
    }
}
