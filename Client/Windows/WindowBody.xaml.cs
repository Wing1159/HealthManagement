using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Windows
{
    /// <summary>
    /// WindowBody.xaml 的交互逻辑
    /// </summary>
    public partial class WindowBody : UserControl
    {
        public WindowBody()
        {
            InitializeComponent();
            DataContext = new PatientDataViewModel(this);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Collapsed;
            ControlEnabled(true);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            ControlEnabled(false);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            ControlEnabled(false);
        }
        private void ControlEnabled(bool IsEnabled)
        {
            tbHeight.IsEnabled = IsEnabled;
            tbName.IsEnabled = IsEnabled;
            tbPhone.IsEnabled = IsEnabled;
            tbProfession.IsEnabled = IsEnabled;
            tbWeight.IsEnabled = IsEnabled;
            cbSex.IsEnabled = IsEnabled;
            dpBirthday.IsEnabled = IsEnabled;
        }
    }
}
