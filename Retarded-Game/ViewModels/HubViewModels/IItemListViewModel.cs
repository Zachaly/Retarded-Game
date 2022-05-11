using System.Collections.ObjectModel;
using Retarded_Game.ViewModels.ItemViewModels;
using System.Collections.Generic;
using System;

namespace Retarded_Game.ViewModels.HubViewModels
{
    /// <summary>
    /// ViewModel that contains a list of items and they can be changed
    /// </summary>
    public interface IItemListViewModel
    {
        public List<ItemViewModel> AllItems { get; }
        public ObservableCollection<ItemViewModel> Items { get; set; }
        public void SetDataColumns(Type type);
    }
}
