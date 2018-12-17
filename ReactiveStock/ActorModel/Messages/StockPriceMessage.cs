using System;

namespace ReactiveStock.ActorModel.Messages
{
    class StockPriceMessage
    {
        public string StockSymbol { get; private set; }

        public decimal Price { get; private set; }

        public DateTime Date { get; private set; }

        public StockPriceMessage(string stockSymbol, decimal stockPrice, DateTime date)
        {
            StockSymbol = stockSymbol;
            Price = stockPrice;
            Date = date;
        }
    }
}