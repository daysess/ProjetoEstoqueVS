using ProjetoEstoque.Dominio;
using ProjetoEstoque.Repositorio;
using System.Collections.Generic;

namespace ProjetoEstoque.Aplicacao
{
    public class ProdutoAplicacao
    {

        private readonly ProdutoADO produtoADO;

        public ProdutoAplicacao()
        {
            produtoADO = new ProdutoADO();
        }


        public void Salvar(Produto produto)
        {
            produtoADO.Salvar(produto);
        }

        public void Excluir(int idProduto)
        {
            produtoADO.Excluir(idProduto);
        }

        public List<Produto> ListarTodos()
        {
            List<Produto> lista = new List<Produto>();

            lista = produtoADO.ListarTodos();

            return lista;
        }

        public Produto ListarPorId(int idProduto)
        {
            return produtoADO.ListarPorId(idProduto);
        }
    }
}
