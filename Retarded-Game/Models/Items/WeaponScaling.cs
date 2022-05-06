namespace Retarded_Game.Models.Items
{
    /// <summary>
    /// Values for weapon scaling
    /// </summary>
    public sealed class WeaponScaling
    {
        public const double S = 0.4;
        public const double A = 0.3;
        public const double B = 0.2;
        public const double C = 0.1;
        public const double D = 0.05;
        public const double E = 0.01;
        public const double None = 0;

        /// <summary>
        /// Converts scaling to string
        /// </summary>
        public static string ScalingToString(double scaling)
        {
                if(scaling >= S) return "S";
                if(scaling >= A) return "A";
                if(scaling >= B) return "B";
                if(scaling >= C) return "C";
                if(scaling >= D) return "D";
                if(scaling >= E) return "E";
                return "None";
        }
    }
}
