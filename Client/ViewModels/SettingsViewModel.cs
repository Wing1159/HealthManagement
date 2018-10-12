using DMSkin.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    class SettingsViewModel
    {
        #region 属性

        #endregion

        #region 方法
        public ICommand Set
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    //new SimpleWindow().Show();
                });
            }
        }
        #endregion
    }
}
