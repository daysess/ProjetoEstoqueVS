using ProjetoEstoque.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoEstoque.Repositorio
{
    public class ProdutoADO
    {

        private ConexaoBD conexaoBD;

        public ProdutoADO()
        {
            conexaoBD = new ConexaoBD();
        }

        private void Inserir(Produto produto)
        {
            var strQuery = "pi_produto ";
            strQuery += string.Format("'{0}', '{1}'", produto.NmProduto, produto.DsProduto);

            conexaoBD.ExecutaComandoText(strQuery);

        }

        private void Alterar(Produto produto)
        {
            var strQuery = "pu_produto ";
            strQuery += string.Format("{0}, '{1}', '{2}'", produto.IdProduto, produto.NmProduto, produto.DsProduto);

            conexaoBD.ExecutaComandoText(strQuery);

        }

        public void Salvar(Produto produto)
        {
            if(produto.IdProduto > 0)
            {
                Alterar(produto);
            }
            else
            {
                Inserir(produto);
            }
        }

        public void Excluir(int idProduto)
        {
            var strQuery = "pd_produto ";
            strQuery += string.Format("{0}", idProduto);

            conexaoBD.ExecutaComandoText(strQuery);

        }

        public List<Produto> ListarTodos()
        {

            List<Produto> produtos = new List<Produto>();

            var strQuery = "ps_produto ";
            SqlDataReader lista = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (lista.Read())
            {
                Produto produto = new Produto();
                produto.IdProduto = int.Parse(lista["id_produto"].ToString());
                produto.NmProduto = lista["nm_produto"].ToString();
                produto.DsProduto = lista["ds_produto"].ToString();

                produtos.Add(produto);
            }

            return produtos;
        }

        public Produto ListarPorId(int idProduto)
        {
            Produto produto = new Produto();

            var strQuery = "ps_produtoPorId ";
            strQuery += string.Format("{0}", idProduto);
            SqlDataReader lista = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (lista.Read())
            {
                produto.IdProduto = int.Parse(lista["id_produto"].ToString());
                produto.NmProduto = lista["nm_produto"].ToString();
                produto.DsProduto = lista["ds_produto"].ToString();

                break;
            }

            return produto;
        }

    }
}
