using LuxeLoft.Server.Data.Models.Carts;
using LuxeLoft.Server.Data.Models.Products;
using LuxeLoft.Server.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace LuxeLoft.Server.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// The products in the database.
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// The carts in the database.
        /// </summary>
        public DbSet<Cart> Carts { get; set; }
        /// <summary>
        /// The users in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /*
         * 
         * Relationships between the entities in the database.
         * 
         */

        /// <summary>
        /// The products ratings in the database.
        /// </summary>
        public DbSet<ProductRatings> ProductRatings { get; set; }
        /// <summary>
        /// The products in carts.
        /// </summary>
        public DbSet<CartProducts> CartProducts { get; set; }

    }
}
