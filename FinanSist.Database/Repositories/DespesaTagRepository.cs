using Dapper;
using FinanSist.Domain.Entities;
using FinanSist.Domain.Interfaces.Infrastructure;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Result.DespesaTag;

namespace FinanSist.Database.Repositories
{
    public class DespesaTagRepository : BaseRepository<DespesaTag>, IDespesaTagRepository
    {
        public DespesaTagRepository(FinanSistContext context, IUnitOfWork uow) : base(context, uow)
        {
        }

        public DespesaTag? ExistePorIdDespesaTag(Guid despesaId, Guid tagId)
        {
            return _connection.Query<DespesaTag>(DespesaTagQueries.ExistePorIdDespesaTag(), new { DespesaId = despesaId, TagId = tagId }, _uow.CurrentTransaction()).FirstOrDefault();
        }

        public void DeleteDespesaTag(Guid desesaId)
        {
            _connection.Query(DespesaTagQueries.DeleteDespesaTag(), new { DespesaId = desesaId }, _uow.CurrentTransaction());

        }

        public bool ExistePorDepesa(Guid despesaId)
        {
            var despesaTag = _connection.Query(DespesaTagQueries.ExistePorDepesa(), new { DespesaId = despesaId }, _uow.CurrentTransaction());
            if (despesaTag.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<DespesaTagFormQueryResult> SelectTagsPorDespesa(Guid despesaId)
        {
            return _connection.Query<DespesaTagFormQueryResult>(DespesaTagQueries.SelectTagsPorDespesa(), new { DespesaId = despesaId }, _uow.CurrentTransaction());
        }

        public bool ExistePorTag(Guid tagId)
        {
            var despesaTag = _connection.Query(DespesaTagQueries.ExistePorTag(), new { TagId = tagId }, _uow.CurrentTransaction());
            if (despesaTag.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}