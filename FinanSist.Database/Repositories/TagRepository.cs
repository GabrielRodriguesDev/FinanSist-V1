using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Tag;

namespace FinanSist.Database.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(FinanSistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public IEnumerable<ListaTagQueryResult> Pesquisar(SearchParams searchParams)
        {
            return _connection.Query<ListaTagQueryResult>(BaseQueries.Pesquisar(searchParams), searchParams);
        }

        public TagFormQueryResult? PesquisarForm(SearchFormParams searchFormParams)
        {
            return _connection.Query<TagFormQueryResult>(BaseQueries.PesquisarForm(searchFormParams), searchFormParams).FirstOrDefault();
        }

        public bool ExistePorNome(String nome)
        {
            var result = _connection.Query(TagQueries.ExistePorNome(), new { Nome = nome }).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}