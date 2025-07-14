using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace taskSession2.InfraStructures.Data.EF.SqlServer.Common
{
    public class TasksContextFactory : IDesignTimeDbContextFactory<RequestUserContext>
    {
        public RequestUserContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RequestUserContext>();
            var connectionString = configuration.GetConnectionString("Tasks");
            builder.UseSqlServer(connectionString);
            return new RequestUserContext(builder.Options);
        }
    }
}
