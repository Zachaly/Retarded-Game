using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Items
{
    internal class Shield : EquipmentPart
    {
        int _blockChance;
        double _blockBaseDamage, _blockFireDamage, _blockFrostDamage, _blockLightningDamage, _blockMagicDamage;

        public int BlockChance
        {
            get 
            { 
                if(_blockChance > 85)
                    return _blockChance;

                return _blockChance; 
            }
            set => _blockChance = value; 
        }

        public double BlockBaseDamage
        {
            get
            {
                if (_blockBaseDamage > 1)
                    return 1;
                return _blockBaseDamage;
            }
            set => _blockBaseDamage = value;
        }

        public double BlockMagicDamage
        {
            get
            {
                if (_blockMagicDamage > 1)
                    return 1;
                return _blockMagicDamage;
            }
            set => _blockMagicDamage = value;
        }

        public double BlockFireDamage
        {
            get
            {
                if (_blockFireDamage > 1)
                    return 1;
                return _blockFireDamage;
            }
            set => _blockFireDamage = value;
        }

        public double BlockFrostDamage
        {
            get
            {
                if (_blockFrostDamage > 1)
                    return 1;
                return _blockFrostDamage;
            }
            set => _blockFrostDamage = value;
        }

        public double BlockLightningDamage
        {
            get
            {
                if (_blockLightningDamage > 1)
                    return 1;
                return _blockLightningDamage;
            }
            set => _blockLightningDamage = value;
        }

        public Shield(string name, string description, int price,
            int minimalStrenght, int minimalDexterity, int minimalIntelligence, int minimalFaith, Statistics statsChange,
            double blockBaseDamage, double blockMagicDamage, double blockFireDamage, double blockFrostDamage, double blockLightningDamage, int blockChance) 
            : base(name, description, price, minimalStrenght, minimalDexterity, minimalIntelligence, minimalFaith, statsChange)
        {
            _blockBaseDamage = blockBaseDamage;
            _blockMagicDamage = blockMagicDamage;
            _blockChance = blockChance;
            _blockFireDamage = blockFireDamage;
            _blockFrostDamage = blockFrostDamage;
            _blockLightningDamage = blockLightningDamage;
        }
    }
}
