using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class SuggestViewModel
    {
        #region 属性
        private string suggest;

        public string Suggest
        {
            get { return suggest; }
            set { suggest = value; }
        }
        #endregion

        #region 方法
        public SuggestViewModel()
        {

        }
        #endregion
    }
}
