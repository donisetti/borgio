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
    public class OcorrenciaController : Controller
    {

        private KurtlewinDbContexto _contexto;
        private RepositorioOcorrencia _repositorio;



        public OcorrenciaController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioOcorrencia(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Registros de Ocorrências", Relatorio = "ListagemOcorrencia.trdx", Tela = "_GridOcorrencia" };
            return View("_ConsultaBase", model);
        }

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarOcorrencia().ToDataSourceResult(request));
        }

        private IQueryable<OcorrenciaViewModel> PegarOcorrencia()
        {

            return _repositorio.ObterTodos().Project().To<OcorrenciaViewModel>();


        }

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, OcorrenciaViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Ocorrencia dados = Mapper.Map<Ocorrencia>(item);
                    _repositorio.Inserir(dados);
                    _contexto.SaveChanges();
                    item.OcorrenciaId = dados.OcorrenciaId;
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, OcorrenciaViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Ocorrencia dados = Mapper.Map<Ocorrencia>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, OcorrenciaViewModel item)
        {
            try
            {
                _contexto.Ocorrencias.Remove(_contexto.Ocorrencias.Find(item.OcorrenciaId));
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