using ProjetoEstoque.Aplicacao;
using ProjetoEstoque.Dominio;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {

        TipoMensagem tipoMsg = new TipoMensagem();
        UsuarioAplicacao App = new UsuarioAplicacao();

        public ActionResult PortalUsuario()
        {
            return View();
        }

        public ActionResult ListaUsuarios(string nmUsuario)
        {
            
            var lista = App.ListarTodos();

            if(Session["NmUsuarioLogado"] != null)
            {
                foreach(Usuario item in lista)
                {
                    //----
                }
            }

            if (nmUsuario != null)
            {
                MensagemShow("Cadastro realizado com sucesso", tipoMsg.Success);
                return View(lista.FindAll(x => x.NmUsuario == nmUsuario));
            }
            else
            {
                return View(lista);
            }

            
        }

        public ActionResult Excluir(int idUsuario)
        {
            App.Excluir(idUsuario);
            return RedirectToAction("ListaUsuarios");
        }

        public ActionResult Editar(int idUsuario)
        {
            Usuario usuario = new Usuario();
            usuario = App.ListarPorId(idUsuario);
            
            return View(usuario);
        }
        
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (usuario.Senha1 != usuario.ConfirmarSenha)
            {
                ModelState.AddModelError("", "As senhas não se coincidem!");
            }
            else
            {
                UsuarioAplicacao AppUsuario = new UsuarioAplicacao();
                int retornoExecucao = AppUsuario.Salvar(usuario);

                if (retornoExecucao == 1)
                {
                    ModelState.AddModelError("", "O nome do usuário informado já existe em nosso sistema. Tente com outro nome.");
                } else if (retornoExecucao == 2)
                {
                    ModelState.AddModelError("", "A senha informada já foi utilizada nas últimas 3 alterações. Favor informa outra senha.");
                }
                else
                {
                    return RedirectToAction("ListaUsuarios", new { nmUsuario = usuario.NmUsuario });
                }

            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult PortalUsuario(Usuario usuario)
        {

            if(usuario.Senha1 != usuario.ConfirmarSenha)
            {
                ModelState.AddModelError("", "As senhas não se coincidem!");
            }
            else
            {
                UsuarioAplicacao AppUsuario = new UsuarioAplicacao();
                int retornoExecucao = AppUsuario.Salvar(usuario);

                if (retornoExecucao == 1)
                {
                    ModelState.AddModelError("", "O nome do usuário informado já existe em nosso sistema. Tente com outro nome.");                    
                }
                else
                {
                    return RedirectToAction("ListaUsuarios", new { nmUsuario = usuario.NmUsuario });
                }

            }

            return View(usuario);
        }

        
        public void MensagemShow(string msg, string tipoMsg)
        {
            ViewBag.msg = msg;
            ViewBag.tipoMsg = tipoMsg;
        }

    }



}