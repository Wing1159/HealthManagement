using Client.Models;
using Client.Windows;
using DMSkin;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
    class HomeViewModel: ViewModelBase
    {
        #region 属性
        private static WindowHome _window { get; set; }

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
        //手机号
        private string profession;
        public string Profession
        {
            get { return profession; }
            set
            {
                profession = value;
                OnPropertyChanged("Profession");
            }
        }
        //医院
        private string hospital;
        public string Hospital
        {
            get { return hospital; }
            set
            {
                hospital = value;
                OnPropertyChanged("Hospital");
            }
        }
        #endregion

        #region 方法
        public DelegateCommand UserSetCommand { get; private set; }
        private void UserSet()
        {
            _window._set.Visibility = Visibility.Visible;
        }
        public DelegateCommand SetCommand { get; private set; }
        private void Set()
        {
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                User u = db.User.Find(Auth.User);
                u.UserSex = sex;
                u.UserName = name;
                u.UserPhone = phone;
                u.UserBirthday = birthday;
                u.UserProfession = profession;
                u.Hospital = hospital;
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Close();
            }
        }
        public DelegateCommand CloseComand { get; private set; }
        private void Close()
        {
            _window._set.Visibility = Visibility.Collapsed;
        }
        public HomeViewModel(object win)
        {
            UserSetCommand = new DelegateCommand(UserSet);
            SetCommand = new DelegateCommand(Set);
            CloseComand = new DelegateCommand(Close);
            _window = (WindowHome)win;
            using (HealthManagementEntities db = new HealthManagementEntities())
            {
                User u = db.User.Find(Auth.User);
                if(u != null)
                {
                    Name = u.UserName;
                    Birthday = Convert.ToDateTime(u.UserBirthday);
                    Sex = u.UserSex;
                    Phone = u.UserPhone;
                    Profession = u.UserProfession;
                    Hospital = u.Hospital;
                }
            }
        }
        #endregion
    }
}
