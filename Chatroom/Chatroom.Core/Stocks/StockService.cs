using CsvHelper;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Net;

namespace Chatroom.Core.Stocks
{
    public interface IStockService
    {
        StockInfo GetStock(string stockCode);
    }

    public class StockService : IStockService
    {
        private readonly IConfiguration configuration;
        private string StooqUrl { get { return configuration["Stooq"]; } }

        public StockService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public StockInfo GetStock(string stockCode)
        {
            StockInfo? stockInfo;
            var client = new WebClient();
            var csvFile = client.DownloadData(string.Format(StooqUrl, stockCode));

            using (var memoryStream = new MemoryStream(csvFile))
            using (var streamReader = new StreamReader(memoryStream))
            using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                var records = csvReader.GetRecords<StockInfo>().ToList();
                stockInfo = records.FirstOrDefault();
            }

            return stockInfo;
        }
    }
}
