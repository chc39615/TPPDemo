using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class OrderTransaction
    {
        public Int64 Id { get; set; }

        [ForeignKey("Order")]
        public Int64 OrderId { get; set; }

        public byte Status { get; set; }

        public int Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Content { get; set; }
    }
}
