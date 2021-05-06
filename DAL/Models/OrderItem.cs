using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class OrderItem
    {
        public Int64 Id { get; set; }

        [ForeignKey("Order")]
        public Int64 OrderId { get; set; }

        public string ItemName { get; set; }

        public int ItemPrice { get; set; }

        public int ItemQuantity { get; set; }

        public string Description { get; set; }
    }
}
