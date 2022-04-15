using System;
using System.Collections.Generic;
using Retarded_Game.BasicStructures.Enums;
using System.Linq;
using Retarded_Game.Fighters.Players;

namespace Retarded_Game.Fighters.AI
{
    public sealed class ActionPicker
    {
        Player Player { get; }
        Fighter Enemy { get; }
        List<EnemyAction> Actions { get; }
        static Random Random { get; } = new Random();
        bool ActionPicked { get; set; } = false;

        public ActionPicker(AIFighter enemy, List<EnemyAction> actions, Player player)
        {
            Enemy = enemy;
            Actions = actions;
            Player = player;
        }

        private EnemyAction GetRandomElement(List<EnemyAction> list)
        {
            return list[Random.Next(0, list.Count)];
        }

        public EnemyAction GetAction()
        {
            EnemyAction action = new EnemyAction(Enemy, Player, 0, new List<ActionTag>(), (_, __) => { });

            if (Enemy.Statistics.BaseStats.CurrentHP < Enemy.Statistics.BaseStats.MaxHP * 0.3)
                action = GetHealingAction(action);
            else if(Enemy.Statistics.BaseStats.CurrentMana < Actions.MinBy(action => action.ManaCost).ManaCost)
                action = GetManaRegeneration(action);
            if(!ActionPicked)
                action = GetOffensiveAction(Actions);
            
            return action;
        }

        private EnemyAction GetManaRegeneration(EnemyAction defaultAction)
        {
            var actions = Actions.FindAll(action => action.ActionTags.Contains(ActionTag.ManaRegeneration));
            if(actions.Count < 1)
                return defaultAction;

            return GetRandomElement(actions);
        }

        private EnemyAction GetHealingAction(EnemyAction defaultAction)
        {
            var healingActions = Actions.FindAll(action => action.ActionTags.Contains(ActionTag.Healing));
            healingActions = healingActions.FindAll(action => action.ManaCost <= Enemy.Statistics.BaseStats.CurrentMana);

            if(healingActions.Count == 0)
                return defaultAction;

            // if player hp is below 25% and you have attack that heals you, return that attack
            if(Player.Statistics.BaseStats.CurrentHP <= Player.Statistics.BaseStats.CurrentHP * 0.25
                && healingActions.Any(action => action.ActionTags.Contains(ActionTag.Attack)))
                return GetOffensiveAction(healingActions);
                
            return GetRandomElement(healingActions);
        }

        private EnemyAction GetOffensiveAction(List<EnemyAction> actions)
        {
            var attacks = actions.FindAll(action => action.ActionTags.Contains(ActionTag.Attack));
            attacks = attacks.FindAll(action => action.ManaCost <= Enemy.Statistics.BaseStats.CurrentMana);

            EnemyAction defaultAttack = GetRandomElement(attacks);

            Resistance lowestPlayerResistance = GetLowestPlayerResistance(attacks);

            defaultAttack = GetElementalAttack(attacks, defaultAttack, ResistanceToAttackTag(lowestPlayerResistance));

            return defaultAttack;
        }

        private Resistance GetLowestPlayerResistance(List<EnemyAction> possibleAttacks)
        {
            var resistances = Player.Statistics.Defences.GetResistancesAscening();
            var lowestResistance = resistances.First().Item1;

            // if no attack contains the lowest resist damage type, try with a second lowest
            if (!possibleAttacks.Any(action => action.ActionTags.Contains(ResistanceToAttackTag(lowestResistance))))
                lowestResistance = resistances.ElementAt(1).Item1;

            return lowestResistance;
        }

        private ActionTag ResistanceToAttackTag(Resistance resistance)
        {
            switch (resistance) 
            {
                case Resistance.Base:
                    return ActionTag.Basic;
                case Resistance.Fire:
                    return ActionTag.Fire;
                case Resistance.Frost:
                    return ActionTag.Frost;
                case Resistance.Lightning:
                    return ActionTag.Lightning;
                case Resistance.Magic:
                    return ActionTag.Magic;
                default:
                    return ActionTag.Basic;
            }
        }

        private EnemyAction GetElementalAttack(List<EnemyAction> actions, EnemyAction defaultAction, ActionTag element)
        {
            var attacks = actions.FindAll(action => action.ActionTags.Contains(element));

            if (attacks.Count == 0)
                return defaultAction;

            return GetRandomElement(attacks);
        }
    }
}
