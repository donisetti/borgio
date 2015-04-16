using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Repositorio
{
    public interface IUnitOfWork
    {
        int Commit();
        System.Threading.Tasks.Task CommitAsync();
        void Rollback();
    }
}
