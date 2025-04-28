using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebbAPI.Data
{
    public class SystemDbContextFactory : IDesignTimeDbContextFactory<SystemDbContext> // IDesignTimeDbContextFactory creates DbContext at design time
    {
        public SystemDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") // Reads appsettings.json
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SystemDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); // get the connection string

            return new SystemDbContext(optionsBuilder.Options); 
        }
    }
    
    
}
