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

namespace DeviceRepairCRM
{
    /// <summary>
    /// Логика взаимодействия для DeviceFrame.xaml
    /// </summary>
    public partial class DeviceFrame : Page
    {
        public DeviceFrame()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ManufactureStackPanel.Children.Add(new DeviceFrameManufactureUC());
            ManufactureStackPanel.Children.Add(new DeviceFrameManufactureUC());
            ManufactureStackPanel.Children.Add(new DeviceFrameManufactureUC());
            ManufactureStackPanel.Children.Add(new DeviceFrameManufactureUC());
            ManufactureStackPanel.Children.Add(new DeviceFrameManufactureUC());
        }
    }
}
