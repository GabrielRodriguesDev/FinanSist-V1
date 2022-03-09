using Dapper;
using TestArchitectureReviewOne.Domain.Entities;
using TestArchitectureReviewOne.Domain.Interfaces.Infrastructure;
using TestArchitectureReviewOne.Domain.Interfaces.Repositories;
using TestArchitectureReviewOne.Domain.Queries;

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
    }
}