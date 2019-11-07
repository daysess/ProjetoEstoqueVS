using ProjetoEstoque.Dominio;
using ProjetoEstoque.Repositorio;
using System.Collections.Generic;

namespace ProjetoEstoque.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly UsuarioADO usuarioADO;
        private static readonly object HttpContext;

        public UsuarioAplicacao()
        {
            usuarioADO = new UsuarioADO();
        }

        public int Salvar(Usuario usuario)
        {
            return usuarioADO.Salvar(usuario);
        }

        public void Excluir(int usuarioId)
        {
            usuarioADO.Excluir(usuarioId);
        }

        public List<Usuario> ListarTodos()
        {
            return usuarioADO.ListarTodos();
        }


        public Usuario ListarPorId(int id)
        {

            return usuarioADO.ListarPorId(id);
        }

        public string AutenticarExistenciaUsuario(string nmUsuario, string senha)
        {
            Usuario existe = usuarioADO.AutenticarUsuario(nmUsuario, senha);
            string usuarioExistente = "";

            if(existe.IdUsuario > 0)
            {
                usuarioExistente = "OK";
            }

            return usuarioExistente;

        }
        

    }
}
