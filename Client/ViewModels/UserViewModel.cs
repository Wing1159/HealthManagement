using DMSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Models;
using Microsoft.Practices.Prism.Commands;
using Client.Windows;
using System.Windows;
using MaterialDesignThemes.Wpf.Transitions;

namespace Client.ViewModels
{
    class UserViewModel: ViewModelBase
    {
        #region 属性
        /// <summary>
        /// 添加Window属性
        /// </summary>
        private DMSkin.WPF.DMSkinSimpleWindow window { get; set; }
        private string userID;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userPWD;
        public string UserPWD
        {
            get { return userPWD; }
            set { userPWD = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string _VCode;
        public string VCode
        {
            get { return _VCode; }
            set { _VCode = value; }
        }
        //窗体进度条
        private int windowPB;
        public int WindowPB
        {
            get { return windowPB; }
            set { windowPB = value; }
        }

        #endregion

        #region 公共方法
        /// <summary>
        /// 用户注册
        /// </summary>
        public DelegateCommand RegiserCommand { get; private set; }
        private void regiser()
        {

        }
        /// <summary>
        /// 重置密码
        /// </summary>
        public DelegateCommand ResetCommand { get; private set; }
        private void reset()
        {

        }
        /// <summary>
        /// 返回登陆界面
        /// </summary>
        public DelegateCommand ReplyCommand { get; private set; }
        private void reply()
        {
            new LoginWindow().Show();
            window.Close();
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        public DelegateCommand VCodeGetCommand { get; private set; }
        private void _VCodeGet()
        {
            
        }
        /// <summary>
        /// 验证码验证
        /// </summary>
        public DelegateCommand VCodeVerCommand { get; private set; }
        private void _VCodeVer()
        {

        }
        /// <summary>
        /// 查找用户名
        /// </summary>
        public DelegateCommand FindUserIDCommand { get; private set; }
        private void findUserID()
        {

        }
        /// <summary>
        /// 下一页
        /// </summary>
        private void next()
        {
            
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserViewModel()
        {
            RegiserCommand = new DelegateCommand(regiser);
            ResetCommand = new DelegateCommand(reset);
            ReplyCommand = new DelegateCommand(reply);
            VCodeGetCommand = new DelegateCommand(_VCodeGet);
            VCodeVerCommand = new DelegateCommand(_VCodeVer);
            FindUserIDCommand = new DelegateCommand(findUserID);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="win">窗体对象</param>
        public UserViewModel(object win)
        {
            RegiserCommand = new DelegateCommand(regiser);
            ResetCommand = new DelegateCommand(reset);
            ReplyCommand = new DelegateCommand(reply);
            VCodeGetCommand = new DelegateCommand(_VCodeGet);
            VCodeVerCommand = new DelegateCommand(_VCodeVer);
            FindUserIDCommand = new DelegateCommand(findUserID);
            window = (DMSkin.WPF.DMSkinSimpleWindow)win;
        }
        #endregion
    }
}
