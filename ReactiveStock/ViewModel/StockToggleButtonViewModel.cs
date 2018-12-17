using System.Windows;
using System.Windows.Input;
using Akka.Actor;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ReactiveStock.ActorModel;
using ReactiveStock.ActorModel.Actors.UI;
using ReactiveStock.ActorModel.Messages;

namespace ReactiveStock.ViewModel
{
    public class StockToggleButtonViewModel : ViewModelBase
    {
        private string _buttonText;

        public string StockSymbol { get; set; }

        public ICommand ToggleCommand { get; set; }

        public IActorRef StockToggleButtonActorRef { get; private set; }

        public string ButtonText
        {
            get => _buttonText;
            set { Set(() => ButtonText, ref _buttonText, value); }
        }

        public StockToggleButtonViewModel(IActorRef stocksCoordiantorRef, string stockSymbol)
        {
            StockSymbol = stockSymbol;

            StockToggleButtonActorRef = ActorSystemReference.ActorSystem.ActorOf(Props.Create(() =>
                new StockToggleButtonActor(stocksCoordiantorRef, this, stockSymbol)));

            ToggleCommand = new RelayCommand(() => StockToggleButtonActorRef.Tell(new FlipToggleMessage()), keepTargetAlive:true);

            UpdateButtonTextToOff();
        }

        public void UpdateButtonTextToOff()
        {
            ButtonText = ConstructButtonText(false);
        }

        public void UpdateButtonTextToOn()
        {
            ButtonText = ConstructButtonText(true);
        }

        private string ConstructButtonText(bool isToggleOn)
        {
            return $"{StockSymbol} {(isToggleOn ? "(on)" : "(off)")}";
        }
    }
}