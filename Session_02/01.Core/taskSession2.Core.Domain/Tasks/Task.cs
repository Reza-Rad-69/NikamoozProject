namespace taskSession2.taskSession2.Core.Domain.Tasks
{
    public class Task : BaseEntity
    {
        public List<StatusTask> statusTask { get; set; }
        public string Description { get; set; }
    }
}
