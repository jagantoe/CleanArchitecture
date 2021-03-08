using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.DataAccess
{
    public class CleanArchitectureDbContext: DbContext
    {
        private readonly IConfigurationHelper _configurationHelper;
        public DbSet<User> User { get; set; }
        public CleanArchitectureDbContext(IConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configurationHelper.ConnectionString);
        }
    }
}
