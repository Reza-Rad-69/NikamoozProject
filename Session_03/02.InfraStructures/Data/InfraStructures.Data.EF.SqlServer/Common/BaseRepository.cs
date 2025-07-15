using CheckNationalCode.Core.ApplicationServices.Common;
using CheckNationalCode.Core.Domain;

namespace InfraStructures.Data.EF.SqlServer.Common
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly RequestUserContext dbContext;

        public BaseRepository(RequestUserContext dbContext)
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
