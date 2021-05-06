using System;
using DAL.Models.BaseModels;

namespace DAL.Models
{
    public class PersonAccount : AccountBase
    {
        public string Account{get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }
}