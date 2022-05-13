using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Command for buying an item in shop
    /// </summary>
    public class BuyItemCommand : CommandBase
    {
        private readonly ShopViewModel _shopViewModel;

        public BuyItemCommand(ShopViewModel shopViewModel) 
        { 
            _shopViewModel = shopViewModel;
            _shopViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(_shopViewModel.SelectedItem))
                    OnCanExecuteChanged();
            };
        }

        public override bool CanExecute(object? parameter) 
            => base.CanExecute(parameter)  
            && _shopViewModel.EnoughMoney()
            && _shopViewModel.SelectedItem is null == false;

        public override void Execute(object? parameter) => _shopViewModel.Buy();
    }
}
