using ProjetoEstoque.Aplicacao;
using ProjetoEstoque.Dominio;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Controllers
{

    public class ProdutoController : Controller
    {

        TipoMensagem tipoMensagem = new TipoMensagem();
        ProdutoAplicacao App = new ProdutoAplicacao();

        // GET: Produto
        public ActionResult ListarProdutos(string nmProduto)
        {
            List<Produto> produtos = new List<Produto>();
            produtos = App.ListarTodos();

            if(nmProduto != null)
            {
                MensagemShow("Cadastro realizado com sucesso", tipoMensagem.Success);
                produtos = produtos.FindAll(x => x.NmProduto == nmProduto);
            }

            return View(produtos);
        }


        public ActionResult CadastroProduto()
        {
            return View();
        }

        [HttpPost, ActionName("CadastroProduto")]
        public ActionResult Cadastrar(Produto produto)
        {
            App.Salvar(produto);

            return RedirectToAction("ListarProdutos", new { nmProduto = produto.NmProduto });
            //return View();
        }

        public ActionResult Editar(int idProduto)
        {
            Produto produto = new Produto();
            produto = App.ListarPorId(idProduto);
            return View(produto);
        }

        [HttpPost, ActionName("Editar")]
        public ActionResult Alterar(Produto produto)
        {
            App.Salvar(produto);
            return RedirectToAction("ListarProdutos", new { nmProduto = produto.NmProduto });
            //return View();
        }

        public ActionResult Excluir(int idProduto)
        {
            App.Excluir(idProduto);
            return RedirectToAction("ListarProdutos");
        }


        public void MensagemShow(string msg, string tipoMsg)
        {
            ViewBag.msg = msg;
            ViewBag.tipoMsg = tipoMsg;
        }



    }
}