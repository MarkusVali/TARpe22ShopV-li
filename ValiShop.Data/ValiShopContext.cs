using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValiShop.Core.Domain;

namespace ValiShop.Data
{
    public class ValiShopContext : DbContext
    {
        public ValiShopContext(DbContextOptions<ValiShopContext> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<CarFileToDatabase> CarFilesToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToApi> FilesToApi { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
