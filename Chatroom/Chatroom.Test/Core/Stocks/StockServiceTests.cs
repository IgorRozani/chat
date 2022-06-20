using Chatroom.Core.Stocks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chatroom.Test.Core.Stocks
{
    public class StockServiceTests
    {
        private readonly StockService stockService;

        public StockServiceTests()
        {
            var configurations = new Dictionary<string, string>
            {
                { "Stooq", "https://stooq.com/q/l/?s={0}&f=sd2t2ohlcv&h&e=csv" }
            };
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configurations)
                .Build();
            stockService = new StockService(configuration);
        }

        [Fact]
        public void DownloadFile()
        {
            var stock = stockService.GetStock("AAPL.US");

            Assert.NotNull(stock);
        }
    }
}
