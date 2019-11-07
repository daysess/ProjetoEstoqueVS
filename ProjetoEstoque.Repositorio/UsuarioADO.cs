using ProjetoEstoque.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoEstoque.Repositorio
{
    public class UsuarioADO
    {
        private ConexaoBD conexaoBD;

        public UsuarioADO()
        {
            conexaoBD = new ConexaoBD();
        }

        private string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private int Inserir(Usuario usuario)
        {
            string procedure = "pi_usuario ";
            string parametroRetorno = "@resultado";
            string senhaCript = CalculateMD5Hash(usuario.Senha1);

            SqlParameter[] ParamsEnvio = new SqlParameter[]
            {
                new SqlParameter("@nm_usuario",  usuario.NmUsuario),
                new SqlParameter("@senha1", senhaCript),
                new SqlParameter("@resultado", DBNull.Value)

            };
            
            object resultado = conexaoBD.ExecutaComandoProcedure(procedure, parametroRetorno, ParamsEnvio);

            int Valor = (int)resultado;

            return Valor;
        }

        private int Alterar(Usuario usuario)
        {

            string procedure = "pu_usuario ";
            string parametroRetorno = "@resultado";
            string senhaCript = CalculateMD5Hash(usuario.Senha1);

            SqlParameter[] ParamsEnvio = new SqlParameter[]
            {
                new SqlParameter("@id_usuario", usuario.IdUsuario),
                new SqlParameter("@senha1", senhaCript),
                new SqlParameter("@resultado", DBNull.Value)

            };

            object resultado = conexaoBD.ExecutaComandoProcedure(procedure, parametroRetorno, ParamsEnvio);

            int Valor = (int)resultado;

            return Valor;
            
        }

        public int Salvar(Usuario usuario)
        {
            int resultado = 0;

            if(usuario.IdUsuario > 0)
            {
                resultado = Alterar(usuario);
            }
            else
            {
                resultado = Inserir(usuario);
            }

            return resultado;
        }

        public void Excluir(int usuarioId)
        {
            var strQuery = "pd_usuario ";
            strQuery += string.Format("{0}", usuarioId);

            conexaoBD.ExecutaComandoText(strQuery);
                        
        }
        
        public List<Usuario> ListarTodos()
        {

            List<Usuario> usuarios = new List<Usuario>();

            var strQuery = "ps_usuario ";
            SqlDataReader lista = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (lista.Read())
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = int.Parse(lista["id_usuario"].ToString());
                usuario.NmUsuario = lista["nm_usuario"].ToString();
                //usuario.Senha1 = lista["senha1"].ToString();
                //usuario.Senha2 = lista["senha2"].ToString();
                //usuario.Senha3 = lista["senha3"].ToString();
                usuario.DtCadastro = DateTime.Parse(lista["dt_cadastro"].ToString());

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public Usuario ListarPorId(int idUsuario)
        {
            Usuario usuario = new Usuario();

            var strQuery = "ps_usuarioPorId ";
            strQuery += string.Format("{0}", idUsuario);
            SqlDataReader dadosUsuario = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (dadosUsuario.Read())
            {
                usuario.IdUsuario = int.Parse(dadosUsuario["id_usuario"].ToString());
                usuario.NmUsuario = dadosUsuario["nm_usuario"].ToString();
                //usuario.Senha1 = dadosUsuario["senha1"].ToString();
                //usuario.Senha2 = dadosUsuario["senha2"].ToString();
                //usuario.Senha3 = dadosUsuario["senha3"].ToString();
                usuario.DtCadastro = DateTime.Parse(dadosUsuario["dt_cadastro"].ToString());

            }

            return usuario;
        }

        public Usuario AutenticarUsuario(string nmUsuario, string senha)
        {
            Usuario usuario = new Usuario();

            var strQuery = "ps_autenticarUsuario ";
            strQuery += string.Format("{0},'{1}'", nmUsuario, CalculateMD5Hash(senha));
            SqlDataReader dadosUsuario = conexaoBD.ExecutaComandoComRetorno(strQuery);

            while (dadosUsuario.Read())
            {
                usuario.IdUsuario = int.Parse(dadosUsuario["id_usuario"].ToString());
                usuario.NmUsuario = dadosUsuario["nm_usuario"].ToString();

            }

            return usuario;

        }


    }
}
