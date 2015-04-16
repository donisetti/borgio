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
    public class TitularController : Controller
    {

        private KurtlewinDbContexto _contexto;
        private RepositorioTitular _repositorio;



        public TitularController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioTitular(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Cadastro de Titulares", Relatorio = "ListagemTitulares.trdx", Tela = "_GridTitular" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTitular().ToDataSourceResult(request));
        }

        private IQueryable<TitularViewModel> PegarTitular()
        {

            return _repositorio.ObterTodos().Project().To<TitularViewModel>();


        }

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, TitularViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Titular dados = Mapper.Map<Titular>(item);
                    _repositorio.Inserir(dados);
                    _contexto.SaveChanges();
                    item.PessoaId = dados.PessoaId;
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, TitularViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Titular dados = Mapper.Map<Titular>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, TitularViewModel item)
        {
            try
            {
                _contexto.Titulares.Remove(_contexto.Titulares.Find(item.PessoaId));
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