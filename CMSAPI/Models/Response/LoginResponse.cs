using CMSAPI.JWT.Models;
using Core.Models.DTO;

namespace CMSAPI.Models.Response
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Account { get; set; }

        public LoginResponse(PersonAccount user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Account = user.Account;
        }
    }
}
