using DeviceRepairCRM.Frames.NewOrderFrames;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeviceRepairCRM.UserControls
{
    public partial class NewOrderClientUC : UserControl
    {
        public int id;
        public ClientFrame Frame;
        public NewOrderClientUC()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Frame.ClearClientNameBorder.Visibility = Visibility.Visible;
            Frame.NextBtBorder.Visibility = Visibility.Visible;

            Frame.FName.Text = UCClientFName.Text;
            Frame.SName.Text = UCClientSName.Text;
            Frame.Phone.Text = UCClientPhone.Text;

            Frame.id = id;
        }
    }
}
