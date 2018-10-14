using Client.Models;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    class BodyViewModel: ViewModelBase
    {
        #region 属性
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        #endregion

        #region 方法
        public BodyViewModel()
        {
            
        }
        #endregion
    }
}
