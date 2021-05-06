using System;

namespace DAL.Models.BaseModels
{
    public abstract class ContactBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdateBy { get; set; }
        public int Status { get; set; }
        public int OwnerType { get; set; }
        public int OwnerID { get; set; }
        public AccountBase Account {get;set;}

    }
}