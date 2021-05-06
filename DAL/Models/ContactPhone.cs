using System;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.BaseModels;

namespace DAL.Models
{
    public class ContactPhone : ContactBase
    {
        [Column(TypeName = "varchar(10)")]
        public string CountryCode { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string AreaCode { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PhoneNumber { get; set; }
    }
}