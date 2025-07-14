using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using taskSession2.taskSession2.Core.Domain;

namespace taskSession2.InfraStructures.Data.EF.SqlServer.StatusTask
{
    public class StatusDescriptionConfig : IEntityTypeConfiguration<StatusDescription>
    {
        public void Configure(EntityTypeBuilder<StatusDescription> builder)
        {
            builder.Property(c => c.Description).HasMaxLength(50).IsRequired();
        }
    }
}
