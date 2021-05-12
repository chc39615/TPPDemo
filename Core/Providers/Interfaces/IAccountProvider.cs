
using Core.Models.DTO;

namespace Core.Providers.Interfaces
{
    public interface IAccountProvider
    {
        PersonAccount GetPersonAccountByAccount(string account);
        PersonAccount GetPersonAccountByAccountId(int accountId);
    }
}