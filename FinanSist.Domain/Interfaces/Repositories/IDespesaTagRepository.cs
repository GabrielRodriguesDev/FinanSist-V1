using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Queries.Result.DespesaTag;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface IDespesaTagRepository : IBaseRepository<DespesaTag>
    {
        DespesaTag? ExistePorIdDespesaTag(Guid despesaId, Guid tagId);

        void DeleteDespesaTag(Guid despesaId);

        bool ExistePorDepesa(Guid despesaId);

        IEnumerable<DespesaTagFormQueryResult> SelectTagsPorDespesa(Guid despesaId);
    }
}