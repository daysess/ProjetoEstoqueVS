using ProjetoEstoque.Dominio;
using ProjetoEstoque.Repositorio;
using System.Collections.Generic;

namespace ProjetoEstoque.Aplicacao
{
    public class EmbalagemAplicacao
    {

        private readonly EmbalagemADO embalagemADO;

        public EmbalagemAplicacao()
        {
            embalagemADO = new EmbalagemADO();
        }


        public void Salvar(Embalagem embalagem)
        {
            embalagemADO.Salvar(embalagem);
        }

        public void Excluir(int idEmbalagem)
        {
            embalagemADO.Excluir(idEmbalagem);
        }

        public List<Embalagem> ListarTodos()
        {
            List<Embalagem> lista = new List<Embalagem>();
            lista = embalagemADO.ListarTodos();

            return lista;
        }

        public Embalagem ListarPorId(int idEmbalagem)
        {
            return embalagemADO.ListarPorId(idEmbalagem);
        }

    }
}
