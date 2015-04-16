﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorgioBase.Dominio1.Entidades;

namespace BorgioBase.Dominio1.Repositorio
{
    class RepositorioVisita : Repositorio<Visita>
    {
        public RepositorioVisita(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
