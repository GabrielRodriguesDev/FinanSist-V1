using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using FinanSist.Domain.Interfaces.Infrastructure;

namespace FinanSist.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable

    {
#nullable disable

        #region  Property
        private FinanSistContext _context;

        private IDbContextTransaction _dbContextTransaction;
        #endregion

        #region Constructor
        public UnitOfWork(FinanSistContext context)
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

            _context.SaveChangesAsync().Wait(); // Criando ponto de salvamento de todas as mudanças no banco de dados.
            _dbContextTransaction.CommitAsync().Wait(); // Commitando todas as mudanças persistidas no banco de dados (com base no ultimo ponto de salvamento).
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