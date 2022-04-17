
using FinanSist.Domain.Entities;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Despesa;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface IDespesaRepository : IBaseRepository<Despesa>
    {
        DespesaFormQueryResult? PesquisarForm(SearchFormParams searchFormParams);

        IEnumerable<ListaDespesaQueryResult> Pesquisar(SearchParams searchParams);
    }
}