using DAL.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class CMSFunction : StatefulBase
    {
        public int ParentFunctionId { get; set; }

        [MaxLength(30)]
        public string FunctionName { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ControllerName { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ActionName { get; set; }
    }

}