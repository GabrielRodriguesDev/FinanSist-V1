using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestArchitectureReviewOne.Domain.Entities;
using TestArchitectureReviewOne.Domain.Queries.Params;
using TestArchitectureReviewOne.Domain.Queries.Result;

namespace TestArchitectureReviewOne.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        UsuarioFormQueryResult? PesquisarForm(SearchFormParams searchFormParams);
        bool ExistePorEmail(string email);

    }
}