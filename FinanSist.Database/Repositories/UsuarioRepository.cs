using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries.Result;
using FinanSist.Domain.Queries.Result.Usuario;

namespace FinanSist.Database.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FinanSistContext context, IUnitOfWork uow) : base(context, uow)
        {

        }
        public bool ExistePorEmail(string email)
        {
            var result = _connection.Query(UsuarioQueries.ExistePorEmail(), new { Email = email }).FirstOrDefault();
            if (result == null)
                return false;
            return true;
        }

        public Usuario? PorEmail(string email)
        {
            return _connection.Query<Usuario>(UsuarioQueries.PorEmail(), new { Email = email }).FirstOrDefault();
        }

        public Usuario? PorTokenSenha(string token)
        {
            return _connection.Query<Usuario>(UsuarioQueries.PorTokenSenha(), new { TokenSenha = token }).FirstOrDefault();
        }
        public UsuarioFormQueryResult? PesquisarForm(SearchFormParams searchFormParams)
        {

            return _connection.Query<UsuarioFormQueryResult>(BaseQueries.PesquisarForm(searchFormParams), searchFormParams).FirstOrDefault();

        }

        public IEnumerable<ListaUsuarioFormQuery> Pesquisar(SearchParams searchParams)
        {
            return _connection.Query<ListaUsuarioFormQuery>(BaseQueries.Pesquisar(searchParams), searchParams);
        }
    }
}