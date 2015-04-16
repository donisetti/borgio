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
    [Authorize(Roles = "Administrador,Operador,Internet")]
    public class PessoaController : Controller
    {

        private KurtlewinDbContexto _contexto;
        private RepositorioPessoa _repositorio;



        public PessoaController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioPessoa(_contexto);

            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Cadastro de Pessoas", Relatorio = "ListagemPessoas.trdx", Tela = "_GridPessoas" };
            return View(model);
        }

        public ActionResult LerColaborador([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarPessoas().ToDataSourceResult(request));
        }



        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarPessoas().ToDataSourceResult(request));
        }

        private IQueryable<PessoaViewModel> PegarPessoas()
        {

            //var dados = _repositorio.ObterTodos();

            //return dados.Select(t => new PessoaViewModel()
            //{
            //    PessoaId = t.PessoaId,
            //    Nome = t.Nome,
            //    Email = t.Email,
            //    Tipo = t.Tipo

            //});

            return _repositorio.ObterTodos().Project().To<PessoaViewModel>();
        }



        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, PessoaViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Pessoa dados = Mapper.Map<Pessoa>(item);
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, PessoaViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Pessoa dados = Mapper.Map<Pessoa>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, PessoaViewModel item)
        {
            try
            {
                _contexto.Pessoas.Remove(_contexto.Pessoas.Find(item.PessoaId));
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