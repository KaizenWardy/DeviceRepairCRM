using DeviceRepairCRM.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DeviceRepairCRM.Frames.NewOrderFrames
{
    /// <summary>
    /// Логика взаимодействия для NewOrderInfoFrame.xaml
    /// </summary>
    public partial class NewOrderInfoFrame : Page
    {
        public NewOrderWindow window;
        public NewOrderInfoFrame()
        {
            InitializeComponent();
        }

        private void CreateOrderBt_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader reader = new Connect().SqlSelect($@"
                INSERT INTO [dbo].[Order]
                           ([Device]
                           ,[Description]
                           ,[Price]
                           ,[Client]
                           ,[Status]
                            ,[StartDate])
                      VALUES   
                           ({window.DeviceId}
                           ,'{OrderProblem.Text}'
                           ,{Convert.ToInt32(OrderPrice.Text)}
                           ,{window.ClientId}
                           ,1
                           ,'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}')");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClientName.Text = reader[1].ToString();
                    ClientName.Text = ClientName.Text + " " + reader[2].ToString();
                }
            }
            window.MainWindow.Grid_Loaded(sender, e);
            ClientFrame clientFrame2 = new ClientFrame();
            clientFrame2.window = window;
            window.NewOrderFrame.Content = clientFrame2;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SqlDataReader reader = new Connect().SqlSelect($@"
                SELECT [Client].[Id]
                      ,[Client].[FirstName]
                      ,[Client].[SecondName]
                  FROM [RepairShop].[dbo].[Client]
  
                  WHERE id like {window.ClientId}");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClientName.Text = reader[1].ToString();
                    ClientName.Text = ClientName.Text + " " + reader[2].ToString();
                }
            }
            SqlDataReader reader2 = new Connect().SqlSelect($@"
SELECT TOP (1000) Device.[Id]
,[DeviceManufacture].[Name] as MName
,[Model]

FROM [RepairShop].[dbo].[Device]
inner join [DeviceManufacture] on
[DeviceManufacture].Id = [Device].Manufacture
  
WHERE Device.Id like {window.DeviceId}");

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    DeviceName.Text = reader2[1].ToString();
                    DeviceName.Text = DeviceName.Text + " " + reader2[2].ToString();
                }
            }
        }

        private void OrderPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
