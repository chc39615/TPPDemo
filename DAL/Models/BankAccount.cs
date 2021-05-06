using DAL.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BankAccount : AccountBase
    {

        [ForeignKey("JuristicAccount")]
        public int JuristicAccountId { get; set; }
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
        public string BankName { get; set; }
        public byte ACHStatus { get; set; }
        public bool IsDefault { get; set; }
        public string Description { get; set; }
    }

}
