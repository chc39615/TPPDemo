using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Models
{
    public class Order
    {
        public Int64 Id { get; set; }
        public int MerchantId { get; set; }
        public string MerchantOrderNo { get; set; }
        public string PostBackUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiredTime { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public ICollection<OrderFees> Fees { get; set; }
        public decimal TaxRate { get; set; }
        public OrderTransaction Transaction { get; set; }
        public string Content { get; set; }
        public byte Status { get; set; }
        public int TotalAmount
        {
            get
            {
                var itemPriceTotal = 0;
                Items.ToList().ForEach(x => itemPriceTotal += x.ItemPrice);

                // 計算稅金
                var tax = itemPriceTotal * TaxRate;

                // 計算手續費
                decimal fee = 0;
                Fees.ToList().ForEach(x => fee += itemPriceTotal * x.Percentage);

                return (int)Math.Round(itemPriceTotal + fee + tax);
            }
        }
    }
}
