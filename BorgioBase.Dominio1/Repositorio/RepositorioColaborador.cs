using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorgioBase.Dominio1.Entidades;

namespace BorgioBase.Dominio1.Repositorio
{
    public class RepositorioColaborador : Repositorio<Colaborador>
    {
        public RepositorioColaborador(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
