using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LuxeLoft.Server.Data.Identity;

namespace LuxeLoft.Server.Data.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<IdentityRole> IdentityRoles { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
    }
}
