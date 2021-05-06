namespace DAL.Models
{
    public class CMSFunction
    {
        public int Id { get; set; }
        public string Entry { get; set; }
        public byte MethodType { get; set; }
        public string FunctionName { get; set; }
        public byte FunctionType { get; set; }
        public int ParentId { get; set; }
    }

}