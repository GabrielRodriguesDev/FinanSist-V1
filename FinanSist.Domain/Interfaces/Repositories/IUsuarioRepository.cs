using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result;
using FinanSist.Domain.Queries.Result.Usuario;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        bool ExistePorEmail(string email);

        Usuario? PorEmail(string email);

        Usuario? PorTokenSenha(string token);

        UsuarioFormQueryResult? PesquisarForm(SearchFormParams searchFormParams);

        IEnumerable<ListaUsuarioFormQuery> Pesquisar(SearchParams searchParams);
    }
}