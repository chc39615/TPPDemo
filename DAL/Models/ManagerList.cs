namespace DAL.Models
{
    public class ManagerList
    {
        public int OrganizationId { get; set; }
        public JuristicAccount Organization { get; set; }
        public int ManagerId { get; set; }
        public PersonAccount Manager { get; set; }
        public byte Role { get; set; }
    }
}
