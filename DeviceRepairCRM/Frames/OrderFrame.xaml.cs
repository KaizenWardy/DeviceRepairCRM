using System.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DeviceRepairCRM
{
    public partial class OrderFrame : Page
    {
        public OrderFrame()
        {
            InitializeComponent();
        }

        public void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            OrderPageStackPanel.Children.Clear();
            SqlDataReader reader = new Connect().SqlSelect($@"
        SELECT TOP (1000) 
        [Order].[Id] as id

               ,[Device].[Id] as DeviceId
              ,[Device].[Manufacture] as Manufacture
        	  ,[Device].[Model] as Model
        	  ,[Device].[Article] as Art

        	  ,[Client].[Id] as ClientId
        	  ,[Client].[FirstName] as FName
        	  ,[Client].[SecondName] as SName
        	  ,[Client].[PhoneNumber] as PhoneNumber

              ,[Description]
              ,[Price]
              ,[Status]
              ,[StartDate]
              ,[EndDate]
              ,[DeviceManufacture].[Name] as ManufName
                ,[DeviceType].Name as DeviceType

          FROM [RepairShop].[dbo].[Order]
          inner join [Device] on
          [Device].[Id] = [Order].[Device]
          inner join [Client] on
          [Client].[Id] = [Order].[Client]
          inner join [DeviceManufacture] on
          [DeviceManufacture].[Id] = [Device].[Manufacture]
          inner join [DeviceType] on
          [DeviceType].Id = [Device].DeviceType {SearchText} Order by [StartDate] DESC ");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    OrderFrameUC uc = new OrderFrameUC();
                    uc.OrderId = Convert.ToInt32(reader[0]);

                    uc.DeviceId = Convert.ToInt32(reader[1]);
                    uc.OrderDeviceType.Text = reader[15].ToString();
                    uc.OrderDeviceManuf.Text = reader[14].ToString();
                    uc.OrderDeviceModel.Text = reader[3].ToString();
                    uc.OrderDeviceArt.Text = reader[4].ToString();

                    uc.Clientid = Convert.ToInt32(reader[5]);
                    uc.OrderClient.Text = reader[6].ToString();
                    uc.OrderClient.Text = uc.OrderClient.Text + " " + reader[7].ToString();
                    uc.OrderClientPhone.Text = reader[8].ToString();

                    uc.OrderInfo.Text = reader[9].ToString();
                    uc.OrderPrice.Text = reader[10].ToString() + " Рублей";
                    uc.OrderStatusInt = Convert.ToInt32(reader[11]);
                    if (!(reader[12] is DBNull))
                    {
                        uc.OrderStartDate.Text = Convert.ToDateTime(reader[12]).ToString();
                    }
                    if (!(reader[13] is DBNull))
                    {
                        uc.OrderEndDate.Text = Convert.ToDateTime(reader[13]).ToString();
                    }
                    uc.OrderFrame = this;
                    OrderPageStackPanel.Children.Add(uc);
                }
            }
            DeviceTypeComboBox.Items.Clear();
            SqlDataReader reader2 = new Connect().SqlSelect($@"
SELECT TOP (1000) [Id]
      ,[Name]
  FROM [RepairShop].[dbo].[DeviceType]");
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    DeviceTypeComboBox.Items.Add(reader2.GetString(1));
                }
            }
        }
        string SearchText;
        private void OrderSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchText = $@"where [Device] like '%{OrderSearchTextBox.Text}%'
                  or [Description] like '%{OrderSearchTextBox.Text}%'
                  or [Price] like '%{OrderSearchTextBox.Text}%'
                  or [Client].FirstName like '%{OrderSearchTextBox.Text}%'
                  or [Client].SecondName like '%{OrderSearchTextBox.Text}%'
                  or [Client].PhoneNumber like '%{OrderSearchTextBox.Text}%'";
            Grid_Loaded(sender, e);
        }
    }
}
