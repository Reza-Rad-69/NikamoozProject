using taskSession2.Core.ApplicationServices.Common;

namespace taskSession2.Core.ApplicationServices.Tasks
{
    public interface ITaskRepository : IBaseRepository<taskSession2.Core.Domain.Tasks.Task>
    {
    }
}
