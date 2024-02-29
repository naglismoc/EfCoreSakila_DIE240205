using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SakilaConsoleApp
{
    public class SakilaDbContextFactory : IDesignTimeDbContextFactory<SakilaDbContext>
    {
        public SakilaDbContext CreateDbContext(string[] args)
        {
            // konfiguracijos uskelimas is appsettings.josn
            IConfigurationRoot confoguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            //connection string pasiemimas
            string connectionString = confoguration.GetConnectionString("DefaultConnection") ?? "";
            var builder = new DbContextOptionsBuilder<SakilaDbContext>();
            builder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 28)));
            return new SakilaDbContext(builder.Options);
        }
    }
}
