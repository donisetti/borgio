using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Kurtlewin.Dominio.Contexto;
using Kurtlewin.Dominio.Entidades;
using Base.GestorWeb.ViewModels;

namespace Base.GestorWeb
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {

            Mapper.CreateMap<TabelaAuxiliarViewModel, TabelaAuxiliar>();
            Mapper.CreateMap<TabelaAuxiliar, TabelaAuxiliarViewModel>();

            Mapper.CreateMap<PessoaViewModel, Pessoa>();
            Mapper.CreateMap<Pessoa, PessoaViewModel>();

            Mapper.CreateMap<EmpresaViewModel, Empresa>();
            Mapper.CreateMap<Empresa, EmpresaViewModel>();

            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<Cliente, ClienteViewModel>();

            Mapper.CreateMap<TitularViewModel, Titular>();
            Mapper.CreateMap<Titular, TitularViewModel>();

            Mapper.CreateMap<DependenteViewModel, Dependente>();
            Mapper.CreateMap<Dependente, DependenteViewModel>();

            Mapper.CreateMap<ColaboradorViewModel, Colaborador>();
            Mapper.CreateMap<Colaborador, ColaboradorViewModel>();

            Mapper.CreateMap<PropostaViewModel, Proposta>();
            Mapper.CreateMap<Proposta, PropostaViewModel>();

            Mapper.CreateMap<OcorrenciaViewModel, Ocorrencia>();
            Mapper.CreateMap<Ocorrencia, OcorrenciaViewModel>();

            Mapper.CreateMap<VisitaViewModel, Visita>();
            Mapper.CreateMap<Visita, VisitaViewModel>();

            Mapper.CreateMap<LigacaoViewModel, Ligacao>();
            Mapper.CreateMap<Ligacao, LigacaoViewModel>();

            Mapper.CreateMap<MensalidadeViewModel, Mensalidade>();
            Mapper.CreateMap<Mensalidade, MensalidadeViewModel>();

            Mapper.CreateMap<BaixaViewModel, Baixa>();
            Mapper.CreateMap<Baixa, BaixaViewModel>();

            Mapper.CreateMap<ComissoesViewModel, Comissao>();
            Mapper.CreateMap<Comissao, ComissoesViewModel>();


        }
    }
}