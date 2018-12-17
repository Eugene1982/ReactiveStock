namespace ReactiveStock.ExternalServices
{
    interface IStockPriceServiceGateway
    {
        decimal GetLatestPrice(string stockSymbol);
    }
}