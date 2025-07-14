using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace taskSession2.InfraStructures.Data.EF.SqlServer.Tasks
{
    public class TaskConfig : IEntityTypeConfiguration<taskSession2.Core.Domain.Tasks.Task>
    {
        public void Configure(EntityTypeBuilder<taskSession2.Core.Domain.Tasks.Task> builder)
        {
            builder.Property(c => c.Description).HasMaxLength(500).IsRequired();
        }
    }
}
