using System.Data.SqlClient;
using System.Data;

namespace myfinance_web_netcore.Infra
{
    public class DAL
    {
        private SqlConnection conn;
        private string connectionString;
        public static IConfiguration? Configuration;
        private static DAL? Instance;

        public static DAL GetInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new();
                return Instance;
            }
        }

        private DAL()
        {
            connectionString = Configuration.GetValue<string>("ConnectionString");
        }

        public void Connect()
        {
            conn = new();
            conn.ConnectionString = connectionString;
            conn.Open();
        }

        public void Disconnect()
        {
            conn.Close();
        }

        public DataTable ReturnDataTable(string sql)
        {
            var dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public void ExecuteSqlCommand(string sql)
        {
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
        }
    }

}
