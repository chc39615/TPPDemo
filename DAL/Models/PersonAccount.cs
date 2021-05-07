using DAL.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PersonAccount : AccountBase
    {

        [Required]
        [MaxLength(5)]
        public string FirstName {get;set;}

        [Required]
        [MaxLength(5)]
        public string LastName {get;set;}

        public override byte AccountType => 1;

    }
}