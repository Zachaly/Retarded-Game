﻿using Retarded_Game.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class ShieldViewModel : HandsItemViewModel
    {
        private Shield _shield => _item as Shield;

        public string BlockChance => $"{_shield.BlockChance}%";
        public string BlockFireDamage => $"{_shield.BlockFireDamage*100}";
        public string BlockFrostDamage => $"{_shield.BlockFrostDamage * 100}";
        public string BlockLightningDamage => $"{_shield.BlockLightningDamage * 100}";
        public string BlockMagicDamage => $"{_shield.BlockMagicDamage * 100}";

        public ShieldViewModel(Shield shield) : base(shield) { }
    }
}
