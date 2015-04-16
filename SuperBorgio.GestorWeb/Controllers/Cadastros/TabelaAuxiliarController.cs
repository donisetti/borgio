using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SuperBorgio.Dominio.Contexto;
using SuperBorgio.Dominio.Entidades;
using SuperBorgio.Dominio.Repositorio;
using SuperBorgio.GestorWeb.ViewModels;

namespace SuperBorgio.GestorWeb.Controllers
{
    public class TabelaAuxiliarController : Controller
    {

        private DbContexto _contexto;
        private RepositorioTabelaAuxiliar _repositorio;



        public TabelaAuxiliarController()
        {
            _contexto = new DbContexto();
            _repositorio = new RepositorioTabelaAuxiliar(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RamoAtividades()
        {
            var model = new JanelaViewModel { Titulo = "Cadastro de Ramo de Atividades", Relatorio = "", Tela = "_GridRamoAtividades" };
            return View(model);
        }

        public ActionResult Nacionalidades()
        {
            var model = new JanelaViewModel { Titulo = "Cadastro de Nacionalidade", Relatorio = "", Tela = "_GridNacionalidades" };
            return View(model);
        }

        public ActionResult Cargos()
        {
            return View();
        }

        public ActionResult Acomodacoes()
        {
            return View();
        }

        public ActionResult Associacoes()
        {
            return View();
        }

        public ActionResult TipoPlanoSaude()
        {
            return View();
        }

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTabelaAuxiliares().ToDataSourceResult(request));
        }

        public ActionResult LerRamoAtividade([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTabelaAuxiliares("Ramo de Atividade").ToDataSourceResult(request));
        }

        public ActionResult LerNacionalidade([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTabelaAuxiliares("Nacionalidade").ToDataSourceResult(request));
        }

        public ActionResult LerCargos([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTabelaAuxiliares("Cargo").ToDataSourceResult(request));
        }

        //LerAcomodacoes

        public ActionResult LerAcomodacoes([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTabelaAuxiliares("Acomodações").ToDataSourceResult(request));
        }

        public ActionResult LerTipoPlano([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTabelaAuxiliares("Tipo de Plano").ToDataSourceResult(request));
        }

        public ActionResult LerAssociacoes([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarTabelaAuxiliares("Tipo de Associação").ToDataSourceResult(request));
        }



        private IQueryable<TabelaAuxiliarViewModel> PegarTabelaAuxiliares(string tipo = "Todos")
        {
            if (tipo != "Todos")
            {
                //var dados = _repositorio.ObterTodos().Where(x => x.Tipo == tipo);


                //return ListarDados(dados);

                return _repositorio.ObterTodos().Where(x => x.Tipo == tipo).Project().To<TabelaAuxiliarViewModel>();
            }
            else
            {
                //var dados = _repositorio.ObterTodos();
                //return ListarDados(dados);

                return _repositorio.ObterTodos().Project().To<TabelaAuxiliarViewModel>();

            }
        }

        //private static IQueryable<TabelaAuxiliarViewModel> ListarDados(IQueryable<TabelaAuxiliar> dados)
        //{
        //    return dados.Select(t => new TabelaAuxiliarViewModel()
        //    {
        //        Id = t.Id,
        //        Nome = t.Nome,
        //        Tipo = t.Tipo
        //    });
        //}

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, TabelaAuxiliarViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    TabelaAuxiliar dados = Mapper.Map<TabelaAuxiliar>(item);
                    _repositorio.Inserir(dados);
                    _contexto.SaveChanges();
                    item.Id = dados.Id;
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, TabelaAuxiliarViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    TabelaAuxiliar dados = Mapper.Map<TabelaAuxiliar>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, TabelaAuxiliarViewModel item)
        {
            try
            {
                _contexto.TabelasAuxiliares.Remove(_contexto.TabelasAuxiliares.Find(item.Id));
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