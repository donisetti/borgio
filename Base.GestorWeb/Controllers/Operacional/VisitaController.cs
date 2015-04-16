using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb.Controllers
{
    public class VisitaController : Controller
    {
        // GET: Visita
        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Registro de Visitas", Relatorio = "ListagemVisitas.trdx", Tela = "_GridVisitas" };
            return View("_ConsultaBase", model);
        }
    }
}