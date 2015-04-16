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
    [Authorize]
    public class DependenteController : Controller
    {

        private KurtlewinDbContexto _contexto;
        private RepositorioDependente _repositorio;



        public DependenteController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioDependente(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Cadastro de Dependentes", Relatorio = "ListagemDependentes.trdx", Tela = "_GridDependente" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarDependente().ToDataSourceResult(request));
        }

        private IQueryable<DependenteViewModel> PegarDependente()
        {

            return _repositorio.ObterTodos().Project().To<DependenteViewModel>();


        }

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, DependenteViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Dependente dados = Mapper.Map<Dependente>(item);
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, DependenteViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Dependente dados = Mapper.Map<Dependente>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, DependenteViewModel item)
        {
            try
            {
                _contexto.Dependentes.Remove(_contexto.Dependentes.Find(item.PessoaId));
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