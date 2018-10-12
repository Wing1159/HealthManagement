using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class HomeViewModel
    {
        #region 属性
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        #endregion

        #region 方法
        public DelegateCommand UserSetCommand { get; private set; }
        private void userSet()
        {

        }
        public HomeViewModel()
        {
            UserSetCommand = new DelegateCommand(userSet);
        }
        #endregion
    }
}
