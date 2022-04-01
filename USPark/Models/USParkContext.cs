using Microsoft.EntityFrameworkCore;

namespace USPark.Models
{
    public class USParkContext : DbContext
    {
        public USParkContext(DbContextOptions<USParkContext> options)
            : base(options)
        {
        }
        public DbSet<Park> Parks { get; set; }
    }
}