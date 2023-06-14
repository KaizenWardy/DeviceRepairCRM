using DeviceRepairCRM.UserControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeviceRepairCRM.Frames.NewOrderFrames
{
    public partial class ClientFrame : Page
    {
        public ClientFrame()
        {
            InitializeComponent();
        }
        public int id;
        public NewOrderWindow window;

        private void ClientName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Grid_Loaded(sender, e);
            NewClient_Button_border.Visibility = Visibility.Visible;
        }
        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ClearClientName_Click(object sender, RoutedEventArgs e)
        {
            ClearClientNameBorder.Visibility = Visibility.Hidden;
            NextBtBorder.Visibility = Visibility.Hidden;
            id = 0;

            FName.Text = "";
            SName.Text = "";
            Phone.Text = "";
        }

        private void NewClient_Button_Click(object sender, RoutedEventArgs e)
        {
            if (FName.Text != null)
            {
                if (SName.Text != null)
                {
                    if (Phone.Text != null)
                    {
                        new Connect().SqlEditAddDel($@"
                            INSERT INTO [dbo].[Client]
                                       ([Firstname]
                                       ,[SecondName]
                                       ,[PhoneNumber])
                                 VALUES
                                       ('{FName.Text}'
                                       ,'{SName.Text}'
                                       ,'{Phone.Text}')");
                        ClearClientName_Click(sender, e);
                        Grid_Loaded(sender, e);
                    }
                    else MessageBox.Show("Пустое поле!");
                }
                else MessageBox.Show("Пустое поле!");
            }
            else MessageBox.Show("Пустое поле!");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ClientNameList.Children.Clear();
            SqlDataReader reader = new Connect().SqlSelect($@"
                SELECT [Id]
                      ,[Firstname]
                      ,[SecondName]
                      ,[PhoneNumber]
                  FROM [RepairShop].[dbo].[Client]
  
                  WHERE Firstname like '%{FName.Text}%' 
                  and SecondName like '%{SName.Text}%'
                  and PhoneNumber like '%{Phone.Text}%'
                ");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NewOrderClientUC ClientUC = new NewOrderClientUC(); //создаем пользов эл управления
                    ClientUC.id = (int)reader[0]; // Запоминаем его Id
                    ClientUC.UCClientFName.Text = reader[1].ToString();
                    ClientUC.UCClientSName.Text = reader[2].ToString();
                    ClientUC.UCClientPhone.Text = reader[3].ToString();
                    ClientUC.Frame = this;
                    ClientNameList.Children.Add(ClientUC); // Добавляем на экран
                }
            }
        }

        private void NextBt_Click(object sender, RoutedEventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Клиент не выбран!");
            }
            else
            {
                DeviceSelectFrame frame = new DeviceSelectFrame();
                frame.window = window;
                window.NewOrderFrame.Content = frame;
                window.ClientId = id;
            }
        }
    }
}
