namespace ReactiveStock.ActorModel.Messages
{
    class RemoveChartSeriesMessage
    {
        public string StockSymbol { get; private set; }

        public RemoveChartSeriesMessage(string stockSymbol)
        {
            StockSymbol = stockSymbol;
        }
    }
}