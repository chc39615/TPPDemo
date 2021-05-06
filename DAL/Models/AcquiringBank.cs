using System;

namespace DAL.Models
{
    public class AcquiringBank
    {
        public int Id { get; set; }
        public int BankCode { get; set; }
        public string BankName { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpDateBy { get; set; }
    }
}
