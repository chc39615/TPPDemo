namespace DAL.Models
{
    public class CMSPermission
    {
        public int FunctionId { get; set; }

        public CMSFunction CMSFunction {get;set;}

        public int BelongToId { get; set; }

        /// <summary>
        /// �v������ - �H��/����
        /// </summary>
        public byte IdentityType { get; set; }


    }

}