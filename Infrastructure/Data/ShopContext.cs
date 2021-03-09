using System.Reflection;
using Core.EntitiesDb;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Item> Items {get; set;}
        public DbSet<ItemType> ItemTypes {get; set;}
        public DbSet<ItemBrand> ItemBrands  {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}