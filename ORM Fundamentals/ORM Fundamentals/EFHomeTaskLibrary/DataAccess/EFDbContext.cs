using Data;
using Microsoft.EntityFrameworkCore;

namespace EFHomeTaskLibrary
{
   public class EFDbContext: Microsoft.EntityFrameworkCore.DbContext
   {
      public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) { }
      public DbSet<Product> Product { get; set; }
      public DbSet<Order> Order { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Order>()
             .Property(o => o.Status)
             .HasConversion(
                 o => o.ToString(),
                 o => (Status)Enum.Parse(typeof(Status), o));
      }
   }
}
