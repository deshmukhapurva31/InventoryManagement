using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class SeedData
    {

        public static async Task InitailizeAsync(IServiceProvider services)
        {
            //await AddTestUsers(
            //    services.GetRequiredService<RoleManager<UserRoleEntity>>(),
            //    services.GetRequiredService<UserManager<UserEntity>>()
            //    );
            await AddTestData(services.GetRequiredService<InventoryApiDbContext>());
        }
        public static async Task AddTestData(InventoryApiDbContext context)
        {
            if (context.Products.Any())
                return;

            context.Products.Add(new ProductEntity
            {
                ProductId = new Guid("48bc3a3d-a663-45fe-8c72-0f32409f8e17"),
                Name="T-shirt",
                Category="Mens",
                Color="Red",
                UnitPrice=300,
                AvailableQuantity=25
            });

            context.Products.Add(new ProductEntity
            {
                ProductId = new Guid("8694027c-1c44-4b1b-919b-f63a22897fed"),
                Name = "Trousers",
                Category = "Mens",
                Color = "Black",
                UnitPrice = 500,
                AvailableQuantity = 10
            });

            context.Products.Add(new ProductEntity
            {
                ProductId = new Guid("0e771888-ffc6-49ef-bba4-783f4345a0f6"),
                Name = "Kurta",
                Category = "Womens",
                Color = "Yellow",
                UnitPrice = 800,
                AvailableQuantity = 15
            });

            context.Products.Add(new ProductEntity
            {
                ProductId = new Guid("5d1bfa94-8d97-421e-9b84-16cc65bd69db"),
                Name = "Saree",
                Category = "Womens",
                Color = "Blue",
                UnitPrice = 1500,
                AvailableQuantity = 5
            });

            await context.SaveChangesAsync();
        }

        private static async Task AddTestUsers(
             RoleManager<UserRoleEntity> roleManager,
             UserManager<UserEntity> userManager)
        {
            var dataExists = roleManager.Roles.Any() || userManager.Users.Any();
            if (dataExists)
            {
                return;
            }

            UserRoleEntity role = new UserRoleEntity("Admin");
            role.Id = Guid.NewGuid();

            // Add a test role
            await roleManager.CreateAsync(role);

            // Add a test user
            var user = new UserEntity
            {
                Email = "admin@landon.local",
                UserName = "admin@landon.local",
                FirstName = "Admin",
                LastName = "Tester",
                CreatedAt = DateTimeOffset.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid()
            };

            await userManager.CreateAsync(user, "Test123");

            // Put the user in the admin role
            await userManager.AddToRoleAsync(user, "Admin");
            //await userManager.UpdateAsync(user);
        }
    }
}
