using Microsoft.EntityFrameworkCore;

namespace USParkAPI.Models {
    public class USParkAPIContext : DbContext {
        public USParkAPIContext(DbContextOptions<USParkAPIContext> options)
            : base(options) {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Park>()
                .HasData(
                    new Park { ParkId = 1, Name = "Yellowstone", City = "Cody", State = "Wyoming", ManagedBy = "National Park Service", Activities = "lots", Amenities = "lots", ADA = true },
                    new Park { ParkId = 2, Name = "Yellowstone", City = "Gardiner", State = "Montana", ManagedBy = "National Park Service", Activities = "lots", Amenities = "lots", ADA = true },
                    new Park { ParkId = 3, Name = "Grand Teton", City = "Jackson", State = "Wyoming", ManagedBy = "National Park Service", Activities = "hiking, camping", Amenities = "lots", ADA = true },
                    new Park { ParkId = 4, Name = "Molalla River Recreation Area", City = "Molalla", State = "Oregon", ManagedBy = "Bureau of Land Management", Activities = "fishing", Amenities = "restrooms", ADA = true },
                    new Park { ParkId = 5, Name = "Forest Park", City = "Portland", State = "Oregon", ManagedBy = "Portland Parks and Recreation", Activities = "trail running", Amenities = "", ADA = true }
        );
        }
        public DbSet<Park> Parks { get; set; }
    }
}