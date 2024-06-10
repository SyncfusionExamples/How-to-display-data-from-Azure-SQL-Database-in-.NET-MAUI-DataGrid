using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Model
{
    public class Stocks
    {
        public int Id { get; set; }

        public string? Ticker { get; set; }

        public string? CompanyName { get; set; }

        public decimal LastPrice { get; set; }

        public decimal Change { get; set; }

        public decimal ChangePercent { get; set; }

        public decimal OpenColumn { get; set; }

        public decimal HighColumn { get; set; }

        public decimal LowColumn { get; set; }

        public long Volume { get; set; }

        public decimal MarketCap { get; set; }
    }
}
