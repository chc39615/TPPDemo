using System;

namespace DAL.Models.BaseModels
{
    public abstract class StatefulBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public byte Status { get; set; }
    }
}
