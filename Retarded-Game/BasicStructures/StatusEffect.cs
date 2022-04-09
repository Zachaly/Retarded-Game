namespace Retarded_Game
{
    public delegate void StatusEffectTick(Fighter target);
    public sealed class StatusEffect
    {
        Fighter target;
        event StatusEffectTick tick;
        int numberOfTicks;
        public StatusEffect(Fighter target, int numberOfTicks, StatusEffectTick tick)
        {
            this.target = target;
            this.tick += tick;
            this.numberOfTicks = numberOfTicks;
        }

        public void TakeEffect()
        {
            tick(target);
            numberOfTicks--;

            if(numberOfTicks == 0)
                target.StatusEffects.Remove(this);
        }
    }
}
