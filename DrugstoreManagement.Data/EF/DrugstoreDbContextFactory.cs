using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Data.EF
{
    public class DrugstoreDbContextFactory : IDesignTimeDbContextFactory<DrugstoreDbContext>
    {
        public DrugstoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DrugstoreManagementDb");

            var optionsBuilder = new DbContextOptionsBuilder<DrugstoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DrugstoreDbContext(optionsBuilder.Options);
        }
    }
}
