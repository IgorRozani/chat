using CsvHelper;
using System.Globalization;
using System.Net;

namespace Chatroom.Core.Stocks
{
    internal class StockService
    {
        public StockInfo GetStock(string stockCode)
        {
            StockInfo stockInfo;
            var client = new WebClient();
            var csvFile = client.DownloadData($"https://stooq.com/q/l/?s={stockCode}&f=sd2t2ohlcv&h&e=csv");

            using (var reader = new MemoryStream(csvFile))
            using (var reader2 = new StreamReader(reader))
            using (var csv = new CsvReader(reader2, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StockInfo>().ToList();
                stockInfo = records[0];
            }

            return stockInfo;
        }
    }
}
