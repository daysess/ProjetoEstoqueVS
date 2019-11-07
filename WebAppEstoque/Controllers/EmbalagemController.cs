using ProjetoEstoque.Aplicacao;
using ProjetoEstoque.Dominio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class EmbalagemController : Controller
    {

        EmbalagemAplicacao App = new EmbalagemAplicacao();
        TipoMensagem tipoMensagem = new TipoMensagem();


        public ActionResult ListarEmbalagens(string nmEmbalagem)
        {
            List<Embalagem> embalagens = new List<Embalagem>();
            embalagens = App.ListarTodos();

            if (nmEmbalagem != null)
            {
                MensagemShow("Cadastro realizado com sucesso", tipoMensagem.Success);
                embalagens = embalagens.FindAll(x => x.NmEmbalagem == nmEmbalagem);
            }

            return View(embalagens);
        }


        public ActionResult CadastroEmbalagem()
        {
            return View();
        }

        [HttpPost, ActionName("CadastroEmbalagem")]
        public ActionResult Cadastrar(Embalagem embalagem)
        {
            App.Salvar(embalagem);

            return RedirectToAction("ListarEmbalagens", new { nmEmbalagem = embalagem.NmEmbalagem });
            //return View();
        }

        public ActionResult Editar(int idEmbalagem)
        {
            Embalagem embalagem = new Embalagem();
            embalagem = App.ListarPorId(idEmbalagem);
            return View(embalagem);
        }

        [HttpPost, ActionName("Editar")]
        public ActionResult Alterar(Embalagem embalagem)
        {
            App.Salvar(embalagem);
            return RedirectToAction("ListarEmbalagens", new { nmEmbalagem = embalagem.NmEmbalagem });
            //return View();
        }

        public ActionResult Excluir(int idEmbalagem)
        {
            App.Excluir(idEmbalagem);
            return RedirectToAction("ListarEmbalagens");
        }


        public void MensagemShow(string msg, string tipoMsg)
        {
            ViewBag.msg = msg;
            ViewBag.tipoMsg = tipoMsg;
        }

    }
}