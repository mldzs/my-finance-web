using System;
using System.Collections.Generic;
using myfinanceweb_dotnet.Infra;
using myfinanceweb_dotnet.Models;

namespace myfinanceweb_dotnet.Domain
{
    public class Transacao
    {

        public void Inserir(TransacaoModel formulario)
        {
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = "INSERT INTO TRANSACAO( DATA, VALOR, TIPO, DESCRICAO, ID_PLANO_CONTA) " +
            "VALUES ( " +
            $"'{formulario.Data.ToString("yyyy-MM-dd")}'," +
            $"{formulario.Valor}," +
            $"'{formulario.Tipo}'," +
            $"'{formulario.Descricao}'," +
            $"{formulario.IdPlanoConta}" +
            ")";

            objDAL.ExecuteSqlCommand(sql);
            objDAL.Disconnect();

        }
        public void Atualizar(TransacaoModel formulario)
        {
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = "UPDATE TRANSACAO SET " +
            $"Data = '{formulario.Data.ToString("yyyy-MM-dd")}'," +
            $"Valor = {formulario.Valor}," +
            $"Tipo = '{formulario.Tipo}'," +
            $"Descricao = '{formulario.Descricao}'," +
            $"ID_PLANO_CONTA = {formulario.IdPlanoConta} " +
            $"WHERE ID = {formulario.Id}";

            objDAL.ExecuteSqlCommand(sql);
            objDAL.Disconnect();
        }

        public void Excluir(int id)
        {
            var objDAL = DAL.GetInstance;
            objDAL.Connect();
            var sql = $"DELETE FROM TRANSACAO WHERE ID = {id}";
            objDAL.ExecuteSqlCommand(sql);
            objDAL.Disconnect();
        }
        public List<TransacaoModel> ListaTransacoes()
        {
            List<TransacaoModel> list = new List<TransacaoModel>();
            var objDAL = DAL.GetInstance;
            objDAL.Connect();

            var sql = "SELECT ID, DATA, VALOR, TIPO, DESCRICAO, ID_PLANO_CONTA FROM transacao order by ID desc";
            var dataTable = objDAL.ReturnDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var transacao = new TransacaoModel()
                {
                    Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                    Data = DateTime.Parse(dataTable.Rows[i]["DATA"].ToString()),
                    Valor = decimal.Parse(dataTable.Rows[i]["VALOR"].ToString()),
                    Tipo = dataTable.Rows[i]["TIPO"].ToString(),
                    Descricao = dataTable.Rows[i]["DESCRICAO"].ToString(),
                    IdPlanoConta = int.Parse(dataTable.Rows[i]["ID_PLANO_CONTA"].ToString()),
                };

                list.Add(transacao);
            }
            objDAL.Disconnect();
            return list;
        }
        public TransacaoModel CarregarTransacaoPorId(int? id)
        {
            var objDAL = DAL.GetInstance;
            objDAL.Connect();

            var sql = $"SELECT ID, DATA, VALOR, TIPO, DESCRICAO, ID_PLANO_CONTA FROM transacao WHERE ID ={id}";
            var dataTable = objDAL.ReturnDataTable(sql);

            var transacao = new TransacaoModel()
            {
                Id = int.Parse(dataTable.Rows[0]["ID"].ToString()),
                Descricao = dataTable.Rows[0]["DESCRICAO"].ToString(),
                Tipo = dataTable.Rows[0]["TIPO"].ToString(),
                Data = DateTime.Parse(dataTable.Rows[0]["DATA"].ToString()),
                Valor = decimal.Parse(dataTable.Rows[0]["VALOR"].ToString()),
                IdPlanoConta = int.Parse(dataTable.Rows[0]["ID_PLANO_CONTA"].ToString()),
            };
            objDAL.Disconnect();
            return transacao;
        }
    }
}
