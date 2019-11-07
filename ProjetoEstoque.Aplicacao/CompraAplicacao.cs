using ProjetoEstoque.Dominio;
using ProjetoEstoque.Repositorio;
using System.Collections.Generic;

namespace ProjetoEstoque.Aplicacao
{
    public class CompraAplicacao
    {

        private readonly CompraADO compraADO;

        public CompraAplicacao()
        {
            compraADO = new CompraADO();
        }


        public void Salvar(Compra compra)
        {
            compraADO.Salvar(compra);
        }

        public void Excluir(int idEmbalagem)
        {
            compraADO.Excluir(idEmbalagem);
        }

        public List<Compra> ListarTodos()
        {
            List<Compra> lista = new List<Compra>();
            lista = compraADO.ListarTodos();

            return lista;
        }

        public Compra ListarPorId(int idCompra)
        {
            return compraADO.ListarPorId(idCompra);
        }


    }
}
