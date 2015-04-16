using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb.Controllers.Operacional
{
    public class FinanceiroController : Controller
    {
        // GET: Financeiro


        public ActionResult Mensalidade()
        {
            var model = new JanelaViewModel { Titulo = "Registros de Mensalidades", Relatorio = "ListagemLigacao.trdx", Tela = "_GridMensalidade" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Baixa()
        {
            var model = new JanelaViewModel { Titulo = "Registros de Baixas", Relatorio = "ListagemBaixa.trdx", Tela = "_GridBaixa" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Comissoes()
        {
            var model = new JanelaViewModel { Titulo = "Registros de Comissões", Relatorio = "ListagemComissao.trdx", Tela = "_GridComissoes" };
            return View("_ConsultaBase", model);
        }
    }
}