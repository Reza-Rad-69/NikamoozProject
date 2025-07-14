using taskSession2.Core.ApplicationServices.StatusTasks;
using taskSession2.InfraStructures.Data.EF.SqlServer.Common;

namespace taskSession2.InfraStructures.Data.EF.SqlServer.StatusTask
{
    public class StatusTaskRepository : BaseRepository<taskSession2.Core.Domain.StatusTask>, IStatusTasksRepository
    {
        public StatusTaskRepository(TasksContext dbContext) : base(dbContext)
        {
        }
    }
}
