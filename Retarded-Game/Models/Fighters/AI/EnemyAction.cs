using System.Collections.Generic;
using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Models.Fighters.AI
{
    public delegate void EnemyAttack(Fighter enemy, Player player);
    public sealed class EnemyAction
    {
        event EnemyAttack _use;
        Fighter _enemy;
        Player _player;
        public int ManaCost { get; }
        public ActionTag Type { get; }
        public List<ActionTag> ActionTags { get; }

        public EnemyAction(Fighter enemy, Player player, int manaCost, List<ActionTag> tags, EnemyAttack attack)
        {
            _enemy = enemy;
            _player = player;
            ManaCost = manaCost;
            ActionTags = tags;
            _use = attack;
        }

        public void TakeAction()
        {
            _enemy.Statistics.BaseStats.CurrentMana -= ManaCost;
            _use(_enemy, _player);
        }
    }
}
