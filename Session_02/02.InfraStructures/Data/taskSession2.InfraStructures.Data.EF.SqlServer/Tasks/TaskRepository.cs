using taskSession2.Core.ApplicationServices.Tasks;
using taskSession2.InfraStructures.Data.EF.SqlServer.Common;

namespace taskSession2.InfraStructures.Data.EF.SqlServer.Tasks
{
    public class TaskRepository : BaseRepository<taskSession2.Core.Domain.Tasks.Task>, ITaskRepository
    {
        public TaskRepository(TasksContext dbContext) : base(dbContext)
        {

        }
    }
}
