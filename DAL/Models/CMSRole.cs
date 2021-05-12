using DAL.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class CMSRole : StatefulBase
    {
        [MaxLength(30)]
        public string RoleName {get;set;}

        [MaxLength(200)]
        public string Description {get;set;}

    }
}