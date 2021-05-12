using System.ComponentModel.DataAnnotations;

namespace CMSAPI.Models.Request
{
    public class LoginRequest
    {
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
