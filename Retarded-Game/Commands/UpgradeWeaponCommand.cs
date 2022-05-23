using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    public class UpgradeWeaponCommand : CommandBase
    {
        private readonly SmithViewModel _smith;

        public UpgradeWeaponCommand(SmithViewModel smith)
        {
            _smith = smith;

            _smith.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(_smith.SelectedWeapon))
                    OnCanExecuteChanged();
            };
        }

        public override bool CanExecute(object? parameter) => base.CanExecute(parameter) && _smith.CanUpgrade();

        public override void Execute(object? parameter) => _smith.Upgrade();
    }
}
