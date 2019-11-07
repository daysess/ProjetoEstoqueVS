using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ProjetoEstoque.Dominio;

namespace ProjetoEstoque.Repositorio
{
    public class ConexaoBD
    {
        private readonly SqlConnection conexao;

        public ConexaoBD()
        {
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoBD_SqlServer"].ConnectionString);
            conexao.Open();
        }


        public void ExecutaComandoText(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };

            cmdComando.ExecuteNonQuery();

        }

        public object ExecutaComandoProcedure(string procedure, string parametroRetorno, SqlParameter[] ParamsEnvio)
        {
            var cmdComando = new SqlCommand();
            cmdComando.Connection = conexao;
            cmdComando.CommandText = procedure;
            cmdComando.CommandType = CommandType.StoredProcedure;
            cmdComando.Parameters.AddRange(ParamsEnvio);

            SqlParameter retornaParametro = new SqlParameter();
            if (!string.IsNullOrEmpty(parametroRetorno))
            {
                retornaParametro = cmdComando.Parameters.Add(parametroRetorno, SqlDbType.Int);
                retornaParametro.Direction = ParameterDirection.ReturnValue;
            }
            
            cmdComando.ExecuteNonQuery();

            return retornaParametro.Value;

        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComandoSelect = new SqlCommand(strQuery, conexao);
            return cmdComandoSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }


        }




    }
}
