namespace DAL.Models
{
    public class CMSPermission
    {
        public int FunctionId { get; set; }

        public CMSFunction CMSFunction {get;set;}

        public int BelongToId { get; set; }

        /// <summary>
        /// 權限類型 - 人員/角色
        /// </summary>
        public byte IdentityType { get; set; }


    }

}