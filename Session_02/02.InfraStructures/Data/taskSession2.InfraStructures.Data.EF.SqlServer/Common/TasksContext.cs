using Microsoft.EntityFrameworkCore;
using taskSession2.InfraStructures.Data.EF.SqlServer.StatusTask;
using taskSession2.InfraStructures.Data.EF.SqlServer.Tasks;
using taskSession2.taskSession2.Core.Domain;
namespace taskSession2.InfraStructures.Data.EF.SqlServer.Common
{
    public class TasksContext : DbContext
    {
        public DbSet<taskSession2.Core.Domain.Tasks.Task> Tasks { get; set; }
        public DbSet<StatusDescription> StatusDescription { get; set; }
        public DbSet<taskSession2.Core.Domain.StatusTask> StatusTask { get; set; }
        public TasksContext(DbContextOptions<TasksContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new StatusDescriptionConfig());
            modelBuilder.ApplyConfiguration(new StatusTaskConfig());
            modelBuilder.ApplyConfiguration(new StatusDescriptionConfig());

            base.OnModelCreating(modelBuilder);
        }
    }

}
