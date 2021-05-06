using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class WithdrawScheduleSetting
    {
        public int Id { get; set; }

        [ForeignKey("JuristicAccount")]
        public int JuristicAccountId { get; set; }

        public byte TimeSpanSetting { get; set; }

        public byte SettlePolicy { get; set; }

        public int WithdrawDay { get; set; }

        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdateBy { get; set; }



    }

}
