using Retarded_Game.BasicStructures.Statistics;

namespace Retarded_Game.Items
{
    public class Shield : EquipmentPart
    {
        int _blockChance = 0;
        double _blockBaseDamage = 0, _blockFireDamage = 0, _blockFrostDamage = 0, _blockLightningDamage = 0, _blockMagicDamage = 0;

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
            StatRequirements statRequirements, Statistics statsChange,
            double blockBaseDamage, double blockMagicDamage, double blockFireDamage,
            double blockFrostDamage, double blockLightningDamage, int blockChance) 
            : base(name, description, price, statRequirements, statsChange)
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
