using System.Collections.Generic;
using Retarded_Game.Fighters.Players;

namespace Retarded_Game.Fighters.AI
{
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
