using DeviceRepairCRM.Frames.NewOrderFrames;
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
    /// Логика взаимодействия для DeviceSelectUC.xaml
    /// </summary>
    public partial class DeviceSelectUC : UserControl
    {
        public int id;
        public DeviceSelectFrame Frame;
        public DeviceSelectUC()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Frame.ClearDeviceNameBtBorder.Visibility = Visibility.Visible;

            Frame.DeviceMNf.Text = UCDeviceMnf.Text;
            Frame.DeviceMdl.Text = UCDeviceMdl.Text;
            Frame.DeviceArt.Text = UCDeviceArt.Text;

            Frame.id = id;
        }
    }
}