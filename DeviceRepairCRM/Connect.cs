using System.Data.SqlClient;

namespace DeviceRepairCRM
{
    class Connect
    {
        public SqlConnection Connection = new SqlConnection(@"
            Data Source = WIN-FAHF3C7J7BR\SQLEXPRESS01;
            Initial Catalog = RepairShop;
            Integrated Security = true;");
        public SqlDataReader SqlSelect(string command)
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(command, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public int SqlEditAddDel(string command)
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand(command, Connection);
            int a = cmd.ExecuteNonQuery();
            return a;
        }
    }
}