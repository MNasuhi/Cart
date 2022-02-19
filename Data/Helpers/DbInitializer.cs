using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Helpers
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            
            context.Database.EnsureCreated();

            if (context.Product.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product {ProductCode = "101",ProductName = "Limonata", Amount = 12.5M , Quantity = 15,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created },
                new Product {ProductCode = "102",ProductName = "Çay", Amount = 6.45M , Quantity = 5,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created },
                new Product {ProductCode = "201",ProductName = "Çikolata", Amount = 2.33M , Quantity = 15,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created },
                new Product {ProductCode = "202",ProductName = "Kek", Amount = 0.85M , Quantity = 10,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created },
                new Product {ProductCode = "301",ProductName = "Pantolon", Amount = 130.95M , Quantity = 1,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created },
                new Product {ProductCode = "302",ProductName = "Gömlek", Amount = 145.99M , Quantity = 2,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created },
                new Product {ProductCode = "303",ProductName = "Kazak", Amount = 127.99M , Quantity = 3,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created },
                new Product {ProductCode = "304",ProductName = "Çorap", Amount = 27.44M , Quantity = 4,CreatedDate = DateTime.Now, CreatedUser = 1, UpdatedDate = DateTime.Now, UpdatedUser = 1, Status = Enums.Status.Created}
            };

            context.AddRange(products);

            var carts = new Cart[]
            {
                new Cart {UserId = 1, TotalAmount = 0, TotalProductCount = 0, Status = Enums.Status.Created, CreatedUser = 1, CreatedDate = DateTime.Now, UpdatedUser = 1, UpdatedDate = DateTime.Now},
                new Cart {UserId = 2, TotalAmount = 0, TotalProductCount = 0, Status = Enums.Status.Created, CreatedUser = 1, CreatedDate = DateTime.Now, UpdatedUser = 1, UpdatedDate = DateTime.Now},
                new Cart {UserId = 3, TotalAmount = 0, TotalProductCount = 0, Status = Enums.Status.Created, CreatedUser = 1, CreatedDate = DateTime.Now, UpdatedUser = 1, UpdatedDate = DateTime.Now},
            };

            context.AddRange(carts);
            context.SaveChanges();

        }
    }
}
