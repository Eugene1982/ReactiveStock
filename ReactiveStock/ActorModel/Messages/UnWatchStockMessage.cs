﻿namespace ReactiveStock.ActorModel.Messages
{
    class UnWatchStockMessage
    {
        public string StockSymbol { get; private set; }

        public UnWatchStockMessage(string stockSymbol)
        {
            StockSymbol = stockSymbol;
        }
    }
}