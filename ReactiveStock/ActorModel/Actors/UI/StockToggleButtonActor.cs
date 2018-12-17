using Akka.Actor;
using ReactiveStock.ActorModel.Messages;
using ReactiveStock.ViewModel;

namespace ReactiveStock.ActorModel.Actors.UI
{
    class StockToggleButtonActor : ReceiveActor
    {
        public readonly IActorRef _coordinatorActor;
        public readonly string _stockSymbol;
        public readonly StockToggleButtonViewModel _viewModel;

        public StockToggleButtonActor(IActorRef coordinatorActor, StockToggleButtonViewModel viewModel, string stockSymbol)
        {
            _coordinatorActor = coordinatorActor;
            _viewModel = viewModel;
            _stockSymbol = stockSymbol;

            ToggledOff();
        }

        private void ToggledOff()
        {
            Receive<FlipToggleMessage>(message =>
            {
                _coordinatorActor.Tell(new WatchStockMessage(_stockSymbol));

                _viewModel.UpdateButtonTextToOn();

                Become(ToggledOn);
            });
        }

        private void ToggledOn()
        {
            Receive<FlipToggleMessage>(message =>
            {
                _coordinatorActor.Tell(new UnWatchStockMessage(_stockSymbol));

                _viewModel.UpdateButtonTextToOff();

                Become(ToggledOff);
            });
        }
    }
}