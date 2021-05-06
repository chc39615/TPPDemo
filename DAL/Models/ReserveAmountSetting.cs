using System;

namespace DAL.Models
{
    public class ReserveAmountSetting
    {
        public int Id { get; set; }
        public string TaxNumber { get; set; }
        public int ReserveAmount { get; set; } 
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateBy { get; set; }
        public byte Status { get; set; }
        public string Description { get; set; }
    }
}
