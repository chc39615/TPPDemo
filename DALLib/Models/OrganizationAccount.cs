using System;
using DAL.Models.BaseModels;

namespace DAL.Models
{
    public class OrganizationAccount : AccountBase
    {
        public string Account { get; set; }
        public string CompanyName { get; set; }

    }
}