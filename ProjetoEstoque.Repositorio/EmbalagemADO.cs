using ProjetoEstoque.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoEstoque.Repositorio
{
    public class EmbalagemADO
    {

        ConexaoBD conexaoBD;

        public EmbalagemADO()
        {
            conexaoBD = new ConexaoBD();
        }

        private void Inserir(Embalagem embalagem)
        {
            var strQuery = "pi_embalagem ";
            strQuery += string.Format("'{0}', '{1}'", embalagem.NmEmbalagem, embalagem.QtdUnidade);

            conexaoBD.ExecutaComandoText(strQuery);

        }

        private void Alterar(Embalagem embalagem)
        {
            var strQuery = "pu_embalagem ";
            strQuery += string.Format("{0}, '{1}', '{2}'", embalagem.IdEmbalagem, embalagem.NmEmbalagem, embalagem.QtdUnidade);

            conexaoBD.ExecutaComandoText(strQuery);

        }

        public void Salvar(Embalagem embalagem)
        {
            if (embalagem.IdEmbalagem > 0)
            {
                Alterar(embalagem);
            }
            else
            {
                Inserir(embalagem);
            }
        }

        public void Excluir(int idEmbalagem)
        {
            var strQuery = "pd_embalagem ";
            strQuery += string.Format("{0}", idEmbalagem);

            conexaoBD.ExecutaComandoText(strQuery);

        }

        public List<Embalagem> ListarTodos()
        {
            List<Embalagem> embalagens = new List<Embalagem>();

            var strQuery = "ps_embalagem ";
            SqlDataReader lista = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (lista.Read())
            {
                Embalagem embalagem = new Embalagem();

                embalagem.IdEmbalagem = int.Parse(lista["id_embalagem"].ToString());
                embalagem.NmEmbalagem = lista["nm_embalagem"].ToString();
                embalagem.DsEmbalagem = lista["ds_embalagem"].ToString();
                embalagem.QtdUnidade = int.Parse(lista["qtd_unidade"].ToString());

                embalagens.Add(embalagem);
            }

            return embalagens;
        }

        public Embalagem ListarPorId(int idEmbalagem)
        {
            Embalagem embalagem = new Embalagem();

            var strQuery = "ps_embalagemPorId ";
            strQuery += string.Format("{0}", idEmbalagem);
            SqlDataReader lista = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (lista.Read())
            {
                embalagem.IdEmbalagem = int.Parse(lista["id_embalagem"].ToString());
                embalagem.NmEmbalagem = lista["nm_embalagem"].ToString();
                embalagem.QtdUnidade = int.Parse(lista["qtd_unidade"].ToString());

                break;
            }

            return embalagem;
        }
    }
}
