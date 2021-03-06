using System.Collections.Generic;
using Retarded_Game.Models.BasicStructures.Enums;
using System.Linq;

namespace Retarded_Game.Models.BasicStructures.Statistics
{
    /// <summary>
    /// Class containing information about character resistances.
    /// Resistances cannot get higher than 90%
    /// </summary>
    public sealed class Defences
    {
        double _defence = 0,
            _magicResistance = 0,
            _fireResistance = 0,
            _frostResistance = 0,
            _lightningResistance = 0;
        List<Defences> _changes = new List<Defences>();

        /// <summary>
        /// Default defences
        /// </summary>
        public static Defences Empty => new Defences();
        public double Defence
        {
            get 
            {
                if (_defence > 0.9)
                    return 0.9;
                return _defence;
            }
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

        public Defences() { }

        public Defences(double defence, double magicResistance, double fireResistance, double frostResistance, double lightningResistance)
        {
            _defence = defence;
            _magicResistance = magicResistance;
            _fireResistance = fireResistance;
            _frostResistance = frostResistance;
            _lightningResistance = lightningResistance;
        }

        /// <summary>
        /// Modifies resistances by Defences given in parameter
        /// </summary>
        public void ApplyChange(Defences change)
        {
            _changes.Add(change);

            _defence += change.Defence;
            _magicResistance += change.MagicResistance;
            _fireResistance += change.FireResistance;
            _frostResistance += change.FrostResistance;
            _lightningResistance += change.LightningResistance;
        }

        /// <summary>
        /// Reverses changes done by given parameter
        /// </summary>
        public void ReverseChange(Defences change)
        {
            if(!_changes.Contains(change))
                    return;

            _defence -= change.Defence;
            _magicResistance -= change.MagicResistance;
            _fireResistance -= change.FireResistance;
            _frostResistance -= change.FrostResistance;
            _lightningResistance -= change.LightningResistance;
        }

        public Defences Clone()
            => new Defences(_defence, _magicResistance, _fireResistance, _frostResistance, _lightningResistance);

        /// <summary>
        /// Returns a clone with given stats modification
        /// </summary>
        public Defences CloneModify(double basicDefence = 0, double magicResistance = 0, double fireResistance = 0,
            double frostResistance = 0, double lightningResistance = 0)
            => new Defences(_defence + basicDefence, _magicResistance + magicResistance,
                _fireResistance + fireResistance, _frostResistance + frostResistance,
                _lightningResistance + lightningResistance);

        /// <summary>
        /// Gets a tuples with resitances and their values ascending
        /// </summary>
        public IEnumerable<(Resistance, double)> GetResistancesAscending()
        {
            List<(Resistance resistance, double value)> resists = new List<(Resistance, double)>
            { (Resistance.Base, Defence), (Resistance.Magic, MagicResistance),
            (Resistance.Fire, FireResistance), (Resistance.Frost, FrostResistance),
            (Resistance.Lightning, LightningResistance)};

            return resists.OrderBy(el => el.value);
        }
    }
}
