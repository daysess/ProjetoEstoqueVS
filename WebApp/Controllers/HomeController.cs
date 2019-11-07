using ProjetoEstoque.Aplicacao;
using ProjetoEstoque.Dominio;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioAplicacao autenticar = new UsuarioAplicacao();
                string usuarioExistente = autenticar.AutenticarExistenciaUsuario(usuario.NmUsuario, usuario.Senha1);

                if (usuarioExistente != "")
                {
                    //TempData["NmUsuarioLogado"] = usuario.NmUsuario;
                    TempData["IdUsuarioLogado"] = usuario.IdUsuario;

                    Session["NmUsuarioLogado"] = usuario.NmUsuario;

                    return View("Portal", usuario);
                }
                else
                {
                    ModelState.AddModelError("", "Nome do usuário ou senha estão incorretos.");
                }
                
            }

            return View(usuario);
        }

        public ActionResult Portal(Usuario usuario)
        {
            return View(usuario);
        }
        

    }
}