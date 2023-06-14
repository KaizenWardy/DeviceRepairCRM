using DeviceRepairCRM.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DeviceRepairCRM.Frames
{
    /// <summary>
    /// Логика взаимодействия для ClientFrame.xaml
    /// </summary>
    public partial class ClientFrame : Page
    {
        public ClientFrame()
        {
            InitializeComponent();
        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            ClientList.Children.Clear();
            SqlDataReader reader = new Connect().SqlSelect($@"SELECT
            [Client].[Id]
            ,[Client].[FirstName]
            ,[Client].[SecondName]
            ,[Client].[PhoneNumber]
            FROM [RepairShop].[dbo].[Client]");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClientFrameUC uc = new ClientFrameUC();
                    uc.FirstName.Text = reader[1].ToString();
                    uc.SecondName.Text = reader[2].ToString();
                    uc.Phone.Text = reader[3].ToString(); 

                    ClientList.Children.Add(uc);
                }
            }
        }
    }
}
