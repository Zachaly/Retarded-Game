using System;
using System.Collections.Generic;
using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Models.Fighters.AI
{
    public delegate void EnemyAttack(Fighter enemy, Player player);
    public sealed class EnemyAction
    {
        Action<Enemy, Player> _attack;
        Enemy _enemy;
        Player _player;
        public int ManaCost { get; }
        public ActionTag Type { get; }
        public List<ActionTag> ActionTags { get; }

        public EnemyAction(Enemy enemy, Player player, int manaCost, List<ActionTag> tags, Action<Enemy, Player> attack)
        {
            _enemy = enemy;
            _player = player;
            ManaCost = manaCost;
            ActionTags = tags;
            _attack = attack;
        }

        public void TakeAction()
        {
            _enemy.Statistics.BaseStats.CurrentMana -= ManaCost;
            _attack(_enemy, _player);
        }
    }
}
