using DAL.Models.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class StaffAccount : AccountBase
    {

        [Required]
        [MaxLength(5)]
        public string FirstName {get;set;}

        [Required]
        [MaxLength(5)]
        public string LastName {get;set;}

        public override byte AccountType => 1;

        public ICollection<CMSPermission> Permissions { get; set; }

    }
}