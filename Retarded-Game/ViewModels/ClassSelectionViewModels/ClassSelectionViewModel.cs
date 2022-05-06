using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.Items;
using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.Models.BasicStructures;
using Retarded_Game.Stores;
using Retarded_Game.Services;
using Retarded_Game.Commands;

namespace Retarded_Game.ViewModels.ClassSelectionViewModels
{
    /// <summary>
    /// ViewModel describing class selection screen
    /// </summary>
    public class ClassSelectionViewModel : BaseViewModel
    {
        private readonly List<ClassViewModel> _startingClasses;
        private readonly NavigationService _navigationService;
        private ClassViewModel _selectedClass;

        public IEnumerable<ClassViewModel> StartingClasses => _startingClasses;
        public ClassViewModel SelectedClass 
        { 
            get => _selectedClass;
            set
            {
                _selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            } 
        }
        public int StartingLevel { get; set; }
        public CreateCharacterCommand CreateCharacterCommand => new CreateCharacterCommand(_navigationService, this);

        public ClassSelectionViewModel(NavigationService navigationService)
        {
            _startingClasses = new List<ClassViewModel> { new ClassViewModel(Trash()), new ClassViewModel(Warrior()),
                new ClassViewModel(Mage())};

            SelectedClass = _startingClasses.FirstOrDefault();
            _navigationService = navigationService;
        }

        private PlayerStartingClass Trash()
        {
            BaseStats baseStats = new BaseStats(20, 5, 3, 3, 3, 3, 3, 3, 0, 1);
            Statistics statistics = new Statistics(baseStats);
            Equipment equipment = new Equipment();
            equipment.SetStartingEquipment(Armor.None(ArmorType.Helmet), Armor.None(ArmorType.Chestplate),
                new Armor("Ragged pants", "", 1, new Statistics(new Defences(0.02, 0, -0.1, 0, 0)), ArmorType.Pants), 
                Armor.None(ArmorType.Boots),
                new Weapon("Wooden club", "", 1, StatRequirements.None, new Statistics(), new Damage(3, 0, 0, 0, 0),
                WeaponScaling.E, WeaponScaling.E, WeaponScaling.None, WeaponScaling.None, WeaponType.OneHanded),
                Weapon.EmptyHand, new List<Ring>(), new List<Consumable>());
            
            
            return new PlayerStartingClass("Trash", 1, statistics, equipment, new Spellbook(), 0);
        }

        private PlayerStartingClass Warrior()
        {
            BaseStats stats = new BaseStats(25, 0, 5, 3, 6, 4, 3, 3, 0, 1);
            Equipment equipment = new Equipment();

            Weapon weapon = new Weapon("Iron shortsword", "", 1, StatRequirements.None, new Statistics(),
                new Damage(5, 0, 0, 0, 0), WeaponScaling.C, WeaponScaling.D,
                WeaponScaling.None, WeaponScaling.None, WeaponType.OneHanded);
            Shield shield = new Shield("Wooden shield", "", 1, StatRequirements.None, new Statistics(),
                0.3, 0, 0, 0, 0, 60);

            Defences ironDefences = new Defences(0.02, 0, 0, 0, 0);

            Armor helmet = new Armor("Iron helmet", "", 1,
                new Statistics(ironDefences.CloneModify(-0.01)), ArmorType.Helmet);
            Armor chesplate = new Armor("Iron chestplate", "", 1,
                new Statistics(ironDefences.CloneModify(0.03)), ArmorType.Chestplate);
            Armor pants = new Armor("Iron leggins", "", 1, new Statistics(ironDefences.Clone()), ArmorType.Pants);
            Armor boots = new Armor("Iron boots", "", 1, new Statistics(ironDefences), ArmorType.Boots);

            equipment.SetStartingEquipment(helmet, chesplate, pants, boots, weapon, shield, new List<Ring>(), new List<Consumable>());
            return new PlayerStartingClass("Warrior", 5, new Statistics(stats), equipment, new Spellbook(), 0);
        }

        private PlayerStartingClass Mage()
        {
            BaseStats stats = new BaseStats(20, 15, 3, 5, 3, 3, 6, 4, 0, 2);
            Equipment equipment = new Equipment();
            Weapon weapon = new Weapon("Poor staff", "", 1, StatRequirements.None, new Statistics(),
                new Damage(3, 0, 0, 0, 1), WeaponScaling.D, WeaponScaling.E,
                WeaponScaling.C, WeaponScaling.None, WeaponType.TwoHanded);

            Defences robeDefences = new Defences(0.01, 0.02, 0, 0, 0);

            Armor chestplate = new Armor("Poor wizard robe", "", 1, new Statistics(robeDefences.Clone()), ArmorType.Chestplate);
            Armor pants = new Armor("Poor wizard leggins", "", 1,
                new Statistics(robeDefences.Clone()), ArmorType.Pants);
            Armor boots = new Armor("Poor wizard boots", "", 1,
                new Statistics(robeDefences.CloneModify(0, -0.01)), ArmorType.Boots);
            equipment.SetStartingEquipment(Armor.None(ArmorType.Helmet), chestplate, pants, boots, weapon,
                Weapon.EmptyHand, new List<Ring>(), new List<Consumable>());


            Spellbook spellbook = new Spellbook();
            Spell magicMissile = new Spell("Magic missile", "", 3, new StatRequirements(0, 5), new Damage(0, 0, 0, 0, 5),
                WeaponScaling.None, WeaponScaling.C, new List<ActionTag> { ActionTag.Spell, ActionTag.Magic }, (_, __) => { });
            spellbook.EquippedSpells.Add(magicMissile);

            return new PlayerStartingClass("Mage", 5, new Statistics(stats), equipment, spellbook, 3);
        }
    }
}
