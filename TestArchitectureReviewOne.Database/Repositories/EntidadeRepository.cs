using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TestArchitectureReviewOne.Domain.Interfaces.Repositories;
using TestArchitectureReviewOne.Domain.Queries;

namespace TestArchitectureReviewOne.Database.Repositories
{
    public class EntidadeRepository : IEntidadeRepository

    {
        protected TestArchitectureReviewOneContext _context;
        protected DbConnection _connection;

        public EntidadeRepository(TestArchitectureReviewOneContext context)
        {
            _context = context;
            _connection = _context.Database.GetDbConnection();

        }

        public bool ExistePorNome(string nome)
        {
            var sql = EntidadeQueries.ExistePorNome();
            var result = _connection.Query(EntidadeQueries.ExistePorNome(), new { Nome = nome }).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}