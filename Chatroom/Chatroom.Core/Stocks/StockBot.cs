using System.Globalization;

namespace Chatroom.Core.Stocks
{
    public interface IStockBot
    {
        string GetStock(string stockCode);
    }

    public class StockBot : IStockBot
    {
        private readonly IStockService stockService;

        private readonly CultureInfo cultureUSA = new CultureInfo("en-us");

        public StockBot(IStockService stockService)
        {
            this.stockService = stockService;
        }

        public string GetStock(string stockCode)
        {
            try
            {
                var stock = stockService.GetStock(stockCode);
                return $"{stockCode.ToUpper()} quote is {stock.PriceClose.ToString("c", cultureUSA)} per share.";
            }
            catch (Exception)
            {
                return "Stock not found.";
            }
        }
    }
}
