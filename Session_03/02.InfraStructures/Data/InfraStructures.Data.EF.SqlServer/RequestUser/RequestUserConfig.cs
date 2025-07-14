using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CheckNationalCode.Core.Domain.Users;
namespace InfraStructures.Data.EF.SqlServer.RequestUser
{
    public class RequestUserConfig : IEntityTypeConfiguration<CheckNationalCode.Core.Domain.Users.RequestUser>
    {
        public void Configure(EntityTypeBuilder<CheckNationalCode.Core.Domain.Users.RequestUser> builder)
        {
            builder.Property(c => c.Request).HasMaxLength(500).IsRequired();
        }
    }
}
