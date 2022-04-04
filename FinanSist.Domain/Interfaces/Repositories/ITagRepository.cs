using FinanSist.Domain.Entities;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Tag;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        TagFormQueryResult? PesquisarForm(SearchFormParams searchFormParams);

        IEnumerable<ListaTagQueryResult> Pesquisar(SearchParams searchParams);

        bool ExistePorNome(String nome);
    }
}