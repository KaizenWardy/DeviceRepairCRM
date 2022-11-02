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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            OrderPageStackPanel.Children.Add(new OrderUserControl());
            OrderPageStackPanel.Children.Add(new OrderUserControl());
            OrderPageStackPanel.Children.Add(new OrderUserControl());
            OrderPageStackPanel.Children.Add(new OrderUserControl());
            OrderPageStackPanel.Children.Add(new OrderUserControl());
            OrderPageStackPanel.Children.Add(new OrderUserControl());
        }
    }
}
