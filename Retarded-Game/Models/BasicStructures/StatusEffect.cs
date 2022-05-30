using Retarded_Game.Models.Fighters;
using System;

namespace Retarded_Game.Models.BasicStructures
{
    /// <summary>
    /// Class representing a status effect that affects character
    /// </summary>
    public sealed class StatusEffect
    {
        Fighter _target;
        Action<Fighter> _tick;
        int _numberOfTicks;
        public StatusEffect(Fighter target, int numberOfTicks, Action<Fighter> tick)
        {
            _target = target;
            _tick = tick;
            _numberOfTicks = numberOfTicks;
        }

        public void TakeEffect()
        {
            _tick(_target);
            _numberOfTicks--;

            if(_numberOfTicks == 0)
                _target.StatusEffects.Remove(this);
        }
    }
}
