using DAL.Contexts.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Contexts
{
    public class TPPContext : DbContext, ITPPContext
    {
        public TPPContext() : base()
        { }
        public TPPContext(DbContextOptions<TPPContext> options) : base(options)
        { }

        public DbSet<StaffAccount> StaffAccounts { get; set; }
        public DbSet<MerchantAccount> MerchantAccounts { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }
        public DbSet<ContactEmail> ContactEmails { get; set; }
        public DbSet<ManagerList> ManagerList { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderFees> OrderFees { get; set; }
        public DbSet<OrderTransaction> OrderTransactions { get; set; }
        public DbSet<CMSPermission> CMSPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TPP;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<StaffAccount>()
                .HasMany(s => s.Addresses)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, p.OwnerType })
                .HasPrincipalKey(p => new { p.Id, p.AccountType });

            builder.Entity<MerchantAccount>()
                .HasMany(s => s.Addresses)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, p.OwnerType })
                .HasPrincipalKey(p => new { p.Id, p.AccountType });

            builder.Entity<StaffAccount>()
                .HasMany(s => s.Emails)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, p.OwnerType })
                .HasPrincipalKey(p => new { p.Id, p.AccountType });

            builder.Entity<MerchantAccount>()
                .HasMany(s => s.Emails)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, p.OwnerType })
                .HasPrincipalKey(p => new { p.Id, p.AccountType });

            builder.Entity<StaffAccount>()
                .HasMany(s => s.Phones)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, p.OwnerType })
                .HasPrincipalKey(p => new { p.Id, p.AccountType });

            builder.Entity<MerchantAccount>()
                .HasMany(s => s.Phones)
                .WithOne()
                .HasForeignKey(p => new { p.OwnerID, p.OwnerType })
                .HasPrincipalKey(p => new { p.Id, p.AccountType });


            builder.Entity<ManagerList>()
                .HasKey(om => new { om.OrganizationId, om.ManagerId });

            builder.Entity<CMSRoleMember>()
                .HasKey(rm => new { rm.AccountId, rm.RoleId });

            builder.Entity<CMSPermission>()
                .HasKey(p => new { p.FunctionId, p.BelongToId, p.IdentityType });


            // 初始化資料庫
            builder.Entity<StaffAccount>().HasData(
               new StaffAccount { Id = 1, Account = "admin", FirstName = "管理", LastName = "員", CreateDate = DateTime.Now, CreateBy = 1, Status = 1 }
            );
        }
    }
}