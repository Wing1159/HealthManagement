using DMSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Models;

namespace Client.ViewModels
{
    class UserViewModel: ViewModelBase
    {
        #region 私有字段
        private string uid;
        private string upwd;
        private ICommand loginCommand;
        #endregion

        #region 属性
        public ICommand LoginCommand
        {
            get { return loginCommand; }
        }

        public String UserID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        public String UserPassWrod
        {
            get
            {
                return upwd;
            }
            set
            {
                upwd = value;
            }
        }
        #endregion

        #region 公共方法
        #endregion
    }
}
