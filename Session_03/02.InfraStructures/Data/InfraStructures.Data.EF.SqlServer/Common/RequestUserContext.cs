
using InfraStructures.Data.EF.SqlServer.RequestUser;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace taskSession2.InfraStructures.Data.EF.SqlServer.Common
{
    public class RequestUserContext : DbContext
    {
        public DbSet<CheckNationalCode.Core.Domain.Users.RequestUser> Tasks { get; set; }
        public RequestUserContext(DbContextOptions<RequestUserContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestUserConfig());
            base.OnModelCreating(modelBuilder);
        }
    }

}
