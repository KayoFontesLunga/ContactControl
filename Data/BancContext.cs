using ContactControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactControl.Data
{
    public class BancContext : DbContext
    {
        public BancContext(DbContextOptions<BancContext> options)
            : base(options)
        {
        }
        public DbSet<ContactModel> Contacts { get; set; }
    }
}
