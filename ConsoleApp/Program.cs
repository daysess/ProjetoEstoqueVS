using System;
using System.Data.SqlClient;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection conexao = new SqlConnection(@"data source=DAYSE ; Integrated Security=SSPI ; Initial Catalog=bdestoque");
            conexao.Open();

            string strQuerySelect = "Select * From tb_usuario";
            SqlCommand cmdCommandSelect = new SqlCommand(strQuerySelect, conexao);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();

            while (dados.Read())
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Senha:{2}", dados["id_usuario"], dados["nm_usuario"], dados["senha1"]);
            }

        }
    }
}
