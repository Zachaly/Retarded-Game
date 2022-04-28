using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.Items;
using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.Models.BasicStructures;

namespace Retarded_Game.ViewModels.ClassSelectionViewModels
{
    public class ClassSelectionViewModel : BaseViewModel
    {
        private readonly List<PlayerStartingClass> _startingClasses;

        public IEnumerable<PlayerStartingClass> StartingClasses => _startingClasses;
        public PlayerStartingClass SelectedClass { get; set; }
        public int StartingLevel { get; set; }

        public ClassSelectionViewModel()
        {
            _startingClasses = new List<PlayerStartingClass> { Trash(), Warrior()};

            SelectedClass = StartingClasses.FirstOrDefault();
        }

        private PlayerStartingClass Trash()
        {
            BaseStats baseStats = new BaseStats(20, 5, 5, 5, 5, 5, 5, 5, 0, 1);
            Statistics statistics = new Statistics(baseStats);
            Equipment equipment = new Equipment();
            equipment.SetStartingEquipment(Armor.None(ArmorType.Helmet), Armor.None(ArmorType.Chestplate),
                new Armor("Ragged pants", "", 1, new Statistics(new Defences(2, 0, -1, 0, 0)), ArmorType.Pants), 
                Armor.None(ArmorType.Boots), new Weapon("Wooden club", "", 1, StatRequirements.None, new Statistics(),
                new Damage(3, 0, 0, 0, 0), WeaponScaling.E, WeaponScaling.E,
                WeaponScaling.None, WeaponScaling.None, WeaponType.OneHanded),
                Weapon.EmptyHand, new List<Ring>(), new List<Consumable>());
            
            
            return new PlayerStartingClass("Trash", 1, statistics, equipment, new Spellbook());
        }

        private PlayerStartingClass Warrior()
        {
            BaseStats stats = new BaseStats(25, 0, 6, 4, 7, 5, 3, 3, 0, 0);
            Equipment equipment = new Equipment();

            Weapon weapon = new Weapon("Iron shortsword", "", 1, StatRequirements.None, new Statistics(),
                new Damage(5, 0, 0, 0, 0), WeaponScaling.C, WeaponScaling.D,
                WeaponScaling.None, WeaponScaling.None, WeaponType.OneHanded);
            Shield shield = new Shield("Wooden shield", "", 1, StatRequirements.None, new Statistics(),
                0.3, 0, 0, 0, 0, 60);

            Defences ironDefences = new Defences(0.02, 0, 0, 0, 0);

            Armor helmet = new Armor("Iron helmet", "", 1, new Statistics(ironDefences.CloneModify(-0.01)), ArmorType.Helmet);
            Armor chesplate = new Armor("Iron chestplate", "", 1, new Statistics(ironDefences.CloneModify(0.03)), ArmorType.Chestplate);
            Armor pants = new Armor("Iron leggins", "", 1, new Statistics(ironDefences.Clone()), ArmorType.Pants);
            Armor boots = new Armor("Iron boots", "", 1, new Statistics(ironDefences), ArmorType.Boots);

            equipment.SetStartingEquipment(helmet, chesplate, pants, boots, weapon, shield, new List<Ring>(), new List<Consumable>());
            return new PlayerStartingClass("Warrior", 5, new Statistics(stats), equipment, new Spellbook());
        }
    }
}
