using taskSession2.Core.ApplicationServices.Common;
using taskSession2.taskSession2.Core.Domain;

namespace taskSession2.InfraStructures.Data.EF.SqlServer.Common
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly TasksContext dbContext;

        public BaseRepository(TasksContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }
        public void Delete(int id)
        {
            TEntity entity = new TEntity
            {
                id = id
            };
            dbContext.Remove(entity);
            dbContext.SaveChanges();

        }
        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
