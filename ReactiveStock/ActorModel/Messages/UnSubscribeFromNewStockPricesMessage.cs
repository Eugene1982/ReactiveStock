using Akka.Actor;

namespace ReactiveStock.ActorModel.Messages
{
    class UnSubscribeFromNewStockPricesMessage
    {
        public IActorRef Subscriber { get; private set; }

        public UnSubscribeFromNewStockPricesMessage(IActorRef unsubscribingActor)
        {
            Subscriber = unsubscribingActor;
        }
    }
}