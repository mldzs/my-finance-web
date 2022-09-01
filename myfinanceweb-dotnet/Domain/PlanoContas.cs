using myfinance_web_netcore.Infra;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain
{
    public class PlanoConta
    {

        public void Insert(PlanoContaModel formulario)
        {
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO) VALUES('{formulario.Descricao}','{formulario.Tipo}')";
            objDAL.ExecuteSqlCommand(sql);
            objDAL.Disconnect();
        }
        public void Atualizar(PlanoContaModel formulario)
        {
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = $"UPDATE PLANO_CONTAS SET " +
                        $"Descricao = '{formulario.Descricao}', " +
                        $"Tipo = '{formulario.Tipo}' " +
                        $"WHERE id = '{formulario.Id}'";

            objDAL.ExecuteSqlCommand(sql);
            objDAL.Disconnect();
        }

        public void Excluir(int id)
        {
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = $"DELETE FROM PLANO_CONTAS WHERE ID = {id}";
            objDAL.ExecuteSqlCommand(sql);
            objDAL.Disconnect();
        }

        public List<PlanoContaModel> ListaPlanoContas()
        {
            List<PlanoContaModel> list = new List<PlanoContaModel>();
            var objDAL = DAL.GetInstance;
            objDAL.Connect();

            var sql = "SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS";
            var dataTable = objDAL.ReturnDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var planoConta = new PlanoContaModel()
                {
                    Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                    Descricao = dataTable.Rows[i]["DESCRICAO"].ToString(),
                    Tipo = dataTable.Rows[i]["TIPO"].ToString()
                };

                list.Add(planoConta);
            }
            objDAL.Disconnect();
            return list;
        }
        public PlanoContaModel CarregarPlanoContaPorId(int? id)
        {

            var objDAL = DAL.GetInstance;
            objDAL.Connect();

            var sql = $"SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS WHERE ID = {id};";
            var dataTable = objDAL.ReturnDataTable(sql);

            var planoConta = new PlanoContaModel()
            {
                Id = int.Parse(dataTable.Rows[0]["ID"].ToString()),
                Descricao = dataTable.Rows[0]["DESCRICAO"].ToString(),
                Tipo = dataTable.Rows[0]["TIPO"].ToString()
            };

            objDAL.Disconnect();
            return planoConta;
        }
    }
}