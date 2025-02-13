using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wasla.Models;

namespace Wasla.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Ensure roles exist
            var roles = new[] { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Ensure admin user exists
            var adminEmail = "admin@wasla.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Seed Governments, Regions, and Available Regions
            if (!context.Governments.Any())
            {
                var governments = new List<Government>
                {
                    new Government
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Cairo",
                        Regions = new List<Region>
                        {
                            new Region
                            {
                                Id = Guid.NewGuid().ToString(),
                                Name = "Nasr City",
                                AvailableRegions = new List<AvailableRegion>
                                {
                                    new AvailableRegion
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        Name = "Downtown",
                                        Description = "Take bus 356 or Metro Line 1."
                                    }
                                }
                            },
                            new Region
                            {
                                Id = Guid.NewGuid().ToString(),
                                Name = "Heliopolis",
                                AvailableRegions = new List<AvailableRegion>
                                {
                                    new AvailableRegion
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        Name = "Korba",
                                        Description = "Take bus 111 or Metro Line 3."
                                    }
                                }
                            }
                        }
                    },
                    new Government
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Giza",
                        Regions = new List<Region>
                        {
                            new Region
                            {
                                Id = Guid.NewGuid().ToString(),
                                Name = "Dokki",
                                AvailableRegions = new List<AvailableRegion>
                                {
                                    new AvailableRegion
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        Name = "Mohandessin",
                                        Description = "Take bus 200 or Metro Line 2."
                                    }
                                }
                            },
                            new Region
                            {
                                Id = Guid.NewGuid().ToString(),
                                Name = "6th of October",
                                AvailableRegions = new List<AvailableRegion>
                                {
                                    new AvailableRegion
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        Name = "Sheikh Zayed",
                                        Description = "Take bus 500 or Metro Line 4."
                                    }
                                }
                            }
                        }
                    }
                };

                context.Governments.AddRange(governments);
                await context.SaveChangesAsync();
            }
        }
    }
}
