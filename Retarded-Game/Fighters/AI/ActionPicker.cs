using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Fighters.AI
{
    internal class ActionPicker
    {
        Player Player { get; }
        Fighter Enemy { get; }
        List<EnemyAction> Actions { get; }
        Random Random { get; }

        enum Resistance
        {
            Base, Magic, Fire, Lightning, Frost
        }

        public ActionPicker(AIFighter enemy, List<EnemyAction> actions, Player player)
        {
            Enemy = enemy;
            Actions = actions;
            Player = player;
            Random = new Random();
        }

        public int GetRandomNum(List<EnemyAction> list)
        {
            return Random.Next(0, list.Count);
        }

        public EnemyAction GetAction()
        {
            EnemyAction action = new EnemyAction(Enemy, Player, 0, new List<ActionTag>(), (_, __) => { });

            if (Enemy.Statistics.BaseStats.CurrentHP < Enemy.Statistics.BaseStats.MaxHP * 0.3)
                action = GetHealingAction(action);
            else
                action = GetOffensiveAction();
            
            return action;
        }

        private EnemyAction GetHealingAction(EnemyAction defaultAction)
        {
            var healingActions = Actions.FindAll(action => action.ActionTags.Contains(ActionTag.Healing));

            if(healingActions.Count == 0)
                return defaultAction;

            return healingActions[GetRandomNum(healingActions)];
        }

        private EnemyAction GetOffensiveAction()
        {
            var attacks = Actions.FindAll(action => action.ActionTags.Contains(ActionTag.Attack));

            EnemyAction defaultAttack = attacks[GetRandomNum(attacks)];

            switch (GetLowestPlayerResistance())
            {
                case Resistance.Base:
                    defaultAttack = GetElementalAttack(attacks, defaultAttack, ActionTag.Basic);
                    break;

                case Resistance.Magic:
                    defaultAttack = GetElementalAttack(attacks, defaultAttack, ActionTag.Magic);
                    break;

                case Resistance.Fire:
                    defaultAttack = GetElementalAttack(attacks, defaultAttack, ActionTag.Fire);
                    break;

                case Resistance.Frost:
                    defaultAttack = GetElementalAttack(attacks, defaultAttack, ActionTag.Frost);
                    break;

                case Resistance.Lightning:
                    defaultAttack = GetElementalAttack(attacks, defaultAttack, ActionTag.Lightning);
                    break;
            }

            return defaultAttack;
        }

        private Resistance GetLowestPlayerResistance()
        {
            Resistance resistance = Resistance.Base;
            //TODO
            return resistance;
        }

        private EnemyAction GetElementalAttack(List<EnemyAction> actions, EnemyAction defaultAction, ActionTag element)
        {
            var attacks = actions.FindAll(action => action.ActionTags.Contains(element));

            if (attacks.Count == 0)
                return defaultAction;

            return attacks[GetRandomNum(attacks)];
        }
    }
}
