using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProductCatalog.Entities
{
    public sealed class Context : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(pc => pc.ProductCategoryId);
         
            var pc1 = new ProductCategory {Id = 1, Name = "Молочная продукция"};
            var pc2 = new ProductCategory {Id = 2, Name = "Выпечка"};

            modelBuilder.Entity<ProductCategory>().HasData(pc1, pc2);
            
            modelBuilder.Entity<Product>().HasData(
                   new Product { Id = 1, ProductCategoryId = 1, Name = "Молоко", 
                       Specification = JsonConvert.SerializeObject(new JObject{
                           { "Вес", "500г" },
                           { "Тара", "Стекляная бутылка" }
                       })
                   },
                   new Product { Id = 2, ProductCategoryId = 1, Name = "Кефир" },
                   new Product { Id = 3, ProductCategoryId = 2, Name = "Плюшка",
                       Specification = JsonConvert.SerializeObject(new JObject{
                           { "Вес", "500г" },
                           { "Состав", new JArray {"Мука", "Масло", "Яйца", "Сахар" }}
                       })
                   }
               );
        }
    }
}
