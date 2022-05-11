using System.Linq;
using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Filters items currently shown in inventory based on T
    /// </summary>
    public class ChangeInventoryCategoryCommand<T> : CommandBase
    {
        private readonly IItemListViewModel _inventory;
        
        public ChangeInventoryCategoryCommand(IItemListViewModel inventory)
        {
            _inventory = inventory;
        }

        public override void Execute(object? parameter)
        {
            _inventory.Items.Clear();
            var desiredItems = _inventory.AllItems.Where(item => item is T).ToList();
            desiredItems.ForEach(item => _inventory.Items.Add(item));
            _inventory.SetDataColumns(typeof(T));
        }
    }
}
