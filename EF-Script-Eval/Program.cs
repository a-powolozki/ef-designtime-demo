using EF_Script_Eval.Db.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF_Script_Eval
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new WebApplicationOptions
            {
                Args = args,
                ContentRootPath = Environment.UserInteractive ? default : AppContext.BaseDirectory
            };
            var builder = WebApplication.CreateBuilder(options);
            Console.WriteLine("Hello, World!");

            var service = builder.Services;
            

            var configurationBuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            configurationBuilder.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true);

            service.AddDbContext<MyDemoContext>(contextBuilder => contextBuilder.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

            var app = builder.Build();            
        }
    }
}