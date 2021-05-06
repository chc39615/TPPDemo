using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.BaseModels
{
    public abstract class AccountBase
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Account { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UpdateBy { get; set; }

        public byte Status { get; set; }

        public virtual byte AccountType { get; }

        public ICollection<ContactAddress> Addresses { get; set; }
        public ICollection<ContactPhone> Phones { get; set; }
        public ICollection<ContactEmail> Emails { get; set; }

    }
}