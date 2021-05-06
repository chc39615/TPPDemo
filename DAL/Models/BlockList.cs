using System;

namespace DAL.Models
{
    public class BlockList
    {
        public int Id { get; set; }
        public byte ItemType { get; set; }
        public string Content { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public byte Status { get; set; }
    }
}
