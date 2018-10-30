using Client.Models;
using Client.Windows;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace Client.ViewModels
{
    class PatientDataViewModel : ViewModelBase
    {
        #region 属性
        private static int Pid;
        //窗口
        private static WindowPatient _window { get; set; }
        //病人信息列表
        private IEnumerable<Patient> patdata;
        public IEnumerable<Patient> PatData
        {
            get { return patdata; }
            set
            {
                patdata = value;
                OnPropertyChanged("PatData");
            }
        }
        //姓名
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        //出生日期
        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }
        //性别
        private string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged("Sex");
            }
        }
        //手机号
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        //身高
        private double height;
        public double Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }
        //体重
        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged("Weight");
            }
        }
        //值名称
        private string valueName;
        public string ValueName
        {
            get { return valueName; }
            set
            {
                valueName = value;
                OnPropertyChanged("ValueName");
            }
        }
        //值
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        #endregion

        #region 方法
        public PatientDataViewModel(object win)
        {
            SaveCommand = new DelegateCommand<int?>(Save);
            SynchronousCommand = new DelegateCommand(Synchronous);
            OpenAddPCommand = new DelegateCommand(OpenAddP);
            CloseAddPComand = new DelegateCommand(CloseAddP);
            AddPCommand = new DelegateCommand(AddP);
            DelPCommand = new DelegateCommand<int?>(DelP);

            //病人身体
            OpenAddPDCommand = new DelegateCommand<int?>(OpenAddPD);
            CloseAddPDComand = new DelegateCommand(CloseAddPD);
            AddPDCommand = new DelegateCommand(AddPD);
            DelPDCommand = new DelegateCommand<int?>(DelPD);
            _window = (WindowPatient)win;
        }
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="PID">病人ID</param>
        private void GetBoay(int PID)
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                var data = db.Patient.Find(Auth.User);
                Name = data.PatientName;
                Sex = data.PatientSex;
                Birthday = Convert.ToDateTime(data.PatientBirthday);
                Weight = Convert.ToDouble(data.PatientWeight);
                Height = Convert.ToDouble(data.PatientHeight);
                Phone = data.PatientPhone;
            }
        }
        //添加病人数据
        public DelegateCommand AddPCommand { get; private set; }
        private void AddP()
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                Patient p = new Patient();
                p.PatientBirthday = birthday;
                p.PatientName = name;
                p.PatientPhone = phone;
                p.PatientSex = sex;
                p.PatientWeight = weight;
                p.PatientHeight = height;
                p.UserID = Auth.User;
                db.Patient.Add(p);
                db.SaveChanges();
            }
            CloseAddP();
            Synchronous();
        }
        //打开添加病人界面
        public DelegateCommand OpenAddPCommand { get; private set; }
        private void OpenAddP()
        {
            _window._addp.Visibility = Visibility.Visible;
        }
        //关闭添加界面
        public DelegateCommand CloseAddPComand { get; private set; }
        private void CloseAddP()
        {
            _window._addp.Visibility = Visibility.Collapsed;
            Value = null;
            ValueName = null;
        }
        //保存病人数据
        public DelegateCommand<int?> SaveCommand { get; private set; }
        private void Save(int? PID)
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                Patient u = db.Patient.Find(PID);
                u.PatientName = name;
                u.PatientBirthday = birthday;
                u.PatientPhone = phone;
                u.PatientSex = sex;
                u.PatientWeight = weight;
                u.PatientHeight = height;
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        //打开添加数据界面
        public DelegateCommand<int?> OpenAddPDCommand { get; private set; }
        private void OpenAddPD(int? pid)
        {
            _window._addpd.Visibility = Visibility.Visible;
            Pid = Convert.ToInt32(pid);
        }
        //关闭添加数据界面
        public DelegateCommand CloseAddPDComand { get; private set; }
        private void CloseAddPD()
        {
            _window._addpd.Visibility = Visibility.Collapsed;
            Value = null;
            ValueName = null;
            Pid = -1;
        }
        //删除病人数据
        public DelegateCommand<int?> DelPCommand { get; set; }
        private void DelP(int? pid)
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                MessageBoxResult result = MessageBox.Show("确定删除次数据吗?", "提示", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Patient u = db.Patient.Find(pid);
                    db.Patient.Remove(u);
                    db.SaveChanges();
                    Synchronous();
                }
            }
        }
        //添加身体数据
        public DelegateCommand AddPDCommand { get; private set; }
        private void AddPD()
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                PData d = new PData();
                d.DataName = valueName;
                d.DataValue = _value;
                d.PatientID = Convert.ToInt32(Pid);
                db.PData.Add(d);
                db.SaveChanges();
            }
            CloseAddP();
        }
        //删除身体数据
        public DelegateCommand<int?> DelPDCommand { get; set; }
        private void DelPD(int? pdid)
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                MessageBoxResult result = MessageBox.Show("确定删除次数据吗?", "提示", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    PData u = db.PData.Find(pdid);
                    db.PData.Remove(u);
                    db.SaveChanges();
                    Synchronous();
                }
            }
        }
        //身体数据同步
        public DelegateCommand SynchronousCommand { get; private set; }
        private void Synchronous()
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                try
                {
                    PatData = (from a in db.Patient
                               where a.UserID == Auth.User
                                select a).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
    }
}