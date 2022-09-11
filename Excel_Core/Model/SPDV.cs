using ExcelMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Core.Model
{
    public class SPDV
    {
        [ExcelColumnName("No")]
        public int No { get; set; }

        [ExcelColumnName("GroupCode")]
        public string GroupCode { get; set; }

        [ExcelColumnName("CompanyCode")]
        public string CompanyCode { get; set; }

        [ExcelColumnName("KBC_type")]
        public string KBC_type { get; set; }

        [ExcelColumnName("KBC_date")]
        public string KBC_date { get; set; }

        [ExcelColumnName("Dimension")]
        public string Dimension { get; set; }

        [ExcelColumnName("InvestmentType")]
        public string InvestmentType { get; set; }

        [ExcelColumnName("CarryForward")]
        public int CarryForward { get; set; }

        [ExcelColumnName("Plan")]
        public  int Plan { get; set; }

        [ExcelColumnName("InDue")]
        public int InDue { get; set; }

        [ExcelColumnName("Due")]
        public int Due { get; set; }

        [ExcelColumnName("NotImplement")]
        public int NotImplement { get; set; }
    }
}
