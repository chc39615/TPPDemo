using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CustomBlockList
    {
        public int Id { get; set; }
        public int JuristicAccountId { get; set; }
        public byte ItemType { get; set; }
        public string Content { get; set; }
        public string Reason { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateBy { get; set; }
        public byte Status { get; set; }

    }
}
