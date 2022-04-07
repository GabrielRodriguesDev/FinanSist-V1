using FinanSist.Domain.Entities;

namespace FinanSist.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Guid Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        void DeleteLogico(Guid id);
        TEntity? Get(Guid id);
        IEnumerable<TEntity> GetAll();
        bool ExistePorId(Guid? id);
        dynamic? RetornaCampo(Guid? id, String tabela, String campo);
    }
}