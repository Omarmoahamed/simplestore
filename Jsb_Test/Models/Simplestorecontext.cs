using Microsoft.EntityFrameworkCore;

namespace Jsb_Test.Models
{
    public class Simplestorecontext : DbContext
    {
        public Simplestorecontext(DbContextOptions<Simplestorecontext> dbContextOptions) : base(dbContextOptions) { }


        public DbSet<Order> Orders { get; set; }

     
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}
