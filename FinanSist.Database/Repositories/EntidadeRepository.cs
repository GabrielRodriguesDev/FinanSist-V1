using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Entidade;

namespace FinanSist.Database.Repositories
{
    public class EntidadeRepository : BaseRepository<Entidade>, IEntidadeRepository
    {
        public EntidadeRepository(FinanSistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public bool ExistePorNome(string nome)
        {
            var result = _connection.Query(EntidadeQueries.ExistePorNome(), new { Nome = nome }).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public EntidadeFormQueryResult? PesquisarForm(SearchFormParams searchFormParams)
        {
            return _connection.Query<EntidadeFormQueryResult>(BaseQueries.PesquisarForm(searchFormParams), searchFormParams).FirstOrDefault();
        }

        public IEnumerable<ListaEntidadeQueryResult> Pesquisar(SearchParams searchParams)
        {
            return _connection.Query<ListaEntidadeQueryResult>(BaseQueries.Pesquisar(searchParams), searchParams);
        }
    }
}