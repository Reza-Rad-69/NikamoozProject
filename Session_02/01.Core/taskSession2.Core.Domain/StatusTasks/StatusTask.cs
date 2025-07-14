namespace taskSession2.taskSession2.Core.Domain
{
    public class StatusTask : BaseEntity
    {
        public int statusDescriptionId { get; set; }
        public StatusDescription statusDescription { get; set; }

        public int TaskId { get; set; }
        public taskSession2.Core.Domain.Tasks.Task task { get; set; }
        public int statusDate { get; set; }
    }
}
