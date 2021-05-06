using System;
using DAL.Models.BaseModels;

namespace DAL.Models
{
    public class ContactPhone : ContactBase
    {
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}