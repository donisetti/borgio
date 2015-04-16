using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb.Controllers.Operacional
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Beneficiario()
        {
            var model = new JanelaViewModel
            {
                Titulo = "Registros de Beneficiários",
                Relatorio = "ListagemBeneficiario.trdx",
                Tela = "_GridBeneficiario"
            };

            return View("_ConsultaBase", model);
        }

        public ActionResult Dependente()
        {
            var model = new JanelaViewModel
            {
                Titulo = "Registros de Dependentes",
                Relatorio = "ListagemBeneficiario.trdx",
                Tela = "_GridDependente"
            };

            return View("_ConsultaBase", model);
        }

        public ActionResult Ocorrencia()
        {
            var model = new JanelaViewModel
            {
                Titulo = "Registros de Ocorrências",
                Relatorio = "ListagemOcorrencia.trdx",
                Tela = "_GridOcorrencia"
            };

            return View("_ConsultaBase", model);
        }
    }
}