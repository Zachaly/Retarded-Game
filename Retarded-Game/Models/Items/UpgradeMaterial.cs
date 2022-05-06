using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Models.Items
{
    public class UpgradeMaterial : Item
    {
        public int MaterialLevel { get; }
        public UpgradeMaterial(string name, string description, int price, int materialLevel) : base(name, description, price)
        {
            MaterialLevel = materialLevel;
        }
    }
}
