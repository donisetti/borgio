using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBorgio.Dominio.Entidades;

namespace SuperBorgio.Dominio.Repositorio
{
    public class RepositorioPessoa : Repositorio<Pessoa>
    {
        public RepositorioPessoa(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
