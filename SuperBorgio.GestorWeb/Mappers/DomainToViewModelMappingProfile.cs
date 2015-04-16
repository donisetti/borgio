using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SuperBorgio.GestorWeb.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            //Mapper.CreateMap<Cliente, ClienteViewModel>();
        }
    }
}