using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperBorgio.GestorWeb.ViewModels;

namespace SuperBorgio.GestorWeb.Controllers
{
    public class ListagemGeralController : Controller
    {
        // GET: ListagemGeral
        public ActionResult ListaTabAuxiliar()
        {
            //var model = new JanelaViewModel { Titulo = "Listagem de Visitas", Relatorio = "ListagemTabelaAuxiliar.trdx", Tela = "_ListaTabAuxiliar" };
            //return View("_ConsultaBase", model);

            return View();

        }


    }
}