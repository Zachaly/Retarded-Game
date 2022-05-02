using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class EquipmentViewModel : BaseViewModel
    {
        private readonly Equipment _equipment;

        private readonly ArmorViewModel _helmet;
        private readonly ArmorViewModel _chestplate;
        private readonly ArmorViewModel _pants;
        private readonly ArmorViewModel _boots;

        private readonly WeaponViewModel _rightHand;
        private readonly HandsItemViewModel _leftHand;
        private readonly List<RingViewModel> _rings;
        private readonly string[] _ringNames;

        public string HelmetName => $"Helmet:\n{_helmet.Name}";
        public string ChestplateName => $"Chestplate:\n{_chestplate.Name}";
        public string PantsName => $"Pants:\n{_pants.Name}";
        public string BootsName => $"Boots:\n{_boots.Name}";

        public string RightHandName => $"Weapon:\n{_rightHand.Name}";
        public string LeftHandName => $"LeftHand:\n{_leftHand.Name}";
        public string[] RingNames => _ringNames;
        
        public EquipmentViewModel(Equipment equipment)
        {
            _equipment = equipment;
            _helmet = new ArmorViewModel(_equipment.Helmet);
            _chestplate = new ArmorViewModel(_equipment.Chestplate);
            _pants = new ArmorViewModel(_equipment.Pants);
            _boots = new ArmorViewModel(_equipment.Boots);
            _rightHand = new WeaponViewModel(_equipment.RightHand);
            _rings = new List<RingViewModel>();

            foreach(var ring in _equipment.EquippedRings)
                _rings.Add(new RingViewModel(ring));

            _ringNames = _rings.Select(ring => ring.Name).ToArray();

            if(_equipment.LeftHand is Weapon)
                _leftHand = new WeaponViewModel(_equipment.LeftHand as Weapon);
            else if(_equipment.LeftHand is Shield)
                _leftHand = new ShieldViewModel(_equipment.LeftHand as Shield);
            else
                _leftHand = new WeaponViewModel(Weapon.EmptyHand);
        }
    }
}
