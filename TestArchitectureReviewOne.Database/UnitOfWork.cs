using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using TestArchitectureReviewOne.Domain.Interfaces.Infrastructure;

namespace TestArchitectureReviewOne.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable

    {
#nullable disable

        #region  Property
        private TestArchitectureReviewOneContext _context;

        private IDbContextTransaction _dbContextTransaction;
        #endregion

        #region Constructor
        public UnitOfWork(TestArchitectureReviewOneContext context)
        {
            _context = context;
        }
        #endregion

        #region  Method
        public void BeginTransaction() // Inicia a transação.
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbContextTransaction == null)
                throw new Exception("Transação não iniciada");

            _context.SaveChangesAsync().Wait(); // Persistindo todas as mudanças no banco de dados.
            _dbContextTransaction.CommitAsync().Wait(); // Commitando todas as mudanças persistidas no banco de dados.
            _context.ChangeTracker.Clear(); // Liberando o estado das entidades rastreadas pelo EF.
            _dbContextTransaction = null; // Setando null na transação.
        }

        public IDbTransaction CurrentTransaction()
        {
            IDbTransaction result = null;
            if (_dbContextTransaction != null)
                result = _dbContextTransaction.GetDbTransaction();
            return result;
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
                _dbContextTransaction.DisposeAsync();

        }

        public void Rollback()
        {
            if (_dbContextTransaction != null)
                _dbContextTransaction.RollbackAsync().Wait(); // Discartando todas as mudanças realizadas durante a transação.
        }
        #endregion
    }
}