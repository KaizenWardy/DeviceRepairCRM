using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace DeviceRepairCRM
{
    public partial class DeviceFrame : Page
    {
        public DeviceFrame()
        {
            InitializeComponent();
        }

        public void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DeviceList.Children.Clear();
            SqlDataReader reader = new Connect().SqlSelect($@"SELECT
            Device.Id
            ,Device.Article
            ,Device.Model
            ,Manufacture
            FROM [RepairShop].[dbo].[Device]");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeviceFrameUC uc = new DeviceFrameUC();
                    uc.deviceFrame = this;
                    uc.Id = Convert.ToInt32(reader[0]);
                    uc.DeviceArticle.Text = reader[1].ToString();
                    uc.DeviceModel.Text = reader[2].ToString();
                    uc.DeviceManufacture.Text = reader[3].ToString();

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
                ,Manufacture
                FROM [RepairShop].[dbo].[Device]
                where Device.Id = {id}");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeviceName.Text = reader[2].ToString() + " " + reader[1].ToString();
                    DeviceArticle.Text = reader[0].ToString();
                }
            }
            SqlDataReader reader1 = new Connect().SqlSelect($@"
                SELECT TOP (1000)
                Part.Id AS Id,
                Part.Name AS Part,
                Part.Quantity AS Quantity

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
                    uc.DevicePartQuantity.Text = reader1[2].ToString();

                    DevicePartList.Children.Add(uc);
                }
            }
        }
    }
}
