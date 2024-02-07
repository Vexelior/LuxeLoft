using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Identity;
using LuxeLoft.Server.Data.Models.Carts;
using LuxeLoft.Server.Data.Models.Products;
using LuxeLoft.Server.Data.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LuxeLoft.Server.Extension
{
    using BCrypt.Net;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            ApplicationDbContext _context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            IdentityContext _identityContext = serviceScope.ServiceProvider.GetRequiredService<IdentityContext>();
            UserManager<ApplicationUser> _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            _context.Database.Migrate();

            // Seed roles
            if (!_identityContext.Roles.Any())
            {
                List<IdentityRole> roles =
                [
                    new IdentityRole { Name = "HeadAdmin", NormalizedName = "HEADADMIN", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
                    new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
                    new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE", ConcurrencyStamp = Guid.NewGuid().ToString("D") },
                ];

                foreach (IdentityRole role in roles)
                {
                    IdentityResult result = _roleManager.CreateAsync(role).Result;

                    if (result.Succeeded)
                    {
                        Console.WriteLine($"Created role '{role.Name}'.");
                    }
                    else
                    {
                        throw new Exception($"Error creating role '{role.Name}'.");
                    }
                }
            }

            // Seed users
            using HttpClient client = new();
            HttpResponseMessage usersResponse = client.GetAsync("https://fakestoreapi.com/users").Result;

            if (usersResponse.IsSuccessStatusCode)
            {
                string usersContent = usersResponse.Content.ReadAsStringAsync().Result;

                List<User> users = JsonConvert.DeserializeObject<List<User>>(usersContent);

                if (!_context.Products.Any())
                {
                    foreach (User user in users)
                    {
                        User newUser = new()
                        {
                            Email = user.Email,
                            Name = user.Name,
                            Address = user.Address,
                            Username = user.Username,
                            Password = user.Password,
                            FirstName = user.Name.FirstName,
                            LastName = user.Name.FirstName,
                            City = user.Address.City,
                            Street = user.Address.Street,
                            Number = user.Address.Number,
                            Zipcode = user.Address.Zipcode,
                            Lat = user.Address.Geolocation.Lat,
                            Long = user.Address.Geolocation.Long,
                            Phone = user.Phone
                        };

                        newUser.Password = BCrypt.EnhancedHashPassword(newUser.Password);

                        _context.Add(newUser);

                        ApplicationUser applicationUser = new()
                        {
                            UserName = newUser.Username,
                            Email = newUser.Email,
                            PhoneNumber = newUser.Phone,
                            EmailConfirmed = true,
                            FirstName = newUser.FirstName,
                            LastName = newUser.LastName,
                            SecurityStamp = Guid.NewGuid().ToString("D"),
                            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false
                        };

                        IdentityResult result = _userManager.CreateAsync(applicationUser, newUser.Password).Result;

                        if (result.Succeeded)
                        {
                            _userManager.AddToRoleAsync(applicationUser, "Customer").Wait();
                        }
                        else
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        _context.SaveChanges();
                        _identityContext.SaveChanges();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: {usersResponse.StatusCode} - {usersResponse.ReasonPhrase}");
            }

            // Seed carts
            HttpResponseMessage cartsResponse = client.GetAsync("https://fakestoreapi.com/carts").Result;

            if (cartsResponse.IsSuccessStatusCode)
            {
                string cartsContent = cartsResponse.Content.ReadAsStringAsync().Result;

                List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(cartsContent);

                if (!_context.Carts.Any())
                {
                    foreach (Cart cart in carts)
                    {
                        Cart newCart = new()
                        {
                            UserId = cart.UserId,
                            Date = cart.Date,
                            Products = cart.Products,
                            __v = cart.__v
                        };

                        _context.Add(newCart);
                    }

                    _context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine($"Error: {cartsResponse.StatusCode} - {cartsResponse.ReasonPhrase}");
            }

            // Seed products
            HttpResponseMessage productsResponse = client.GetAsync("https://fakestoreapi.com/products").Result;

            if (productsResponse.IsSuccessStatusCode)
            {
                string productsContent = productsResponse.Content.ReadAsStringAsync().Result;

                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsContent);

                if (!_context.Products.Any())
                {
                    foreach (Product product in products)
                    {
                        Product newProduct = new()
                        {
                            Title = product.Title,
                            Price = product.Price,
                            Category = product.Category,
                            Description = product.Description,
                            Image = product.Image,
                            Ratings = product.Ratings
                        };

                        string imageName = newProduct.Image.Split("/").Last();
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "Client", "Images", imageName);
                        byte[] image = client.GetByteArrayAsync(newProduct.Image).Result;

                        if (!File.Exists(path))
                        {
                            File.WriteAllBytes(path, image);
                        }

                        newProduct.Image = imageName;

                        _context.Add(newProduct);
                        _context.SaveChanges();
                    }

                }
            }
            else
            {
                Console.WriteLine($"Error: {productsResponse.StatusCode} - {productsResponse.ReasonPhrase}");
            }

            return app;
        }
    }
}
