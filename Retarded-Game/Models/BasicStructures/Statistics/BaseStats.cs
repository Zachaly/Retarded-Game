using System.Collections.Generic;

namespace Retarded_Game.Models.BasicStructures.Statistics
{
    public sealed class BaseStats
    {
        double _maxHPBase = 0, _maxManaBase = 0, _currentHP = 0, _currentMana = 0;
        int _vitality = 0, _focus = 0, _strenght = 0, _dexterity = 0, _intelligence = 0, _faith = 0;
        int _criticalChance = 0, _dodgeBaseChance = 0;
        List<BaseStats> _changes = new List<BaseStats>();

        public static BaseStats Empty { get; } = new BaseStats();
        public double MaxHP
        {
            get
            {
                if (_maxHPBase <= 20)
                    return 20;
                return _maxHPBase + (5*Vitality) + (Strenght + Dexterity);
            }
            set => _maxHPBase = value;
        }

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
                if (_vitality < 5)
                    return 5;
                return _vitality;
            }
            set => _vitality = value;
        }

        public int Focus
        {
            get
            {
                if (_focus < 5)
                    return 5;
                return _focus;
            }
            set => _focus = value;
        }

        public int Strenght
        {
            get
            {
                if (_strenght < 5)
                    return 5;
                return _strenght;
            }
            set => _strenght = value;
        }
        public int Dexterity
        {
            get
            {
                if (_dexterity < 5)
                    return 5;
                return _dexterity;
            }
            set => _dexterity = value;
        }
        public int Intelligence
        {
            get
            {
                if (_intelligence < 5)
                    return 5;
                return _intelligence;
            }
            set => _intelligence = value;
        }
        public int Faith
        {
            get
            {
                if (_faith < 5)
                    return 5;
                return _faith;
            }
            set => _faith = value;
        }

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
            _currentHP = maxHP;
            _currentMana = maxMana;

            _vitality = vitality;
            _focus = focus;
            _strenght = strenght;
            _dexterity = dexterity;
            _intelligence = intelligence;
            _faith = faith;

            _criticalChance = critical;
            _dodgeBaseChance = dodge;
        }

        public void ApplyChange(BaseStats change)
        {
            _changes.Add(change);

            MaxHP += change._maxHPBase;
            MaxMana += change._maxManaBase;

            Vitality += change._vitality;
            Focus += change._focus;
            Strenght += change._strenght;
            Dexterity += change._dexterity;
            Intelligence += change._intelligence;
            Faith += change._faith;

            CriticalChance += change._criticalChance;
            DodgeChance += change._dodgeBaseChance;
        }

        public void ReverseChange(BaseStats change)
        {
            if (!_changes.Contains(change))
                return;

            MaxHP -= change._maxHPBase;
            MaxMana -= change._maxManaBase;

            Vitality -= change._vitality;
            Focus -= change._focus;
            Strenght -= change._strenght;
            Dexterity -= change._dexterity;
            Intelligence -= change._intelligence;
            Faith -= change._faith;

            CriticalChance -= change._criticalChance;
            DodgeChance -= change._dodgeBaseChance;
        }

        public BaseStats Clone()
            => new BaseStats(_maxHPBase, _maxManaBase, _vitality, _focus, _strenght,
                _dexterity, _intelligence, _faith, _criticalChance, _dodgeBaseChance);
    }
}
