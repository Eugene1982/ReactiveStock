using Akka.Actor;

namespace ReactiveStock.ActorModel.Messages
{
    class SubscribeToNewStockPricesMessage
    {
        public IActorRef Subscriber { get; private set; }

        public SubscribeToNewStockPricesMessage(IActorRef subscribingActor)
        {
            Subscriber = subscribingActor;
        }
    }
}