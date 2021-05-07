using DAL.Models.BaseModels;

namespace DAL.Models
{
    public class MerchantAccount : AccountBase
    {
        public string RegisterNameE { get; set; }
        public string RegisterNameC { get; set; }
        public string DisplayNameE { get; set; }
        public string DisplayNameC { get; set; }
        public string TaxNumber { get; set; }
        public int AnnualRevenue { get; set; }
        public int EquityCapital { get; set; }
        public int EmployeeCount { get; set; }
        public string ProxyName { get; set; }
        public string ProxyIDNumber { get; set; }
        public string ProxyNation { get; set; }

        /// <summary>
        /// 個人商家/一般商家
        /// </summary>
        public byte MerchantAccountType { get; set; }
        public override byte AccountType => 2;

    }
}