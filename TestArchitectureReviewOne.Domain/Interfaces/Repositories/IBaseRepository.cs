using TestArchitectureReviewOne.Domain.Entities;

namespace TestArchitectureReviewOne.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Guid Create(TEntity entity);
        void Update(TEntity entity);
        void Detete(Guid id);
        void DeleteLogico(Guid id);
        TEntity? Get(Guid id);
        IEnumerable<TEntity> GetAll();
        bool ExistePorId(Guid? id);
    }
}