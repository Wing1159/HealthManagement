using Client.Models;
using Client.Windows;
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
        // 添加Window属性
        private static WindowMedicalRecord window { get; set; }
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

        private string anaText;
        public string AnaText
        {
            get { return anaText; }
            set { anaText = value; }
        }

        private string anaClass;
        public string AnaClass
        {
            get { return anaClass; }
            set { anaClass = value; }
        }

        private DateTime anaDate;
        public DateTime AnaDate
        {
            get { return anaDate; }
            set { anaDate = value; }
        }

        #endregion
        
        #region 方法
        public DelegateCommand OpenAddCommand { get; private set; }
        private void OpenAdd()
        {
            window._add.Visibility = Visibility.Visible;
        }

        public DelegateCommand CloseAddComand { get; private set; }
        private void CloseAdd()
        {
            window._add.Visibility = Visibility.Collapsed;
        }

        public DelegateCommand AddCommand { get; private set; }
        private void Add()
        {

        }

        public DelegateCommand DelCommand { get; private set; }
        private void Del()
        {

        }
        /// <summary>
        /// 病历同步
        /// </summary>
        public DelegateCommand SynchronousCommand { get; private set; }
        private void Synchronous()
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
        public MedicalRecordViewModel(object win)
        {
            SynchronousCommand = new DelegateCommand(Synchronous);
            OpenAddCommand = new DelegateCommand(OpenAdd);
            CloseAddComand = new DelegateCommand(CloseAdd);
            AddCommand = new DelegateCommand(Add);
            DelCommand = new DelegateCommand(Del);
            window = (WindowMedicalRecord)win;
        }
        #endregion
    }
}
