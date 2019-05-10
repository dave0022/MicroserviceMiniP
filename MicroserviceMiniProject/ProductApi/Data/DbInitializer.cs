using System.Collections.Generic;
using System.Linq;
using SharedModels;

namespace ProductApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(ProductApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Products
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            List<Product> products = new List<Product>
            {
                new Product { Name = "Hammer", Price = 150, ItemsInStock = 25, ItemsReserved = 0 },
                new Product { Name = "Screwdriver", Price = 90, ItemsInStock = 50, ItemsReserved = 0 },
                new Product { Name = "Drill", Price = 800, ItemsInStock = 5, ItemsReserved = 0 }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
