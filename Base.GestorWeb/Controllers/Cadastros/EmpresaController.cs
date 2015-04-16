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
    public class EmpresaController : Controller
    {


        private KurtlewinDbContexto _contexto;
        private RepositorioEmpresa _repositorio;



        public EmpresaController()
        {
            _contexto = new KurtlewinDbContexto();
            _repositorio = new RepositorioEmpresa(_contexto);


            // ViewData["Funcionarios"] = _repositorioFuncionario.ObterTodos().Select(c => new { Id = c.PessoaId, Nome = c.Nome }).OrderBy(x=>x.Nome);           

        }

        public ActionResult Index()
        {
            var model = new JanelaViewModel { Titulo = "Cadastro de Empresas", Relatorio = "ListagemEmpresas.trdx", Tela = "_GridEmpresas" };
            return View(model);
        }

        public ActionResult Ler([DataSourceRequest] DataSourceRequest request)
        {
            return Json(PegarEmpresas().ToDataSourceResult(request));
        }

        private IQueryable<EmpresaViewModel> PegarEmpresas()
        {
            var dados = _repositorio.ObterTodos().Where(e => e.Tipo == "Empresa");

            return dados.Select(t => new EmpresaViewModel()
            {
                PessoaId = t.PessoaId,
                TelCelular = t.TelCelular,
                TelResidencial = t.TelResidencial,
                Nome = t.Nome,
                Email = t.Email,
                Cnpj = t.Cnpj,
                InscricaoEstadual = t.InscricaoEstadual,
                DataConstituicao = t.DataConstituicao,
                Site = t.Site,


                Tipo = t.Tipo

            });
        }

        public ActionResult Incluir([DataSourceRequest] DataSourceRequest request, EmpresaViewModel item)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    Empresa dados = Mapper.Map<Empresa>(item);
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


        public ActionResult Atualizar([DataSourceRequest] DataSourceRequest request, EmpresaViewModel item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Empresa dados = Mapper.Map<Empresa>(item);
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

        public ActionResult Excluir([DataSourceRequest] DataSourceRequest request, EmpresaViewModel item)
        {
            try
            {
                _contexto.Empresas.Remove(_contexto.Empresas.Find(item.PessoaId));
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