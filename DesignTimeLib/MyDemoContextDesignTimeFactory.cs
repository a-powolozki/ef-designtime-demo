using EF_Script_Eval.Db.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesignTimeLib
{
    public class MyDemoContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDemoContext>
    {
        public MyDemoContext CreateDbContext(string[] args)
        {
            var configuration = InitializeConfiguration();

            var builder = new DbContextOptionsBuilder<MyDemoContext>();
            builder.UseSqlServer(configuration.GetConnectionString("MyDesiredConnectionStringName"));
            return new MyDemoContext(builder.Options);
        }

        private IConfiguration InitializeConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            configurationBuilder.AddJsonFile("appsettins.Development.json",optional: true);

            return configurationBuilder.Build();
        }
    }
}