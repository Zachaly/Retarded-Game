using System.Collections.Generic;

namespace Retarded_Game.Models.BasicStructures.Statistics
{
    /// <summary>
    /// Class containing basic statistics that mostly aren't influenced by equipment
    /// </summary>
    public sealed class BaseStats
    {
        double _maxHPBase = 0, _maxManaBase = 0, _currentHP = 0, _currentMana = 0;
        int _vitality = 0, _focus = 0, _strenght = 0, _dexterity = 0, _intelligence = 0, _faith = 0;
        int _criticalChance = 0, _dodgeBaseChance = 0;
        List<BaseStats> _changes = new List<BaseStats>();

        /// <summary>
        /// Default statistics
        /// </summary>
        public static BaseStats Empty => new BaseStats();
        /// <summary>
        /// Maximum HP of character, cannot be lower than 20.
        /// Influenced by vitality, strenght and dexterity
        /// </summary>
        public double MaxHP
        {
            get
            {
                if (_maxHPBase < 20)
                    return 20;
                return _maxHPBase + (5*Vitality) + (Strenght + Dexterity);
            }
            set => _maxHPBase = value;
        }

        /// <summary>
        /// Maximum mana of character, cannot be lower than 0.
        /// Influenced by focus, faith and intelligence
        /// </summary>
        public double MaxMana
        {
            get
            {
                if (_maxManaBase >= 0)
                    return _maxManaBase + (5*Focus) + (Faith + Intelligence);
                return 0;
            }
            set => _maxManaBase = value;
        }

        public double CurrentHP
        {
            get => _currentHP;
            set
            {
                if (value > MaxHP)
                    _currentHP = MaxHP;
                else
                    _currentHP = value;
            }
        }
        public double CurrentMana
        {
            get => _currentMana;
            set
            {
                if (value > MaxMana)
                    _currentMana = MaxMana;
                else
                    _currentMana = value;
            }
        }

        public int Vitality
        {
            get
            {
                if (_vitality < 3)
                    return 3;
                return _vitality;
            }
            set => _vitality = value;
        }

        public int Focus
        {
            get
            {
                if (_focus < 3)
                    return 3;
                return _focus;
            }
            set => _focus = value;
        }

        public int Strenght
        {
            get
            {
                if (_strenght < 3)
                    return 3;
                return _strenght;
            }
            set => _strenght = value;
        }
        public int Dexterity
        {
            get
            {
                if (_dexterity < 3)
                    return 3;
                return _dexterity;
            }
            set => _dexterity = value;
        }
        public int Intelligence
        {
            get
            {
                if (_intelligence < 3)
                    return 3;
                return _intelligence;
            }
            set => _intelligence = value;
        }
        public int Faith
        {
            get
            {
                if (_faith < 3)
                    return 3;
                return _faith;
            }
            set => _faith = value;
        }

        /// <summary>
        /// Chance for a critical hit by character, given in % between 1 and 75
        /// </summary>
        public int CriticalChance
        {
            get
            {
                if (_criticalChance < 1)
                    return 1;
                if (_criticalChance > 75)
                    return 75;
                return _criticalChance;
            }
            set => _criticalChance = value;

        }

        /// <summary>
        /// Chance for a character to dodge an attack, given in % between 1 and 80,
        /// influenced by dexterity
        /// </summary>
        public int DodgeChance
        {
            get
            {
                if (_dodgeBaseChance < 1)
                    return 1 + (int)(0.5 * Dexterity);
                if (_dodgeBaseChance > 80)
                    return 80 + (int)(0.5 * Dexterity);
                return _dodgeBaseChance + (int)(0.5*Dexterity);
            }
            set => _dodgeBaseChance = value;
        }

        public BaseStats() { }
        public BaseStats(double maxHP, double maxMana, int vitality, int focus, int strenght,
            int dexterity, int intelligence, int faith, int critical, int dodge)
        {
            _maxHPBase = maxHP;
            _maxManaBase = maxMana;

            _vitality = vitality;
            _focus = focus;
            _strenght = strenght;
            _dexterity = dexterity;
            _intelligence = intelligence;
            _faith = faith;

            _criticalChance = critical;
            _dodgeBaseChance = dodge;

            _currentHP = MaxHP;
            _currentMana = MaxMana;
        }

        /// <summary>
        /// Modifies statistics by BaseStats given in parameter
        /// </summary>
        public void ApplyChange(BaseStats change)
        {
            _changes.Add(change);

            _maxHPBase += change._maxHPBase;
            _maxHPBase += change._maxManaBase;

            _vitality += change._vitality;
            _focus += change._focus;
            _strenght += change._strenght;
            _dexterity += change._dexterity;
            _intelligence += change._intelligence;
            _faith += change._faith;

            _criticalChance += change._criticalChance;
            _dodgeBaseChance += change._dodgeBaseChance;
        }

        /// <summary>
        /// Reverses changes done by given parameter
        /// </summary>
        public void ReverseChange(BaseStats change)
        {
            if (!_changes.Contains(change))
                return;

            _maxHPBase -= change._maxHPBase;
            _maxHPBase -= change._maxManaBase;

            _vitality -= change._vitality;
            _focus -= change._focus;
            _strenght -= change._strenght;
            _dexterity -= change._dexterity;
            _intelligence -= change._intelligence;
            _faith -= change._faith;

            _criticalChance -= change._criticalChance;
            _dodgeBaseChance -= change._dodgeBaseChance;
        }

        public BaseStats Clone()
            => new BaseStats(_maxHPBase, _maxManaBase, _vitality, _focus, _strenght,
                _dexterity, _intelligence, _faith, _criticalChance, _dodgeBaseChance);
    }
}
