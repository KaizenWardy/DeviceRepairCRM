using System.Data.SqlClient;

namespace DeviceRepairCRM
{
    class Connect
    {
        public SqlConnection Connection = new SqlConnection(@"
            DataSource = WIN-MKI4LD09KJR\SQLEXPRESS;
            Initial Catalog = RepairShop;
            Integrated Security = true;");
        public SqlDataReader SqlSelect(string command)
        {
            SqlCommand cmd = new SqlCommand(command, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public int SqlEditAddDel(string command)
        {
            SqlCommand cmd = new SqlCommand(command, Connection);
            int a = cmd.ExecuteNonQuery();
            return a;
        }
    }
}