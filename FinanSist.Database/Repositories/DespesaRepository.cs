using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Despesa;

namespace FinanSist.Database.Repositories
{
    public class DespesaRepository : BaseRepository<Despesa>, IDespesaRepository
    {
        public DespesaRepository(FinanSistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public DespesaFormQueryResult? PesquisarForm(SearchFormParams searchFormParams)
        {
            return _connection.Query<DespesaFormQueryResult>(BaseQueries.PesquisarForm(searchFormParams), searchFormParams).FirstOrDefault();
        }
    }
}