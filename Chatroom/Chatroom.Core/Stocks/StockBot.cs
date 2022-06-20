namespace Chatroom.Core.Stocks
{
    public class StockBot
    {
        private readonly StockService stockService;

        public StockBot(StockService stockService)
        {
            this.stockService = stockService;
        }

        public string GetStock(string stockCode)
        {
            try
            {
                var stock = stockService.GetStock(stockCode);
                return $"{stockCode.ToUpper()} quote is {stock.PriceClose:c} per share.";
            }
            catch (Exception)
            {
                return "Stock not found";
            }
        }
    }
}
