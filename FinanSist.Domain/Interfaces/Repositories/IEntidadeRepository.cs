using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result.Entidade;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface IEntidadeRepository : IBaseRepository<Entidade>
    {
        bool ExistePorNome(string nome);

        EntidadeFormQueryResult? PesquisarForm(SearchFormParams searchFormParams);
        IEnumerable<ListaEntidadeQueryResult> Pesquisar(SearchParams searchParams);
    }
}