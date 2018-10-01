using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels
{
    class LoginViewModel:ViewModelBase
    {
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
        public DelegateCommand LoginCommand { get; private set; }

        private void login()
        {
            string mes = string.Format("{0},{1}", userName, userPassWord);
            MessageBox.Show(mes);
        }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(login); 
        }
    }
}
