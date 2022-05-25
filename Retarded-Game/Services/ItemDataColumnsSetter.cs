using System;
using System.Windows;
using System.Windows.Controls;
using Retarded_Game.ViewModels.ItemViewModels;

namespace Retarded_Game.Services
{
    /// <summary>
    /// Used to set columns in listview to show info about certain item type
    /// </summary>
    public class ItemDataColumnsSetter
    {
        private readonly GridView _itemColumns;
        private readonly ResourceDictionary _resources;
        public ItemDataColumnsSetter(GridView gridView, ResourceDictionary resources)
        {
            _itemColumns = gridView;
            _resources = resources;
        }

        private void AddNewColumn(string name, string binding = "")
        {
            if (binding == "")
                binding = name.Replace(" ", "");
            GridViewColumn column = new GridViewColumn();
            column.Header = name;
            column.CellTemplate = (DataTemplate)_resources[binding];
            _itemColumns.Columns.Add(column);
        }

        public void SetColumnsToType(Type type)
        {
            if (type == typeof(WeaponViewModel))
                SetWeaponColumns();
            else if (type == typeof(ArmorViewModel))
                SetArmorColumns();
            else if (type == typeof(ShieldViewModel))
                SetShieldColumns();
            else if (type == typeof(UpgradeMaterialViewModel))
                SetUpgradeMaterialColumns();
            else if (type == typeof(RingViewModel))
                SetRingColumns();
            else if( type == typeof(HandsItemViewModel))
                SetLeftHandColumns();
            else
                SetStandardColumns();
        }

        /// <summary>
        /// Columns containing name and price
        /// </summary>
        public void SetStandardColumns()
        {
            _itemColumns.Columns.Clear();
            AddNewColumn("Name");
            AddNewColumn("Price");
        }

        private void SetWeaponColumns()
        {
            SetStandardColumns();
            AddNewColumn("Type");
            AddNewColumn("Base Damage");
            AddNewColumn("Magic Damage");
            AddNewColumn("Fire Damage");
            AddNewColumn("Frost Damage");
            AddNewColumn("Lightning Damage");
            AddStatsRequirementsColumns();
            AddNewColumn("Strength Scaling");
            AddNewColumn("Dexterity Scaling");
            AddNewColumn("Faith Scaling");
            AddNewColumn("Intelligence Scaling");
        }

        private void AddStatsRequirementsColumns()
        {
            AddNewColumn("Minimal Strength", "RequiredStrength");
            AddNewColumn("Minimal Dexterity", "RequiredDexterity");
            AddNewColumn("Minimal Faith", "RequiredFaith");
            AddNewColumn("Minimal Intelligence", "RequiredIntelligence");
        }
        private void SetArmorColumns()
        {
            SetStandardColumns();
            AddNewColumn("Type");
            AddNewColumn("Base Defence");
            AddNewColumn("Magic Resistance");
            AddNewColumn("Fire Resistance");
            AddNewColumn("Frost Resistance");
            AddNewColumn("Lightning Resistance");
        }
        private void SetShieldColumns()
        {
            SetStandardColumns();
            AddNewColumn("Block Chance");
            AddNewColumn("Block Base Damage");
            AddNewColumn("Block Magic Damage");
            AddNewColumn("Block Fire Damage");
            AddNewColumn("Block Frost Damage");
            AddNewColumn("Block Lightning Damage");
        }
        private void SetRingColumns()
        {
            SetStandardColumns();
        }

        private void SetUpgradeMaterialColumns()
        {
            SetStandardColumns();
            AddNewColumn("Material Level");
        }

        private void SetLeftHandColumns()
        {
            SetStandardColumns();
            AddStatsRequirementsColumns();
        }
    }
}
