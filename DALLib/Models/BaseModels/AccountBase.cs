using System;
using System.Collections.Generic;

namespace DAL.Models.BaseModels
{
    public abstract class AccountBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdateBy { get; set; }
        public int Status { get; set; }

        public ICollection<ContactAddress> Addresses { get; set; }
        public ICollection<ContactPhone> Phones { get; set; }
        public ICollection<ContactEmail> Emails { get; set; }

    }
}