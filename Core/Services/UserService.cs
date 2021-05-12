using Core.Models.DTO;
using Core.Providers.Interfaces;
using Core.Services.Interfaces;

namespace Core.Services
{

    public class UserService : IUserService
    {

        private readonly IAccountProvider accountProvider;


        public UserService(IAccountProvider pAccountProvider)
        {
            accountProvider = pAccountProvider;
        }

        public PersonAccount GetUserAccountByAccount(string account)
        {
            var user = accountProvider.GetPersonAccountByAccount(account);

            return user;

        }

        public bool IsValidUserCredentials(string account, string pwd)
        {
            if (string.IsNullOrWhiteSpace(account))
                return false;

            if (string.IsNullOrWhiteSpace(pwd))
                return false;

            var user = accountProvider.GetPersonAccountByAccount(account);

            if (user == null)
                return false;

            return true;
        }

        public PersonAccount GetPersonAccountById(int accountId)
        {
            var user = accountProvider.GetPersonAccountByAccountId(accountId);

            return user;
        }

    }
}
