using System.Collections.Generic;

namespace Retarded_Game
{
    public sealed class Statistics
    {
        double _maxHP = 0, _maxMana = 0, _currentHP = 0, _currentMana = 0;
        double _defence = 0, _magicResistance = 0, _fireResistance = 0, _frostResistance = 0, _lightningResistance = 0;
        int _strenght = 0, _dexterity = 0, _intelligence = 0, _faith = 0;
        int _criticalChance = 0, _dodgeChance = 0;

        public double MaxHP 
        {
            get
            {
                if( _maxHP >= 20 )
                    return _maxHP;
                return 20;
            }
            set => _maxHP = value;
        }
        public double MaxMana 
        {
            get
            {
                if(_maxMana >= 0)
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
                if(value > _maxMana)
                    _currentMana = _maxMana;
                else
                    _currentMana = value;
            } 
        }

        public double Defence 
        {
            get => _defence;
            set => _defence = value; 
        }
        public double MagicResistance 
        {
            get
            {
                if (_magicResistance > 0.9)
                    return 0.9;
                return _magicResistance;
            }
            set => _magicResistance = value; 
        }
        public double FireResistance 
        {
            get
            {
                if (_fireResistance > 0.9)
                    return 0.9;
                return _fireResistance;
            } 
            set => _fireResistance = value;
        }
        public double FrostResistance 
        {
            get
            {
                if (_frostResistance > 0.9)
                    return 0.9;
                return _frostResistance;
            }
            set => _frostResistance = value; 
        }
        public double LightningResistance 
        { 
            get
            {
                if (_lightningResistance > 0.9)
                    return 0.9;
                return _lightningResistance;
            }
            set => _lightningResistance = value;
        }

        public int Strenght 
        { 
            get
            {
                if(_strenght < 5)
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
                if(_criticalChance < 1)
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

        List<Statistics> StatChanges = new List<Statistics>();
        
        public Statistics(double maxHP, double maxMana, double defence, double magicResistance,
            double fireResistance, double frostResistance, double lighningResistance,
            int strenght, int dexterity, int intelligence, int faith, int critical, int dodge)
        {
            _maxHP = maxHP;
            _maxMana = maxMana;
            _currentHP = _maxHP;
            _currentMana = _maxMana;
            
            _defence = defence;
            _magicResistance = magicResistance;
            _fireResistance = fireResistance;
            _frostResistance = frostResistance;
            _lightningResistance = lighningResistance;

            _strenght = strenght;
            _dexterity = dexterity;
            _intelligence = intelligence;
            _faith = faith;

            _criticalChance = critical;
            _dodgeChance = dodge;
        }

        public Statistics() { }

        public Statistics Copy()
        {
            return new Statistics(_maxHP, _maxMana, _defence, _magicResistance, _fireResistance, _frostResistance,
                _lightningResistance, _strenght, _dexterity, _intelligence, _faith, _criticalChance, _dodgeChance);
        }

        public void ChangeBy(Statistics change)
        {
            MaxHP += change.MaxHP;
            MaxMana += change.MaxMana;

            Defence += change.Defence;
            MagicResistance += change.MagicResistance;
            FireResistance += change.FireResistance;
            FrostResistance += change.FrostResistance;
            LightningResistance += change.LightningResistance;

            Strenght += change.Strenght;
            Dexterity += change.Dexterity;
            Intelligence += change.Intelligence;
            Faith += change.Faith;

            CriticalChance += change.CriticalChance;
            DodgeChance += change.DodgeChance;

            StatChanges.Add(change);
        }

        public void ReverseChange(Statistics change)
        {
            if (!StatChanges.Contains(change))
                return;

            MaxHP -= change.MaxHP;
            MaxMana -= change.MaxMana;

            Defence -= change.Defence;
            MagicResistance -= change.MagicResistance;
            FireResistance -= change.FireResistance;
            FrostResistance -= change.FrostResistance;
            LightningResistance -= change.LightningResistance;

            Strenght -= change.Strenght;
            Dexterity -= change.Dexterity;
            Intelligence -= change.Intelligence;
            Faith -= change.Faith;

            CriticalChance -= change.CriticalChance;
            DodgeChance -= change.DodgeChance;
            StatChanges.Remove(change);
        }
    }
}
