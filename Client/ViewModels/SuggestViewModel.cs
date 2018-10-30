using Client.Models;
using Client.Windows;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
    class SuggestViewModel: ViewModelBase
    {
        #region 属性
        private string suggest;
        public string Suggest
        {
            get { return suggest; }
            set
            {
                suggest = value;
                OnPropertyChanged("Suggest");
            }
        }
        #endregion

        #region 方法
        public SuggestViewModel()
        {
            RGetCommand = new DelegateCommand(RGet);
            GetSuggest();
        }
        public DelegateCommand RGetCommand { get; private set; }
        private void RGet()
        {
            GetSuggest();
        }
        private void GetSuggest()
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                var sug = (from s in db.Suggest
                           orderby Guid.NewGuid()
                           select s.SugText).FirstOrDefault();
                Suggest = sug;
            }
        }
        #endregion
    }
}
