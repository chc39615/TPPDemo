using AutoMapper;
using Core.Models.DTO;
using Core.Providers.Interfaces;
using DAL.Contexts.Interfaces;
using System.Linq;

namespace Core.Providers
{
    public class AccountProvider : IAccountProvider
    {
        private readonly ITPPContext tppContext;

        private readonly IMapper mapper;
        public AccountProvider(ITPPContext pTPPContext, IMapper pMapper)
        {
            tppContext = pTPPContext;
            mapper = pMapper;
        }

        PersonAccount IAccountProvider.GetPersonAccountByAccount(string account)
        {
            var queryable = tppContext.StaffAccounts.Where(p => p.Account == account);

            var user = mapper.ProjectTo<PersonAccount>(queryable).FirstOrDefault();

            return user;
        }

        PersonAccount IAccountProvider.GetPersonAccountByAccountId(int accountId)
        {
            var user = tppContext.StaffAccounts.Find(accountId);

            return mapper.Map<PersonAccount>(user);
        }
    }
}
