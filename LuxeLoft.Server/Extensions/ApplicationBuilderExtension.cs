using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Models.Carts;
using LuxeLoft.Server.Data.Models.Products;
using LuxeLoft.Server.Data.Models.Users;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace LuxeLoft.Server.Extension
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            ApplicationDbContext _context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            using HttpClient client = new();

            // Seed users
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

                        _context.Add(newUser);
                    }

                    _context.SaveChanges();
                }
            }
            else
            {
                Debug.WriteLine($"Error: {usersResponse.StatusCode} - {usersResponse.ReasonPhrase}");
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
                Debug.WriteLine($"Error: {cartsResponse.StatusCode} - {cartsResponse.ReasonPhrase}");
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

                        _context.Add(newProduct);
                    }

                    _context.SaveChanges();
                }
            }
            else
            {
                Debug.WriteLine($"Error: {productsResponse.StatusCode} - {productsResponse.ReasonPhrase}");
            }

            return app;
        }
    }
}
