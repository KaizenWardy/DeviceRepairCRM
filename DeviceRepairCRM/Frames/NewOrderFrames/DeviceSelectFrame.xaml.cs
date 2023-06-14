using DeviceRepairCRM.UserControls;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace DeviceRepairCRM.Frames.NewOrderFrames
{
    public partial class DeviceSelectFrame : Page
    {
        public int id;
        public NewOrderWindow window;
        public DeviceSelectFrame()
        {
            InitializeComponent();
        }

        private void DeviceMNf_TextChanged(object sender, TextChangedEventArgs e)
        {
            Grid_Loaded(sender, e);
        }

        private void ClearDeviceNameBt_Click(object sender, RoutedEventArgs e)
        {
            DeviceMNf.Text = string.Empty;
            DeviceMdl.Text = string.Empty;
            DeviceArt.Text = string.Empty;
            
            id = 0;
        }

        private void NextBt_Click(object sender, RoutedEventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Выберите девайс!");
            }
            else
            {
                NewOrderInfoFrame frame = new NewOrderInfoFrame();
                frame.window = window;
                window.NewOrderFrame.Content = frame;
                window.DeviceId = id;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DeviceNameList.Children.Clear();
            SqlDataReader reader = new Connect().SqlSelect($@"
                SELECT Device.[Id]
                      ,[DeviceManufacture].Name as MName
                      ,[Article]
                      ,[Model]
                  FROM [RepairShop].[dbo].[Device]
                    inner join [DeviceManufacture] on
                    [DeviceManufacture].id = [Device].Manufacture
  
                  WHERE [DeviceManufacture].Name like '%{DeviceMNf.Text}%' 
                  and Article like '%{DeviceArt.Text}%'
                  and Model like '%{DeviceMdl.Text}%'");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DeviceSelectUC DeviceUC = new DeviceSelectUC(); //создаем пользов эл управления
                    DeviceUC.id = (int)reader[0]; // Запоминаем его Id
                    DeviceUC.UCDeviceMnf.Text = reader[1].ToString();
                    DeviceUC.UCDeviceMdl.Text = reader[2].ToString();
                    DeviceUC.UCDeviceArt.Text = reader[3].ToString();
                    DeviceUC.Frame = this;
                    DeviceNameList.Children.Add(DeviceUC); // Добавляем на экран
                }
            }
        }

        private void NewDeviceBt_Click(object sender, RoutedEventArgs e)
        {
            if (DeviceMNf.Text == "")
            {
                if (DeviceMdl.Text == "")
                {
                    if (DeviceArt.Text == "")
                    {
                        MessageBox.Show("Пустое поле!");
                    }
                }
            }
            else
            {
                new Connect().SqlEditAddDel($@"
                    INSERT INTO [dbo].[Device]
                               ([Manufacture]
                               ,[Article]
                               ,[Model])
                         VALUES
                               ('{DeviceMNf.Text}'
                               ,'{DeviceArt.Text}'
                               ,'{DeviceMdl.Text}')");
                ClearDeviceNameBt_Click(sender, e);
                Grid_Loaded(sender, e);
            }
        }
    }
}
