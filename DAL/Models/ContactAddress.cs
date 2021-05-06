using DAL.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ContactAddress : ContactBase
    {
        [MaxLength(50)]
        public string Country { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PostCode { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
    }
}