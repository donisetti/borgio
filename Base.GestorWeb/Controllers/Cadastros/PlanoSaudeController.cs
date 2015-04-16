﻿using System;
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
    public class PlanoSaudeController : Controller
    {

        private KurtlewinDbContexto _contexto;
        private RepositorioPlanoSaude _repositorio;



        public PlanoSaudeController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioPlanoSaude(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarEmpresas().ToDataSourceResult(request));
        }

        private IQueryable<PlanoSaudeViewModel> PegarEmpresas()
        {
            var dados = _repositorio.ObterTodos();

            return dados.Select(t => new PlanoSaudeViewModel()
            {
                PlanoSaudeId = t.PlanoSaudeId,

                Nome = t.Nome,


            });
        }

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, PlanoSaudeViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    PlanoSaude dados = Mapper.Map<PlanoSaude>(item);
                    _repositorio.Inserir(dados);
                    _contexto.SaveChanges();
                    item.PlanoSaudeId = dados.PlanoSaudeId;
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, PlanoSaudeViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    PlanoSaude dados = Mapper.Map<PlanoSaude>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, PlanoSaudeViewModel item)
        {
            try
            {
                _contexto.PlanosSaudes.Remove(_contexto.PlanosSaudes.Find(item.PlanoSaudeId));
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