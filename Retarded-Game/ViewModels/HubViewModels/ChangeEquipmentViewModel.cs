using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.ItemViewModels;
using System;
using Retarded_Game.Models.BasicStructures.Enums;
using System.Collections.ObjectModel;
using System.Linq;
using Retarded_Game.Commands;
using Retarded_Game.Views.HubViews;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class ChangeEquipmentViewModel : HubSubCategoryBase
    {
        private Item? _currentEquippmentPart;
        private EquipmentPartViewModel? _selectedItem;
        private static ChangeEquipmentView _view;

        public static ChangeEquipmentView View { set => _view = value; }
        public ItemViewModel EquippedItem => CurrentEquippedItemViewModel();
        public ObservableCollection<EquipmentPartViewModel> Items { get; set; }
        public EquipmentPartViewModel SelectedItem 
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ChangeEquipmentCategoryCommand<RingViewModel> ChangeToRing 
            => new ChangeEquipmentCategoryCommand<RingViewModel>(this);
        public ChangeEquipmentCategoryCommand<WeaponViewModel> ChangeToRightHand
            => new ChangeEquipmentCategoryCommand<WeaponViewModel>(this);
        public ChangeEquipmentCategoryCommand<HandsItemViewModel> ChangeToLeftHand
            => new ChangeEquipmentCategoryCommand<HandsItemViewModel>(this);
        public ChangeEquipmentCategoryCommand<ArmorViewModel> ChangeToHelmet 
            => new ChangeEquipmentCategoryCommand<ArmorViewModel>(this, ArmorType.Helmet);
        public ChangeEquipmentCategoryCommand<ArmorViewModel> ChangeToChestplate
            => new ChangeEquipmentCategoryCommand<ArmorViewModel>(this, ArmorType.Chestplate);
        public ChangeEquipmentCategoryCommand<ArmorViewModel> ChangeToPants
            => new ChangeEquipmentCategoryCommand<ArmorViewModel>(this, ArmorType.Pants);
        public ChangeEquipmentCategoryCommand<ArmorViewModel> ChangeToBoots
            => new ChangeEquipmentCategoryCommand<ArmorViewModel>(this, ArmorType.Boots);

        public EquipItemCommand EquipCommand => new EquipItemCommand(this);
        public UnequipCommand UnequipCommand => new UnequipCommand(this);
        
        public ChangeEquipmentViewModel(NavigationService navigationService, Player player) 
            : base(navigationService, player)
        {
            Items = new ObservableCollection<EquipmentPartViewModel>();
        }

        private ItemViewModel CurrentEquippedItemViewModel()
        {
            if (_currentEquippmentPart is Weapon)
                return new WeaponViewModel(_currentEquippmentPart as Weapon);
            else if(_currentEquippmentPart is Armor)
                return new ArmorViewModel(_currentEquippmentPart as Armor);
            else if(_currentEquippmentPart is Shield)
                return new ShieldViewModel(_currentEquippmentPart as Shield);
            else if(_currentEquippmentPart is Ring)
                return new RingViewModel(_currentEquippmentPart as Ring);
            else
                return new ItemViewModel(Item.None);
        }

        public void SetItemsOfType(Type type, ArmorType armorType = 0)
        {
            Items = new ObservableCollection<EquipmentPartViewModel>();

            _player.Equipment.LeftHandEquip = false;

            if (type == typeof(HandsItemViewModel))
                SetLeftHand();
            else if (type == typeof(ArmorViewModel))
                SetArmor(armorType);
            else if(type == typeof(WeaponViewModel))
                SetRightHand();

            _view.SetColumnsToType(type);
            ItemsChanged();
        }

        public void SetRing(int ringNum)
        {
            if (ringNum < 0 || ringNum > 3)
                return;

            _currentEquippmentPart = _player.Equipment.EquippedRings[ringNum];
            var rings = _player.Equipment.AllItems.
                Where(item => item is Ring
                && !_player.Equipment.EquippedRings.Contains(item)).
                Select(item => item as Ring).
                ToList();
            rings.ForEach(item => Items.Add(new RingViewModel(item)));
            ItemsChanged();
            _view.SetColumnsToType(typeof(RingViewModel));
        }

        private void SetRightHand()
        {
            var weapons = _player.Equipment.AllItems.
                Where(item => item is Weapon 
                && !_player.Equipment.EquippedItems.Contains(item)).
                Select(item => item as Weapon).
                ToList();

            weapons.ForEach(weapon => Items.Add(new WeaponViewModel(weapon)));
            _currentEquippmentPart = _player.Equipment.RightHand;
        }

        private void SetLeftHand()
        {
            _player.Equipment.LeftHandEquip = true;
            var weapons = _player.Equipment.AllItems.
                Where(item => item is Weapon 
                && !_player.Equipment.EquippedItems.Contains(item)
                && (item as Weapon)?.WeaponType != WeaponType.TwoHanded).
                Select(item => item as Weapon).
                ToList();

            var shields = _player.Equipment.AllItems.
                Where(item => item is Shield 
                && !_player.Equipment.EquippedItems.Contains(item)).
                Select(item => item as Shield).
                ToList();

            weapons.ForEach(weapon => Items.Add(new WeaponViewModel(weapon)));
            shields.ForEach(shield => Items.Add(new ShieldViewModel(shield)));
            _currentEquippmentPart = _player.Equipment.LeftHand;
        }

        private void SetArmor(ArmorType type)
        {
            var armours = _player.Equipment.AllItems.
                Where(item => item is Armor 
                && !_player.Equipment.EquippedItems.Contains(item)
                && (item as Armor)?.ArmorType == type).
                Select(item => item as Armor).
                ToList();

            armours.ForEach(armor => Items.Add(new ArmorViewModel(armor)));

            if (type == ArmorType.Helmet)
                _currentEquippmentPart = _player.Equipment.Helmet;
            else if(type == ArmorType.Chestplate)
                _currentEquippmentPart = _player.Equipment.Chestplate;
            else if(type == ArmorType.Pants)
                _currentEquippmentPart = _player.Equipment.Pants;
            else 
                _currentEquippmentPart = _player.Equipment.Boots;
        }

        public bool CanEquip() => SelectedItem is null ? false : SelectedItem.AreStatsFullfilled(_player.Statistics.BaseStats);

        public void Equip() 
        { 
            SelectedItem.Equip(_player);
            Items.Add(CurrentEquippedItemViewModel() as EquipmentPartViewModel);
            _currentEquippmentPart = SelectedItem.Item;
            Items.Remove(SelectedItem);
            ItemsChanged();
        }
        public void UnEquip() 
        {
            if ((EquippedItem as EquipmentPartViewModel) == null)
                return;

            Items.Add(CurrentEquippedItemViewModel() as EquipmentPartViewModel);
            (EquippedItem as EquipmentPartViewModel).UnEquip(_player);
            _currentEquippmentPart = Item.None;
            ItemsChanged();
        }

        private void ItemsChanged()
        {
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(SelectedItem));
            OnPropertyChanged(nameof(EquippedItem));
        }
    }
}
