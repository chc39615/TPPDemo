using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts.Interfaces
{
    public interface ITPPContext
    {
        DbSet<ContactAddress> ContactAddresses { get; set; }
        DbSet<ContactEmail> ContactEmails { get; set; }
        DbSet<ContactPhone> ContactPhones { get; set; }
        DbSet<ManagerList> ManagerList { get; set; }
        DbSet<MerchantAccount> MerchantAccounts { get; set; }
        DbSet<OrderFees> OrderFees { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderTransaction> OrderTransactions { get; set; }
        DbSet<StaffAccount> StaffAccounts { get; set; }
        DbSet<CMSPermission> CMSPermissions { get; set; }
    }
}