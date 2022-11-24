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

namespace DeviceRepairCRM.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DeviceFramePartsUC.xaml
    /// </summary>
    public partial class DeviceFramePartsUC : UserControl
    {
        public DeviceFramePartsUC()
        {
            InitializeComponent();
        }
        public DeviceFrame deviceFrame;
        public int id;
        private void DevicePartDecreesBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
