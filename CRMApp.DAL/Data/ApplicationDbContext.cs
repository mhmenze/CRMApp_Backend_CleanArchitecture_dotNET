using CRMApp.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMApp.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<User> Users => Set<User>();

    }
}