using System;

namespace DAL.Models
{
    public class CMSRole
    {
        public int Id {get;set;}
        public string RoleName {get;set;}
        public string Description {get;set;}
        public DateTime CreateDate {get;set;}
        public int CreateBy {get;set;}

    }
}