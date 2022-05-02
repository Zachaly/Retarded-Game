using System.Collections.Generic;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;

namespace Retarded_Game.Models.Fighters.AI
{
    /// <summary>
    /// Character controlled by computer during fight
    /// </summary>
    public class AIFighter : Fighter
    {
        List<EnemyAction> _actions { get; }
        ActionPicker _actionPicker { get; set; }

        public AIFighter(string name, int level, List<EnemyAction> actions) : base(name, level)
        {
            _actions = actions;
        }

        public void SetActionPicker(Player target)
        {
            _actionPicker = new ActionPicker(this, _actions, target);
        }

        public EnemyAction GetEnemyAction() => _actionPicker.GetAction();
    }
}
