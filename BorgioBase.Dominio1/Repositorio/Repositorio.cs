using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorgioBase.Dominio1.Contexto;

namespace BorgioBase.Dominio1.Repositorio
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<TEntity> _context;

        public Repositorio(IUnitOfWork unitOfWork)
        {

            _context = ((DbContexto)unitOfWork).Set<TEntity>();

            //_context = new ApplicationDbContext().Set<TEntity>();
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        public DbSet<TEntity> Context { get { return _context; } }

        public TEntity Inserir(TEntity entity)
        {
            try
            {
                _context.Add(entity);
                ((DbContexto)_unitOfWork).Entry(entity).State = EntityState.Added;
            }
            catch (Exception)
            {
                throw new Exception("Nome Já está cadastrado.");
            }

            return entity;
        }
        public TEntity InserirOuAtualizar(TEntity entity)
        {
            try
            {
                _context.AddOrUpdate(entity);
                ((DbContexto)_unitOfWork).Entry(entity).State = EntityState.Added;
            }
            finally
            {
            }

            return entity;
        }

        public TEntity Atualizar(TEntity entity)
        {
            ((DbContexto)_unitOfWork).Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Excluir(TEntity entity)
        {
            _context.Remove(entity);
        }

        public virtual TEntity Obter(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return _context.FirstOrDefault(filter);
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return _context;
        }


    }
}
