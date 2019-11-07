using ProjetoEstoque.Aplicacao;
using ProjetoEstoque.Dominio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class CompraController : Controller
    {
        CompraAplicacao App = new CompraAplicacao();
        ProdutoAplicacao AppProduto = new ProdutoAplicacao();
        EmbalagemAplicacao AppEmbalagem = new EmbalagemAplicacao();
        TipoMensagem tipoMensagem = new TipoMensagem();


        public ActionResult ListarCompras(string idCompra)
        {
            List<Compra> compras = new List<Compra>();
            compras = App.ListarTodos();
            int id = 0;

            if (!string.IsNullOrEmpty(idCompra))
            {
                id = int.Parse(idCompra);
            }

            if (id > 0)
            {
                MensagemShow("Cadastro realizado com sucesso", tipoMensagem.Success);
                compras = compras.FindAll(x => x.IdCompra == id);
            }

            return View(compras);
        }


        public ActionResult Cadastrar()
        {
            DdlProdutos();
            DdlEmbalagens();

            return View();
        }

        private void DdlProdutos()
        {
            var listaProduto = AppProduto.ListarTodos();
            listaProduto.Add(new Produto { IdProduto = 0, NmProduto = "[Selecione o produto!]" });
            ViewBag.IdProduto = new SelectList(listaProduto, "IdProduto", "NmProduto");
        }

        private void DdlEmbalagens()
        {
            var listaEmbalagens = AppEmbalagem.ListarTodos();
            listaEmbalagens.Add(new Embalagem { IdEmbalagem = 0, NmEmbalagem = "[Selecione a embalagem!]" });
            ViewBag.IdEmbalagemCompra = new SelectList(listaEmbalagens, "IdEmbalagem", "DsEmbalagem");
            ViewBag.IdEmbalagemEstoque = new SelectList(listaEmbalagens, "IdEmbalagem", "DsEmbalagem");
        }

        [HttpPost, ActionName("Cadastrar")]
        public ActionResult CadastroCompra(Compra compra)
        {

            var idProduto = Request["IdProduto"];
            var idEmbalagem = Request["IdEmbalagem"];

            if (string.IsNullOrEmpty(idProduto))
            {
                ViewBag.Error = "Favor selecionar o produto!";
            }
            if (string.IsNullOrEmpty(idEmbalagem))
            {
                ViewBag.Error = "Favor selecionar a embalagem!";
            }

            App.Salvar(compra);

            return RedirectToAction("ListarCompras", new { idCompra = compra.IdCompra });
            /*
            DdlProdutos();
            DdlEmbalagens();
            MensagemShow("Favor preencher as informações para o cadastro da compra.", tipoMensagem.Warning);

            return View();*/

        }

        public ActionResult Editar(int idCompra)
        {
            Compra compra = new Compra();
            compra = App.ListarPorId(idCompra);
            return View(compra);
        }

        [HttpPost, ActionName("Editar")]
        public ActionResult Alterar(Compra compra)
        {
            App.Salvar(compra);
            return RedirectToAction("ListarCompras", new { idCompra = compra.IdCompra });
            //return View();
        }

        public ActionResult Excluir(int idCompra)
        {
            App.Excluir(idCompra);
            return RedirectToAction("ListarCompras");
        }


        public void MensagemShow(string msg, string tipoMsg)
        {
            ViewBag.msg = msg;
            ViewBag.tipoMsg = tipoMsg;
        }

        public ActionResult TesteQuery()
        {
            return View();
        }


    }
}