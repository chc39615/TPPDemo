using DAL.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Core.Providers
{
    public class PermissionProvider
    {

        private readonly ITPPContext tPPContext;

        public PermissionProvider(ITPPContext pTPPContext)
        {
            tPPContext = pTPPContext;
        }

        public bool PersonHasPermission(int accountId, string entry)
        {
            var account = tPPContext.StaffAccounts.Include(a => a.Permissions).FirstOrDefault(a => a.Id == accountId);

            foreach (var functions in account.Permissions)
            {
                if (functions.CMSFunction.ControllerName == entry)
                    return true;

            }
            return false;
        }

    }
}
