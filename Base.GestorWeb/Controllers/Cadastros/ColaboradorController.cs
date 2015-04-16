using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Kurtlewin.Dominio.Contexto;
using Kurtlewin.Dominio.Entidades;
using Kurtlewin.Dominio.Repositorio;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb.Controllers
{
    [Authorize]
    public class ColaboradorController : Controller
    {

        private KurtlewinDbContexto _contexto;
        private RepositorioColaborador _repositorio;



        public ColaboradorController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioColaborador(_contexto);

            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            return View();
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
            var dados = _repositorio.ObterTodos();

            return dados.Select(t => new PessoaViewModel()
            {
                PessoaId = t.PessoaId,
                Nome = t.Nome,
                Email = t.Email,
                Tipo = t.Tipo

            });
        }



        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, ColaboradorViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Colaborador dados = Mapper.Map<Colaborador>(item);
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, ColaboradorViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Colaborador dados = Mapper.Map<Colaborador>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, ColaboradorViewModel item)
        {
            try
            {
                _contexto.Colaboradores.Remove(_contexto.Colaboradores.Find(item.PessoaId));
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