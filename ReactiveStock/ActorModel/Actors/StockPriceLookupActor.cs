using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using ReactiveStock.ActorModel.Messages;
using ReactiveStock.ExternalServices;

namespace ReactiveStock.ActorModel.Actors
{
    class StockPriceLookupActor: ReceiveActor
    {
        private IStockPriceServiceGateway _stockPriceServiceGateway;

        public StockPriceLookupActor(IStockPriceServiceGateway stockPriceServiceGateway)
        {
            _stockPriceServiceGateway = stockPriceServiceGateway;

            Receive<RefreshStockPriceMessage>(message => LookupStockPrice(message));
        }

        private void LookupStockPrice(RefreshStockPriceMessage message)
        {
            var latestPrice = _stockPriceServiceGateway.GetLatestPrice(message.StockSymbol);

            Sender.Tell(new UpdatedStockPriceMessage(latestPrice, DateTime.Now));
        }
    }
}