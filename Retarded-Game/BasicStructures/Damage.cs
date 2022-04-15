namespace Retarded_Game.BasicStructures
{
    internal struct Damage
    {
        public double BaseDamage { get; set; }
        public double FireDamage { get; set; }
        public double FrostDamage { get; set; }
        public double LightningDamage { get; set; }
        public double MagicDamage { get; set; }

        public static Damage None { get; } = new Damage(0, 0, 0, 0, 0);

        public Damage(double baseDamage, double fireDamage, double frostDamage, double lightningDamage, double magicDamage)
        {
            BaseDamage = baseDamage;
            FireDamage = fireDamage;
            FrostDamage = frostDamage;
            LightningDamage = lightningDamage;
            MagicDamage = magicDamage;
        }
    }
}
