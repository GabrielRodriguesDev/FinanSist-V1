
using FinanSist.Domain.Entities;
using FinanSist.Domain.Queries.Result.DespesaTag;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface IDespesaTagRepository : IBaseRepository<DespesaTag>
    {
        DespesaTag? ExistePorIdDespesaTag(Guid despesaId, Guid tagId);

        void DeleteDespesaTag(Guid despesaId);

        bool ExistePorDepesa(Guid despesaId);

        bool ExistePorTag(Guid tagId);

        IEnumerable<DespesaTagFormQueryResult> SelectTagsPorDespesa(Guid despesaId);
    }
}