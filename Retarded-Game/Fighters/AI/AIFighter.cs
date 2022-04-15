using System.Collections.Generic;

namespace Retarded_Game.Fighters.AI
{
    internal class AIFighter : Fighter
    {
        List<EnemyAction> Actions { get; }
        ActionPicker ActionPicker { get; set; }

        public AIFighter(string name, int level, List<EnemyAction> actions) : base(name, level)
        {
            Actions = actions;
        }

        public void SetActionPicker(Player target)
        {
            ActionPicker = new ActionPicker(this, Actions, target);
        }

        public EnemyAction GetEnemyAction() => ActionPicker.GetAction();
    }
}
