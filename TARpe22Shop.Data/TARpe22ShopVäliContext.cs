using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVäli.Core.Domain;

namespace TARpe22ShopVäli.Data
{
    public class TARpe22ShopVäliContext : DbContext
    {
        public TARpe22ShopVäliContext(DbContextOptions<TARpe22ShopVäliContext> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<CarFileToDatabase> CarFilesToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToApi> FilesToApi { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
