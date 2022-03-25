using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result;
using FinanSist.Domain.Queries.Result.Grupo;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {

        bool ExistePorNomeETipo(string nome, int? tipo);

        CategoriaFormQueryResult? PesquisarForm(SearchFormParams searchFormParams);

        IEnumerable<ListaCategoriaQueryResult> Pesquisar(SearchParams searchParams);


    }
}