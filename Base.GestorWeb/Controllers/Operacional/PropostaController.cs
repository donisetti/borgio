using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Kurtlewin.Dominio.Contexto;
using Kurtlewin.Dominio.Entidades;
using Kurtlewin.Dominio.Repositorio;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb.Controllers
{
    public class PropostaController : Controller
    {

        private KurtlewinDbContexto _contexto;
        private RepositorioProposta _repositorio;



        public PropostaController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioProposta(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Registros de Propostas", Relatorio = "ListagemProposta.trdx", Tela = "_GridProposta" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarProposta().ToDataSourceResult(request));
        }

        private IQueryable<PropostaViewModel> PegarProposta()
        {

            return _repositorio.ObterTodos().Project().To<PropostaViewModel>();


        }

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, PropostaViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Proposta dados = Mapper.Map<Proposta>(item);
                    _repositorio.Inserir(dados);
                    _contexto.SaveChanges();
                    item.PropostaId = dados.PropostaId;
                }
                catch (Exception erro)
                {

                    if (erro.InnerException.InnerException.Message.Contains("IdxNome"))
                    {
                        ModelState.AddModelError("", "O nome já foi incluído.");
                    }

                    _contexto.Rollback();
                    return Json(ModelState.ToDataSourceResult());

                }



            }

            return Json(new[] { item }.ToDataSourceResult(request));
        }


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, PropostaViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Proposta dados = Mapper.Map<Proposta>(item);
                    dados = _repositorio.Atualizar(dados);
                    _contexto.Commit();
                }
                catch (Exception erro)
                {

                    ModelState.AddModelError("", erro.Message);
                    _contexto.Rollback();

                }

            }
            return Json(ModelState.ToDataSourceResult());

        }

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, PropostaViewModel item)
        {
            try
            {
                _contexto.Propostas.Remove(_contexto.Propostas.Find(item.PropostaId));
                _contexto.SaveChanges();
                ModelState.IsValidField("true");
            }
            catch (Exception erro)
            {
                ModelState.IsValidField("false");
                ModelState.AddModelError("", erro.Message);
                _contexto.Rollback();
            }
            return Json(ModelState.ToDataSourceResult());

        }


    }
}