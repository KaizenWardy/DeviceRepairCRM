using DeviceRepairCRM.Frames;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DeviceRepairCRM
{
    public partial class OrderFrameUC : UserControl
    {
        public int Clientid;
        public int DeviceId;
        public int OrderId;
        public int OrderStatusInt;
        public OrderFrame OrderFrame;
        public OrderFrameUC()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (OrderStatusInt == 1)
            {
                OrderStatus.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#EC2D01");
            }
            else if (OrderStatusInt == 2)
            {
                OrderStatus.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#008000");
                OrderEndDateTextBlock.Visibility = Visibility.Visible;
                OrderEndDate.Visibility = Visibility.Visible;
            }

        }

        private void OrderStatus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (OrderStatusInt == 2)
            {
                return;
            }
            else
            {

                ChangeStatusWarning changeStatusWarning = new ChangeStatusWarning();
                changeStatusWarning.OrderId = OrderId;
                changeStatusWarning.frame = OrderFrame;
                changeStatusWarning.OrderStatusInt = OrderStatusInt;
                changeStatusWarning.ShowDialog();
                Grid_Loaded(sender, e);
            }
            
        }
    }
}
