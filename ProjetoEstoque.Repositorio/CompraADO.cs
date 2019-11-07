using ProjetoEstoque.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoEstoque.Repositorio
{
    public class CompraADO
    {

        ConexaoBD conexaoBD;

        public CompraADO()
        {
            conexaoBD = new ConexaoBD();
        }

        private void Inserir(Compra compra)
        {
            string procedure = "pi_compra";

            SqlParameter[] ParamsEnvio = new SqlParameter[]
            {
                new SqlParameter("@id_produto",  compra.IdProduto),
                new SqlParameter("@id_embalagem_compra", compra.IdEmbalagemCompra),
                new SqlParameter("@id_embalagem_estoque", compra.IdEmbalagemEstoque),
                new SqlParameter("@qtd_unidade_compra", compra.QtdUnidadeCompra),
                new SqlParameter("@vl_unidade_compra", compra.VlUnidadeCompra),
                new SqlParameter("@vl_total_compra", compra.VlTotalCompra),
                new SqlParameter("@baselucro", compra.VlBaseLucro),
                new SqlParameter("@dt_compra", compra.DtCompra),
                new SqlParameter("@dt_validade", compra.DtValidade),
                new SqlParameter("@id_usuario", compra.IdUsuario)

            };

            object resultado = conexaoBD.ExecutaComandoProcedure(procedure, null, ParamsEnvio);


        }

        private void Alterar(Compra compra)
        {
            string procedure = "pu_compra";

            SqlParameter[] ParamsEnvio = new SqlParameter[]
            {
                new SqlParameter("@id_compra", compra.IdCompra),
                new SqlParameter("@id_produto", compra.IdProduto),
                new SqlParameter("@id_embalagem_compra", compra.IdEmbalagemCompra),
                new SqlParameter("@id_embalagem_estoque", compra.IdEmbalagemEstoque),
                new SqlParameter("@qtd_unidade_compra", compra.QtdUnidadeCompra),
                new SqlParameter("@vl_unidade_compra", compra.VlUnidadeCompra),
                new SqlParameter("@vl_total_compra", compra.VlTotalCompra),
                new SqlParameter("@baselucro", compra.VlBaseLucro),
                new SqlParameter("@dt_compra", compra.DtCompra),
                new SqlParameter("@dt_validade", compra.DtValidade)
            };

            object resultado = conexaoBD.ExecutaComandoProcedure(procedure, null, ParamsEnvio);


        }

        public void Salvar(Compra compra)
        {
            if (compra.IdCompra > 0)
            {
                Alterar(compra);
            }
            else
            {
                Inserir(compra);
            }
            
        }

        public void Excluir(int idCompra)
        {
            var strQuery = "pd_compra ";
            strQuery += string.Format("{0}", idCompra);

            conexaoBD.ExecutaComandoText(strQuery);

        }

        public List<Compra> ListarTodos()
        {
            List<Compra> compras = new List<Compra>();

            var strQuery = "ps_compra ";
            SqlDataReader lista = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (lista.Read())
            {
                Compra compra = new Compra();

                compra.IdCompra = int.Parse(lista["id_compra"].ToString());
                compra.IdProduto = int.Parse(lista["id_produto"].ToString());
                compra.NmProduto = lista["nm_produto"].ToString();
                compra.IdEmbalagemCompra = int.Parse(lista["id_embalagem_compra"].ToString());
                compra.NmEmbalagemCompra = lista["nm_embalagem_compra"].ToString();
                compra.IdEmbalagemEstoque = int.Parse(lista["id_embalagem_estoque"].ToString());
                compra.NmEmbalagemEstoque = lista["nm_embalagem_estoque"].ToString();
                compra.QtdUnidadeCompra = int.Parse(lista["qtd_unidade_compra"].ToString());
                compra.VlUnidadeCompra = double.Parse(lista["vl_unidade_compra"].ToString());
                compra.VlTotalCompra = double.Parse(lista["vl_total_compra"].ToString());
                compra.VlBaseLucro = double.Parse(lista["baselucro"].ToString());
                compra.DtCompra = DateTime.Parse(lista["dt_compra"].ToString());
                compra.DtValidade = DateTime.Parse(lista["dt_validade"].ToString());

                compras.Add(compra);

            }

            return compras;
        }

        public Compra ListarPorId(int idCompra)
        {
            Compra compra = new Compra();

            var strQuery = "ps_compraPorId ";
            strQuery += string.Format("{0}", idCompra);
            SqlDataReader lista = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (lista.Read())
            {

                compra.IdCompra = int.Parse(lista["id_compra"].ToString());
                compra.IdProduto = int.Parse(lista["id_produto"].ToString());
                compra.NmProduto = lista["nm_produto"].ToString();
                compra.IdEmbalagemCompra = int.Parse(lista["id_embalagem_compra"].ToString());
                compra.NmEmbalagemCompra = lista["nm_embalagem_compra"].ToString();
                compra.IdEmbalagemEstoque = int.Parse(lista["id_embalagem_estoque"].ToString());
                compra.NmEmbalagemEstoque = lista["nm_embalagem_estoque"].ToString();
                compra.QtdUnidadeCompra = int.Parse(lista["qtd_unidade_compra"].ToString());
                compra.VlUnidadeCompra = double.Parse(lista["vl_unidade_compra"].ToString());
                compra.VlTotalCompra = double.Parse(lista["vl_total_compra"].ToString());
                compra.VlBaseLucro = double.Parse(lista["baselucro"].ToString());
                compra.DtCompra = DateTime.Parse(lista["dt_compra"].ToString());
                compra.DtValidade = DateTime.Parse(lista["dt_validade"].ToString());

                break;
            }

            return compra;
        }

    }
}
