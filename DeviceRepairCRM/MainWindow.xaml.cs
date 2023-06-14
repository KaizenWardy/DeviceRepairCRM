using DeviceRepairCRM.Frames;
using System.Windows;

namespace DeviceRepairCRM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Grid_Loaded(object sender, RoutedEventArgs e)
        { MainFrame.Content = new OrderFrame(); }

        private void DeviceFrameBt_Click(object sender, RoutedEventArgs e)
        {MainFrame.Content = new DeviceFrame();}

        private void OrderFrameBt_Click(object sender, RoutedEventArgs e)
        {MainFrame.Content = new OrderFrame();}

        private void MasterFrameBt_Click(object sender, RoutedEventArgs e)
        {MainFrame.Content = new MasterFrame();}
        private void ClientFrameBt_Click(object sender, RoutedEventArgs e)
        {MainFrame.Content = new ClientFrame();}

        private void FastOrderFrameBt_Click(object sender, RoutedEventArgs e)
        {
            NewOrderWindow newOrderWindow = new NewOrderWindow();
            newOrderWindow.MainWindow = this;
            newOrderWindow.Show();
        }

    }
}
