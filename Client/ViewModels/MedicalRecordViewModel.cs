using Client.Models;
using Client.Windows;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
    class MedicalRecordViewModel: ViewModelBase
    {
        #region 属性
        // 添加Window属性
        private static WindowMedicalRecord _window { get; set; }
        private HealthManagementEntities db = new HealthManagementEntities();
        private IEnumerable<PAnamnesis> anamnesis;
        public IEnumerable<PAnamnesis> Anamnesis
        {
            get { return anamnesis; }
            set
            {
                anamnesis = value;
                OnPropertyChanged("Anamnesis");
            }
        }

        private IEnumerable<AnamnesisClass> anaClass;
        public IEnumerable<AnamnesisClass> AnaClass
        {
            get { return anaClass; }
            set
            {
                anaClass = value;
                OnPropertyChanged("AnaClass");
            }
        }

        private IEnumerable<Patient> patient;
        public IEnumerable<Patient> Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }

        private string anaText;
        public string AnaText
        {
            get { return anaText; }
            set
            {
                anaText = value;
                OnPropertyChanged("AnaText");
            }
        }

        private string anaClassID;
        public string AnaClassID
        {
            get { return anaClassID; }
            set
            {
                anaClassID = value;
                OnPropertyChanged("AnaClassID");
            }
        }

        private string anaDate;
        public string AnaDate
        {
            get { return anaDate; }
            set
            {
                anaDate = value;
                OnPropertyChanged("AnaDate");
            }
        }

        private int patID;
        public int PatID
        {
            get { return patID; }
            set
            {
                patID = value;
                OnPropertyChanged("PatID");
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #region 方法
        //打开添加界面
        public DelegateCommand OpenAddCommand { get; private set; }
        private void OpenAdd()
        {
            _window._add.Visibility = Visibility.Visible;
        }
        //关闭添加界面
        public DelegateCommand CloseAddComand { get; private set; }
        private void CloseAdd()
        {
            _window._add.Visibility = Visibility.Collapsed;
        }
        //添加病历
        public DelegateCommand AddCommand { get; private set; }
        private void Add()
        {
            if (anaClassID == "" || anaClassID == null)
            {
                MessageBox.Show("请选择病历类型");
                return;
            }
            else if (anaDate == "" || anaDate == null)
            {
                MessageBox.Show("请输入病历时间");
                return;
            }
            else if (anaText == "" || anaText == null)
            {
                MessageBox.Show("请输入病历内容");
                return;
            }

            PAnamnesis anamnesis = new PAnamnesis();
            anamnesis.AClID = int.Parse(anaClassID);
            anamnesis.AnaDate = Convert.ToDateTime(anaDate);
            anamnesis.AnaCDate = DateTime.Now;
            anamnesis.AnaText = anaText;
            anamnesis.PatientID = PatID;
            db.PAnamnesis.Add(anamnesis);
            db.SaveChanges();
            AnaClassID = null;
            AnaDate = null;
            AnaText = null;
            _window._add.Visibility = Visibility.Collapsed;
            Synchronous();
        }
        //删除病历
        public DelegateCommand<int?> DelCommand { get; set; }
        private void Del(int? anaid)
        {
            MessageBoxResult result = MessageBox.Show("确定删除次数据吗?","提示",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                PAnamnesis anamnesis = db.PAnamnesis.Find(anaid);
                db.PAnamnesis.Remove(anamnesis);
                db.SaveChanges();
                Synchronous();
            }
        }
        //病历同步
        public DelegateCommand SynchronousCommand { get; private set; }
        private void Synchronous()
        {
            try
            {
                Anamnesis = (from a in db.PAnamnesis join p in db.Patient on a.PatientID equals p.PatientID
                             where p.UserID == Auth.User
                             select a).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //构造函数
        public MedicalRecordViewModel(object win)
        {
            AnaClass = (from a in db.AnamnesisClass
                        orderby a.AClOrder
                        select a).ToList();

            Patient = (from p in db.Patient
                       where p.UserID == Auth.User
                       select p).ToList();

            SynchronousCommand = new DelegateCommand(Synchronous);
            OpenAddCommand = new DelegateCommand(OpenAdd);
            CloseAddComand = new DelegateCommand(CloseAdd);
            AddCommand = new DelegateCommand(Add);
            DelCommand = new DelegateCommand<int?>(Del);
            _window = (WindowMedicalRecord)win;
        }
        #endregion
    }
}
