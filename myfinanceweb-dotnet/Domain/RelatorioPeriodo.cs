using System.Globalization;
using myfinanceweb_dotnet.Infra;

namespace myfinanceweb_dotnet.Domain
{
    public class RelatorioPeriodo
    {
        public List<string> ListaRelatorios(string inicio, string fim)
        {
            List<string> list = new List<string>();
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = $"SELECT(SELECT COALESCE(sum(VALOR), 0) from transacao t where t.TIPO = 'D' and [DATA] >= '{inicio}' and [DATA] <= '{fim}' ) as sum_despesas,(SELECT COALESCE(sum(VALOR), 0) from transacao t where t.TIPO = 'R' and[DATA] >= '{inicio}' and[DATA] <= '{fim}') as sum_receita";

            var dataTable = objDAL.ReturnDataTable(sql);

            list.Add(Convert.ToString(dataTable.Rows[0]["sum_despesas"], CultureInfo.InvariantCulture));
            list.Add(Convert.ToString(dataTable.Rows[0]["sum_receita"], CultureInfo.InvariantCulture));

            objDAL.Disconnect();
            return list;
        }
    }
}
