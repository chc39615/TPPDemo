using System;

namespace DAL.Models
{
    public class MessageBoard
    {
        public int Id { get; set; }
        public bool StickTop { get; set; }
        public byte Category { get; set; }
        public byte Importance { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime UpdateBy { get; set; }
        public byte Status { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int ApproveBy { get; set; }


    }
}
