using LuxeLoft.Server.Data.Models;
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
        ///// <summary>
        ///// The carts in the database.
        ///// </summary>
        //public DbSet<Cart> Cart { get; set; }
        ///// <summary>
        ///// The users in the database.
        ///// </summary>
        //public DbSet<User> Users { get; set; }
    }
}
