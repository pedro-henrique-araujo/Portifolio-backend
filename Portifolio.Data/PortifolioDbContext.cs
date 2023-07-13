using Microsoft.EntityFrameworkCore;

namespace Portifolio.Data
{
    public class PortifolioDbContext : DbContext
    {
        public PortifolioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}