using System.Collections.Generic;

namespace Retarded_Game.BasicStructures.Statistics
{
    public sealed class BaseStats
    {
        double _maxHP = 0, _maxMana = 0, _currentHP = 0, _currentMana = 0;
        int _strenght = 0, _dexterity = 0, _intelligence = 0, _faith = 0;
        int _criticalChance = 0, _dodgeChance = 0;
        List<BaseStats> _changes = new List<BaseStats>();

        public static BaseStats Empty { get; } = new BaseStats();
        public double MaxHP
        {
            get
            {
                if (_maxHP <= 20)
                    return 20;
                return _maxHP;
            }
            set => _maxHP = value;
        }

        public double MaxMana
        {
            get
            {
                if (_maxMana >= 0)
                    return _maxMana;
                return 0;
            }
            set => _maxMana = value;
        }

        public double CurrentHP
        {
            get => _currentHP;
            set
            {
                if (value > _maxHP)
                    _currentHP = _maxHP;
                else
                    _currentHP = value;
            }
        }
        public double CurrentMana
        {
            get => _currentMana;
            set
            {
                if (value > _maxMana)
                    _currentMana = _maxMana;
                else
                    _currentMana = value;
            }
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
                if (_dodgeChance < 1)
                    return 1;
                if (_dodgeChance > 80)
                    return 80;
                return _dodgeChance;
            }
            set => _dodgeChance = value;
        }

        public BaseStats() { }
        public BaseStats(double maxHP, double maxMana, int strenght, int dexterity, int intelligence, int faith, int critical, int dodge)
        {
            _maxHP = maxHP;
            _maxMana = maxMana;
            _currentHP = _maxHP;
            _currentMana = _maxMana;

            _strenght = strenght;
            _dexterity = dexterity;
            _intelligence = intelligence;
            _faith = faith;

            _criticalChance = critical;
            _dodgeChance = dodge;
        }

        public void ApplyChange(BaseStats change)
        {
            _changes.Add(change);

            MaxHP += change._maxHP;
            MaxMana += change._maxMana;

            Strenght += change._strenght;
            Dexterity += change._dexterity;
            Intelligence += change._intelligence;
            Faith += change._faith;

            CriticalChance += change._criticalChance;
            DodgeChance += change._dodgeChance;
        }

        public void ReverseChange(BaseStats change)
        {
            if (!_changes.Contains(change))
                return;

            MaxHP -= change._maxHP;
            MaxMana -= change._maxMana;

            Strenght -= change._strenght;
            Dexterity -= change._dexterity;
            Intelligence -= change._intelligence;
            Faith -= change._faith;

            CriticalChance -= change._criticalChance;
            DodgeChance -= change._dodgeChance;
        }

        public BaseStats Clone()
            => new BaseStats(_maxHP, _maxMana, _strenght, _dexterity, _intelligence, _faith, _criticalChance, _dodgeChance);
    }
}
