using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;

namespace FinanSist.Database.Repositories
{
    public class EntidadeRepository : BaseRepository<Entidade>, IEntidadeRepository
    {
        public EntidadeRepository(FinanSistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public bool ExistePorNome(string nome)
        {
            var result = _connection.Query(EntidadeQueries.ExistePorNome(), new { Nome = nome });
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}