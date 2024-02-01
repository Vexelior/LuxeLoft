using LuxeLoft.Server.Data.Context;
using LuxeLoft.Server.Data.Models;
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
            HttpResponseMessage response =  client.GetAsync("https://fakestoreapi.com/products").Result;

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(content);

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
                        };

                        _context.Add(newProduct);

                        _context.SaveChanges();

                    }
                }

                // TODO: Add more seed data for cart and user
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
            return app;
        }
    }
}
