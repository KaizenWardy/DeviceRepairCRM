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
                    uc.deviceFrame = this;
                    uc.Id = Convert.ToInt32(reader[0]);
                    uc.DeviceManufacture.Content = reader[3];
                    uc.DeviceArticle.Content = reader[1];
                    uc.DeviceModel.Content = reader[2];
                    
                    DeviceList.Children.Add(uc);
                }
            }

            
        }
        public void DeviceOptionLoad(int id)
        {
            DevicePartList.Children.Clear();
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
                    DeviceName.Text = reader[3].ToString() +  " " + reader[1].ToString();
                    DeviceArticle.Content = reader[0].ToString();
                    DeviceReleaseYear.Content = reader[2].ToString();
                }
            }
            SqlDataReader reader1 = new Connect().SqlSelect($@"
                SELECT TOP (1000)
                Part.Id AS Id,
                Part.Name AS Part,
                Part.Quantity AS Quantity,
                Part.Description AS Descriptoin

                FROM [RepairShop].[dbo].[PartOfDevice]
                INNER JOIN
                Device ON DeviceId = Device.Id
                INNER JOIN
                Part ON PartId = Part.Id

                WHERE
                Device.Id = {id}");
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    UserControls.DeviceFramePartsUC uc = new UserControls.DeviceFramePartsUC();
                    uc.id = Convert.ToInt32(reader1[0]);
                    uc.deviceFrame = this;
                    uc.DevicePartName.Text = reader1[1].ToString();
                    uc.DevicePartQuantity.Content = reader1[2].ToString();

                    DevicePartList.Children.Add(uc);
                }
            }
        }
    }
}
