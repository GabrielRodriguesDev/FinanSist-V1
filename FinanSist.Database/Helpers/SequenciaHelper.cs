using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Helpers;
using FinanSist.Domain.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FinanSist.Database.Helpers
{
    public class SequenciaHelper : ISequenciaHelper
    {

        protected FinanSistContext _context;
        protected DbConnection _connection;

        protected IUnitOfWork _uow;

        public SequenciaHelper(FinanSistContext context, IUnitOfWork uow)
        {
            _context = context;
            _connection = _context.Database.GetDbConnection();
            _uow = uow;
        }
        public int ProximoNumero(string nomeTabela)
        {
            _uow.BeginTransaction();
            var sequencia = _connection.Query<Sequencia>($@"Select * From Sequencia Where Nome = @Nome", new { Nome = nomeTabela }, _uow.CurrentTransaction()).FirstOrDefault();
            try
            {
                if (sequencia == null)
                {
                    sequencia = new Sequencia(nomeTabela);
                    _connection.Execute("INSERT INTO `sequencia` (`Id`, `Nome`, `Numero`, `CriadoEm`, `AlteradoEm`) VALUES (@Id, @Nome, @Numero, @CriadoEm, @AlteradoEm);", sequencia, _uow.CurrentTransaction());

                }
                else
                {
                    sequencia.ProximoNumero();
                    sequencia.setAlteradoEm();
                    _connection.Execute("Update Sequencia set Numero = @Numero Where Id = @Id", sequencia, _uow.CurrentTransaction());
                }

                _uow.Commit();
            }
            catch (System.Exception)
            {
                _uow.Rollback();
                throw;
            }
            return sequencia.Numero;
        }

        public int ProximoNumeroCurrentTransaction(string nomeTabela)
        {
            var sequencia = _connection.Query<Sequencia>($@"Select * From Sequencia Where Nome = @Nome", new { Nome = nomeTabela }, _uow.CurrentTransaction()).FirstOrDefault();
            try
            {
                if (sequencia == null)
                {
                    sequencia = new Sequencia(nomeTabela);
                    _connection.Execute("INSERT INTO `sequencia` (`Id`, `Nome`, `Numero`, `CriadoEm`, `AlteradoEm`) VALUES (@Id, @Nome, @Numero, @CriadoEm, @AlteradoEm);", sequencia, _uow.CurrentTransaction());

                }
                else
                {
                    sequencia.ProximoNumero();
                    sequencia.setAlteradoEm();
                    _connection.Execute("Update Sequencia set Numero = @Numero Where Id = @Id", sequencia, _uow.CurrentTransaction());
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return sequencia.Numero;
        }
    }
}