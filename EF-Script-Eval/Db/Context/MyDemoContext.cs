using EF_Script_Eval.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Script_Eval.Db.Context
{
    public class MyDemoContext : DbContext
    {
        public MyDemoContext(DbContextOptions<MyDemoContext> options) : base(options)
        {
        }

        //protected MyDemoContext() : base()
        //{
        //}



        public DbSet<MyDemoModel> Models { get; set; }
    }
}
