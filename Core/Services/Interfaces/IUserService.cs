
using Core.Models.DTO;

namespace Core.Services.Interfaces
{
    public interface IUserService
    {
        PersonAccount GetPersonAccountById(int AccountId);
        PersonAccount GetUserAccountByAccount(string account);
        bool IsValidUserCredentials(string account, string pwd);
    }
}