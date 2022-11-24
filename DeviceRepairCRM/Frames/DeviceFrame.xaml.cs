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
            DeviceList.Children.Clear();
            SqlDataReader reader = new Connect().SqlSelect($@"SELECT TOP (1000)
            Device.Id
            ,Device.Article
            ,Device.Model
            ,Manufacture.Name 
            AS Manufacture
            FROM [RepairShop].[dbo].[Device]
            INNER JOIN
            Manufacture 
            ON Device.Manufacture = Manufacture.Id");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeviceFrameUC uc = new DeviceFrameUC();

                    uc.Id = reader[0].ToString();
                    uc.DeviceManufacture.Content = reader[3];
                    uc.DeviceArticle.Content = reader[1];
                    uc.DeviceModel.Content = reader[2];
                    
                    DeviceList.Children.Add(uc);
                }
            }

            
        }
        public void DeviceOptionLoad(int id)
        {
            SqlDataReader reader = new Connect().SqlSelect($@"SELECT
            Device.Article
            ,Device.Model
            ,Device.YearOfRelease
            ,Manufacture.Name 
            AS Manufacture
            FROM [RepairShop].[dbo].[Device]
            INNER JOIN
            Manufacture 
            ON Device.Manufacture = Manufacture.Id
            where Device.Id = {id}");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeviceName.Text = reader[3].ToString() + reader[2].ToString();
                    DeviceArticle.Content = reader[1].ToString();
                    DeviceReleaseYear.Content = reader[2].ToString();
                }
            }
        }
    }
}
