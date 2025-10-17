using Microsoft.EntityFrameworkCore;

namespace autotrader.Models
{
    public class CarDbContext : DbContext
    {
        public CarDbContext()
        {

        }

        public CarDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server = localhost;database=autotrader;user=root;password=;sslMode=None");
        }
    }
}
