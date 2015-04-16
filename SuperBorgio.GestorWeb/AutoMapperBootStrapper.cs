using AutoMapper;
using SuperBorgio.Dominio.Entidades;
using SuperBorgio.GestorWeb.ViewModels;

namespace SuperBorgio.GestorWeb
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {

            Mapper.CreateMap<TabelaAuxiliarViewModel, TabelaAuxiliar>();
            Mapper.CreateMap<TabelaAuxiliar, TabelaAuxiliarViewModel>();

            Mapper.CreateMap<ProdutoViewModel, Produto>();


            Mapper.CreateMap<Produto, ProdutoViewModel>()
              .ForMember(d=>d.sCusto1, o=>o.MapFrom(p=>p.Custo1.ToString()+" "+p.Fornecedor1))
              .ForMember(d=>d.sCusto2, o=>o.MapFrom(p=>p.Custo2.ToString()+" "+p.Fornecedor2))
              .ForMember(d=>d.sCusto3, o=>o.MapFrom(p=>p.Custo3.ToString()+" "+p.Fornecedor3))
              .ForMember(d=>d.sCusto4, o=>o.MapFrom(p=>p.Custo4.ToString()+" "+p.Fornecedor4))
              .ForMember(d=>d.sCusto5, o=>o.MapFrom(p=>p.Custo5.ToString()+" "+p.Fornecedor5));




        }
    }
}