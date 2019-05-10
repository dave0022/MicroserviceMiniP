using System.Collections.Generic;
using System.Linq;
using SharedModels;
using System;

namespace OrderApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        
        public void Initialize(OrderApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            
            if (context.Orders.Any())
            {
                return;   
            }

            List<Order> orders = new List<Order>
            {
                new Order { Date = DateTime.Today, ProductId = 1, Quantity = 2 }
            };

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
