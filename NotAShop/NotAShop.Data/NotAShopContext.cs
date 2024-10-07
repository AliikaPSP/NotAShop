using Microsoft.EntityFrameworkCore;
using NotAShop.Core.Domain;
using System.Xml;

namespace NotAShop.Data
{
    public class NotAShopContext : DbContext
    {
        public NotAShopContext(DbContextOptions<NotAShopContext> options)
            : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        public DbSet<Kindergarten> Kindergartens{ get; set; }

        public DbSet<RealEstate> RealEstates { get; set; }

    }
}
