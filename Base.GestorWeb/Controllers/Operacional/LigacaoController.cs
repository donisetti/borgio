using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb.Controllers
{
    public class LigacaoController : Controller
    {
        // GET: Ligacao
        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Registros de Ligação", Relatorio = "ListagemLigacao.trdx", Tela = "_GridLigacao" };
            return View("_ConsultaBase", model);
        }


    }
}
