using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class OrderFees
    {
        public Int64 Id { get; set; }

        [ForeignKey("Order")]
        public Int64 OrderId { get; set; }

        public string FeeType { get; set; }

        public decimal Percentage { get; set; }
    }
}
