using taskSession2.taskSession2.Core.Domain;

namespace taskSession2.Core.ApplicationServices.Common
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new ()
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();

        void Delete(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
