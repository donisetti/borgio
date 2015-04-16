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
    public class ProdutoController : Controller
    {

        private DbContexto _contexto;
        private RepositorioProduto _repositorio;



        public ProdutoController()
        {
            _contexto = new DbContexto();
            _repositorio = new RepositorioProduto(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            //var model = new JanelaViewModel { Titulo = "Cadastro de Produtos", Relatorio = "", Tela = "_GridProdutos" };
            //return View(model);

            var model = new JanelaViewModel { Titulo = "Registro de Preços de Produtos", Relatorio = "ListagemProdutos.trdx", Tela = "_GridProdutos" };
            return View("_ConsultaBase", model);
        }

       

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarProdutos().ToDataSourceResult(request));
        }

     



        private IQueryable<ProdutoViewModel> PegarProdutos(string tipo = "Todos")
        {
            if (tipo != "Todos")
            {
             
                var dados =  _repositorio.ObterTodos().Project().To<ProdutoViewModel>();


                return dados;
            }
            else
            {
               
                var dados = _repositorio.ObterTodos().Project().To<ProdutoViewModel>();


                return dados;

            }
        }

   

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, ProdutoViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Produto dados = Mapper.Map<Produto>(item);
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, ProdutoViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Produto dados = Mapper.Map<Produto>(item);
                    dados = _repositorio.Atualizar(dados);
                    _contexto.Commit();
                    item.Id = dados.Id;
                }
                catch (Exception erro)
                {

                    ModelState.AddModelError("", erro.Message);
                    _contexto.Rollback();

                }

            }
            return Json(ModelState.ToDataSourceResult());

        }

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, ProdutoViewModel item)
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