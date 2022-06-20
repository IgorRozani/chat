using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Core.Stocks
{
    public class StockInfo
    {
        [Name("Symbol")]
        public string? StockCode { get; set; }
        [Name("Date")]
        public DateTime Date { get; set; }
        [Name("Time")]
        public TimeSpan Time { get; set; }
        [Name("Open")]
        public decimal PriceOpen { get; set; }
        [Name("High")]
        public decimal PriceHigh { get; set; }
        [Name("Low")]
        public decimal PriceLow { get; set; }
        [Name("Close")]
        public decimal PriceClose { get; set; }
        [Name("Volume")]
        public int Volume { get; set; }
    }
}
