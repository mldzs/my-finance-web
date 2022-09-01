using System.Data.SqlClient;

namespace myfinanceweb_dotnet.Infra
{
    public class DAL
    {
        private SqlConnection conn;
        private string connectionString;
        public static IConfiguration Configuration;
        private static DAL Instancia;

        public static DAL GetInstancia()
        {
            get{
                if (Instancia == null)
                {
                    Instancia = new();
                }

                return Instancia;
            }
        }

        public DAL()
        {
            connectionString = Configuration.GetValue<string>("ConnectionString");
        }

        public void Conectar()
        {
            conn = new();
            conn.ConnectionString = connectionString;
            conn.Open();
        }
    }
}
