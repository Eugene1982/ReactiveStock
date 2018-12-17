﻿namespace ReactiveStock.ActorModel.Messages
{
    class AddChartSeriesMessage
    {
        public string StockSymbol { get; private set; }

        public AddChartSeriesMessage(string stockSymbol)
        {
            StockSymbol = stockSymbol;
        }
    }
}