using System;
using System.Data.SqlClient;
using System.Windows;

namespace DeviceRepairCRM.Frames
{

    public partial class ChangeStatusWarning : Window
    {
        public int OrderId;
        public OrderFrame frame;
        public int OrderStatusInt;
        public int OrderNewStatusInt;
        public ChangeStatusWarning()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (OrderNewStatusInt == 2)
            {
                return;
            }
            else
            {
                SqlDataReader reader = new Connect().SqlSelect("SELECT [FirstName], [SecondName] FROM [dbo].[Master]");
                while (reader.Read())
                {
                    MasterComboBox.Items.Add(reader[0].ToString() + " " + reader[1].ToString());
                }
            }
        }

        private void MasterSelectBt_Click(object sender, RoutedEventArgs e)
        {
            if (OrderNewStatusInt == 2) 
            {
                return;
            }
            else
            {
            OrderNewStatusInt = OrderStatusInt + 1 == 3 ? OrderStatusInt = 1 : OrderStatusInt = 2;
            new Connect().SqlEditAddDel($@"UPDATE [dbo].[Order]
               SET [Master] = {MasterComboBox.SelectedIndex + 5}
                  ,[Status] = {OrderNewStatusInt}
                    ,[EndDate] = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff")}'
             WHERE [Order].[Id] = {OrderId}");
            }
        }
    }
}
