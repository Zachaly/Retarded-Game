﻿using Retarded_Game.Models.Fighters;

namespace Retarded_Game.Models.BasicStructures
{
    public delegate void StatusEffectTick(Fighter target);
    /// <summary>
    /// Class representing a status effect that affects character
    /// </summary>
    public sealed class StatusEffect
    {
        Fighter _target;
        event StatusEffectTick _tick;
        int _numberOfTicks;
        public StatusEffect(Fighter target, int numberOfTicks, StatusEffectTick tick)
        {
            _target = target;
            _tick += tick;
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
