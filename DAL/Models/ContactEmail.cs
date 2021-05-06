using DAL.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ContactEmail : ContactBase
    {
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }
    }

}