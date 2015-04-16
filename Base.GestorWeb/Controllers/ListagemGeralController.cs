using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb.Controllers
{
    public class ListagemGeralController : Controller
    {
        // GET: ListagemGeral
        public ActionResult ListaTabAuxiliar()
        {
            var model = new JanelaViewModel { Titulo = "Listagem de Visitas", Relatorio = "ListagemTabelaAuxiliar.trdx", Tela = "_ListaTabAuxiliar" };
            return View("_ConsultaBase", model);

        }

        public ActionResult Clientes()
        {
            var model = new JanelaViewModel { Titulo = "Listagem de Clientes", Relatorio = "ListagemClientes.trdx", Tela = "_ListaTabAuxiliar" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Operadoras()
        {
            return View();
        }

        public ActionResult Colaboradores()
        {
            var model = new JanelaViewModel { Titulo = "Listagem de Colaboradores", Relatorio = "ListagemColaboradores.trdx", Tela = "_ListaTabAuxiliar" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Propostas()
        {
            var model = new JanelaViewModel { Titulo = "Listagem de Propostas", Relatorio = "ListagemProposta.trdx", Tela = "_ListaTabAuxiliar" };
            return View("_ConsultaBase", model);
        }
    }
}