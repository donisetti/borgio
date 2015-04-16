using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kurtlewin.Dominio.Contexto;
using Kurtlewin.Dominio.Repositorio;
using Kurtlewin.Dominio.Utilitarios;
using Base.GestorWeb.Models;

namespace Base.GestorWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {


        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Versao = "[ Versão: 1.01.7 - 13/04/2015 16:25 ]";

            //ViewBag.Extenso = Extenso.ToExtenso(245765.32, Extenso.TipoValorExtenso.Monetario);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}