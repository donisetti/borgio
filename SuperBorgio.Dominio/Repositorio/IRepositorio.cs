using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuperBorgio.Dominio.Repositorio
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entity);
        TEntity Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        TEntity Obter(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> ObterTodos();
        IUnitOfWork UnitOfWork { get; }

    }
}
