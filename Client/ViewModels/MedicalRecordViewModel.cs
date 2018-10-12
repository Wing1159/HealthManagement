using Client.Models;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
    class MedicalRecordViewModel: ViewModelBase
    {
        #region 属性
        private HealthManagementEntities db = new HealthManagementEntities();
        private IEnumerable<UAnamnesis> anamnesis;

        public IEnumerable<UAnamnesis> Anamnesis
        {
            get { return anamnesis; }
            set
            {
                anamnesis = value;
                OnPropertyChanged("Anamnesis");
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 病历同步
        /// </summary>
        public DelegateCommand SynchronousCommand { get; private set; }
        private void synchronous()
        {
            try
            {
                Anamnesis = (from a in db.UAnamnesis
                             where a.UserID == Auth.User
                             select a).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public MedicalRecordViewModel()
        {
            SynchronousCommand = new DelegateCommand(synchronous);
        }
        #endregion
    }
}
