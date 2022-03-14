using Dapper;
using TestArchitectureReviewOne.Domain.Entities;
using TestArchitectureReviewOne.Domain.Interfaces.Infrastructure;
using TestArchitectureReviewOne.Domain.Interfaces.Repositories;
using TestArchitectureReviewOne.Domain.Queries;
using TestArchitectureReviewOne.Domain.Queries.Params;
using TestArchitectureReviewOne.Domain.Queries.Result;

namespace TestArchitectureReviewOne.Database.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(TestArchitectureReviewOneContext context, IUnitOfWork uow) : base(context, uow)
        {

        }
        public bool ExistePorEmail(string email)
        {
            var result = _connection.Query(UsuarioQueries.ExistePorEmail(), new { Email = email }).FirstOrDefault();
            if (result == null)
                return false;
            return true;
        }

        public UsuarioFormQueryResult? PesquisarForm(SearchFormParams searchFormParams)
        {

            return _connection.Query<UsuarioFormQueryResult>(BaseQueries.PesquisarForm(searchFormParams), searchFormParams.Id).FirstOrDefault();

        }
    }
}