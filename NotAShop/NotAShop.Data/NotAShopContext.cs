using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotAShop.Core.Domain;
using System.Xml;

namespace NotAShop.Data
{
    public class NotAShopContext : IdentityDbContext<ApplicationUser>
    {
        public NotAShopContext(DbContextOptions<NotAShopContext> options)
            : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<Kindergarten> Kindergartens{ get; set; }

        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }
        public DbSet<ImageToDatabase> ImageToDatabases { get; set; }
        public DbSet<IdentityRole> IdentiyRoles { get; set; }

    }
}
