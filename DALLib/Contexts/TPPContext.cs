using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts
{
    public class TPPContext : DbContext
    {
        public TPPContext(DbContextOptions<TPPContext> options) : base(options)
        { }

        public DbSet<PersonAccount> PersonAccounts { get; set; }
        public DbSet<OrganizationAccount> OrganizationAccounts { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }
        public DbSet<ContactEmail> ContactEmails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TPP");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonAccount>()
                .HasMany(s => s.Addresses)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, OwnerType = 1 });

            builder.Entity<OrganizationAccount>()
                .HasMany(s => s.Addresses)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, OwnerType = 2 });
        }
    }
}