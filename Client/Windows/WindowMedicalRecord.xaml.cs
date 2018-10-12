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
    /// WindowMedicalRecord.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMedicalRecord : UserControl
    {
        public WindowMedicalRecord()
        {
            InitializeComponent();
            DataContext = new MedicalRecordViewModel();
        }

        private void btnSynchronous_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(dgAnamnesis.Items.Count.ToString());
            }
            catch
            {

            }
        }
    }
}
