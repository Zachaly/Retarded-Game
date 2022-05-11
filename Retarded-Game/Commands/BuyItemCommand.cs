using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    public class BuyItemCommand : CommandBase
    {
        ShopViewModel _shopViewModel;

        public BuyItemCommand(ShopViewModel shopViewModel) => _shopViewModel = shopViewModel;

        public override bool CanExecute(object? parameter) 
            => base.CanExecute(parameter)  
            && _shopViewModel.EnoughMoney()
            && _shopViewModel.SelectedItem is null == false;

        public override void Execute(object? parameter) => _shopViewModel.Buy();
    }
}
