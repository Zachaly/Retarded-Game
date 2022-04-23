﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class ArmorViewModel : ItemViewModel
    {
        private  Armor _armor => _item as Armor;
        public string Type => _armor.ArmorType.ToString();

        public ArmorViewModel(Armor armor) : base(armor) { }
        
    }
}
