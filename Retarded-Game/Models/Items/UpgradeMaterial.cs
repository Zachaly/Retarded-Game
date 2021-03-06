namespace Retarded_Game.Models.Items
{
    /// <summary>
    /// Item used to upgrade weapons
    /// </summary>
    public sealed class UpgradeMaterial : Item
    {
        public int MaterialLevel { get; }
        public UpgradeMaterial(string name, string description, int price, int materialLevel) 
            : base(name, description, price)
            => MaterialLevel = materialLevel;

        public override UpgradeMaterial Clone() => new UpgradeMaterial(Name, Description, Price, MaterialLevel);
    }
}
