using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Domain
{
    public class RelatorioPeriodo
    {
        public List<decimal> ListaRelatorios(string inicio, string fim)
        {
            List<decimal> list = new List<decimal>();
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = $"SELECT(SELECT COALESCE(sum(VALOR), 0) from transacao t where t.TIPO = 'D' and [DATA] >= '{inicio}' and [DATA] <= '{fim}' ) as sum_despesas,(SELECT COALESCE(sum(VALOR), 0) from transacao t where t.TIPO = 'R' and[DATA] >= '{inicio}' and[DATA] <= '{fim}') as sum_receita";

            var dataTable = objDAL.ReturnDataTable(sql);

            list.Add((decimal)dataTable.Rows[0]["sum_despesas"]);
            list.Add((decimal)dataTable.Rows[0]["sum_receita"]);

            objDAL.Disconnect();
            return list;
        }
    }
}