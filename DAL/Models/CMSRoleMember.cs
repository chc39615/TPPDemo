namespace DAL.Models
{
    public class CMSRoleMember
    {
        public int RoleId {get;set;}
        public CMSRole CMSRole {get;set;}
        public int AccountId {get;set;}
        public PersonAccount PersonAccount {get;set;}
    }
    
}