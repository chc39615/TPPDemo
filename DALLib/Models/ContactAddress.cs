using System;
using DAL.Models.BaseModels;

namespace DAL.Models
{
    public class ContactAddress : ContactBase
    {
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}