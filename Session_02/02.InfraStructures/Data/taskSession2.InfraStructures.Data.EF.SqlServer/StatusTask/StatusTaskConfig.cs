using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace taskSession2.InfraStructures.Data.EF.SqlServer.StatusTask
{
    public class StatusTaskConfig : IEntityTypeConfiguration<taskSession2.Core.Domain.StatusTask>
    {
        public void Configure(EntityTypeBuilder<taskSession2.Core.Domain.StatusTask> builder)
        {
            builder.Property(c => c.statusDate).HasMaxLength(8).IsRequired();
        }
    }
}
