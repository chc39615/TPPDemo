namespace DAL.Models
{
    public class CMSPermission
    {
        public int FunctionId { get; set; }
        public CMSFunction CMSFunction { get; set; }
        public int AccountId { get; set; }
        public PersonAccount Account { get; set; }

    }

}