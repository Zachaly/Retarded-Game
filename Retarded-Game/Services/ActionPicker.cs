using System;
using System.Collections.Generic;
using Retarded_Game.Models.BasicStructures.Enums;
using System.Linq;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Fighters.AI;

namespace Retarded_Game.Services
{
    /// <summary>
    /// Class used by AI to pick best action during fight
    /// </summary>
    public sealed class ActionPicker
    {
        private readonly Player _player;
        private readonly Enemy _enemy;
        private readonly List<EnemyAction> _actions;
        private static readonly Random _random = new Random();
        private bool _actionPicked = false;

        public ActionPicker(Enemy enemy, List<EnemyAction> actions, Player player)
        {
            _enemy = enemy;
            _actions = actions;
            _player = player;
        }

        private EnemyAction GetRandomElement(List<EnemyAction> list) => list[_random.Next(0, list.Count)];

        public EnemyAction GetAction()
        {
            EnemyAction action = new EnemyAction(_enemy, _player, 0, new List<ActionTag>(), (_, __) => { });

            if (_enemy.Statistics.BaseStats.CurrentHP < _enemy.Statistics.BaseStats.MaxHP * 0.3)
                action = GetHealingAction(action);
            else if (_enemy.Statistics.BaseStats.CurrentMana < _actions.MinBy(action => action.ManaCost).ManaCost)
                action = GetActionByTag(_actions, action, ActionTag.ManaRegeneration);
            if (!_actionPicked)
                action = GetOffensiveAction(_actions);

            return action;
        }

        private EnemyAction GetHealingAction(EnemyAction defaultAction)
        {
            var healingActions = _actions.FindAll(action => action.ActionTags.Contains(ActionTag.Healing));
            healingActions = healingActions.FindAll(action => action.ManaCost <= _enemy.Statistics.BaseStats.CurrentMana);

            if (healingActions.Count == 0)
                return defaultAction;

            // if player hp is below 25% and you have attack that heals you, return that attack
            if (_player.Statistics.BaseStats.CurrentHP <= _player.Statistics.BaseStats.CurrentHP * 0.25
                && healingActions.Any(action => action.ActionTags.Contains(ActionTag.Attack)))
                return GetOffensiveAction(healingActions);

            return GetRandomElement(healingActions);
        }

        private EnemyAction GetOffensiveAction(List<EnemyAction> actions)
        {
            var attacks = actions.FindAll(action => action.ActionTags.Contains(ActionTag.Attack));
            attacks = attacks.FindAll(action => action.ManaCost <= _enemy.Statistics.BaseStats.CurrentMana);

            EnemyAction defaultAttack = GetRandomElement(attacks);

            Resistance lowestPlayerResistance = GetLowestPlayerResistance(attacks);

            defaultAttack = GetActionByTag(attacks, defaultAttack, ResistanceToAttackTag(lowestPlayerResistance));

            return defaultAttack;
        }

        private Resistance GetLowestPlayerResistance(List<EnemyAction> possibleAttacks)
        {
            var resistances = _player.Statistics.Defences.GetResistancesAscending();
            var lowestResistance = resistances.First().Item1;

            // if no attack contains the lowest resist damage type, try with a second lowest
            if (!possibleAttacks.Any(action => action.ActionTags.Contains(ResistanceToAttackTag(lowestResistance))))
                lowestResistance = resistances.ElementAt(1).Item1;

            return lowestResistance;
        }

        /// <summary>
        /// Converts given resistances to appropriate action tag
        /// </summary>
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

        private EnemyAction GetActionByTag(List<EnemyAction> actions, EnemyAction defaultAction, ActionTag element)
        {
            var attacks = actions.FindAll(action => action.ActionTags.Contains(element));

            if (attacks.Count == 0)
                return defaultAction;

            return GetRandomElement(attacks);
        }
    }
}
