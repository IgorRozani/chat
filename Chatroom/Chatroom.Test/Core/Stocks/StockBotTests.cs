using Chatroom.Core.Stocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chatroom.Test.Core.Stocks
{
    public class StockBotTests
    {
        private readonly StockBot stockBot;
        private readonly Mock<IStockService> stockServiceMock;

        public StockBotTests()
        {
            stockServiceMock = new Mock<IStockService>();
            stockBot = new StockBot(stockServiceMock.Object);
        }

        [Fact]
        public void GetStock_Success()
        {
            stockServiceMock.Setup(s => s.GetStock(It.IsAny<string>())).Returns(new StockInfo { StockCode = "AAPL.US", PriceClose = 95.99m });
            
            var stockMessage = stockBot.GetStock("AAPL.US");

            Assert.Equal("AAPL.US quote is $95.99 per share.", stockMessage);
        }

        [Fact]
        public void GetStock_StockNull()
        {
            stockServiceMock.Setup(s => s.GetStock(It.IsAny<string>())).Returns((StockInfo)null);

            var stockMessage = stockBot.GetStock("AAPL.US");

            Assert.Equal("Stock not found.", stockMessage);
        }

        [Fact]
        public void GetStock_StockServiceException()
        {
            stockServiceMock.Setup(s => s.GetStock(It.IsAny<string>())).Throws(new Exception());

            var stockMessage = stockBot.GetStock("AAPL.US");

            Assert.Equal("Stock not found.", stockMessage);
        }
    }
}
