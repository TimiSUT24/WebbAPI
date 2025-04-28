using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebbAPI.Data
{
    public class SystemDbContextFactory : IDesignTimeDbContextFactory<SystemDbContext>
    {
        public SystemDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SystemDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new SystemDbContext(optionsBuilder.Options);
        }
    }
    
    
}
