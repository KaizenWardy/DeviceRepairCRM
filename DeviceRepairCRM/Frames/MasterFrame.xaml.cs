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
    public partial class MasterFrame : Page
    {
        public MasterFrame()
        {
            InitializeComponent();
        }

        public void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MasterList.Children.Clear();
            SqlDataReader reader = new Connect().SqlSelect($@"SELECT
            [Master].[Id]
            ,[Master].[FirstName]
            ,[Master].[SecondName]
            FROM [RepairShop].[dbo].[Master]");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MasterFrameUC uc = new MasterFrameUC();
                    uc.FirstName.Text = reader[1].ToString();
                    uc.SecondName.Text = reader[2].ToString();

                    MasterList.Children.Add(uc);
                }
            }
        }
    }
}
