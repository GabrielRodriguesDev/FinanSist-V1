using System.Data.Common;
using Dapper;
using Microsoft.EntityFrameworkCore;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;

namespace FinanSist.Database.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Property
        protected FinanSistContext _context;

        protected DbSet<TEntity> _dbSet;

        protected DbConnection _connection;

        protected IUnitOfWork _uow;

        #endregion

        #region  Constructor
        public BaseRepository(FinanSistContext context, IUnitOfWork uow)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _connection = _context.Database.GetDbConnection();
            _uow = uow;
        }
        #endregion

        #region  Method
        public Guid Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity.Id;
        }

        public void DeleteLogico(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            _connection.Execute($@"Delete from {typeof(TEntity).Name} where Id = @Id", new { Id = id }, _uow.CurrentTransaction());
        }

        public bool ExistePorId(Guid? id)
        {
            var result = _connection.Query(BaseQueries.ExistePorId(typeof(TEntity).Name), new { Id = id }).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public TEntity? Get(Guid id)
        {
            return _connection.Query<TEntity>($@"Select * from {typeof(TEntity).Name} where Id = @Id", new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _connection.Query<TEntity>($@"Select * from {typeof(TEntity).Name}", null);
        }

        public void Update(TEntity entity)
        {
            entity.setAlteradoEm();
            _dbSet.Update(entity);
        }
        #endregion
    }
}