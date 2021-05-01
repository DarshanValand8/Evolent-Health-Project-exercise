using CoreApplication.Entities;
using CoreApplication.Interfaces.IDBContext;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.DBContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact()
                {
                    Id = 1,
                    FirstName = "Darshan",
                    LastName = "Valand",
                    Email = "defaultMail@gmail.com",
                    PhoneNumber = "9999999999",
                    Status = true
                });
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
