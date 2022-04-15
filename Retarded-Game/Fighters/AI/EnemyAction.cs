using System.Collections.Generic;
using Retarded_Game.BasicStructures.Enums;

namespace Retarded_Game.Fighters.AI
{
    delegate void EnemyAttack(Fighter enemy, Player player);
    internal class EnemyAction
    {
        event EnemyAttack Use;
        Fighter Enemy;
        Player Player;
        public int ManaCost { get; }
        public ActionTag Type { get; }
        public List<ActionTag> ActionTags { get; }

        public EnemyAction(Fighter enemy, Player player, int manaCost, List<ActionTag> tags, EnemyAttack attack)
        {
            Enemy = enemy;
            Player = player;
            ManaCost = manaCost;
            ActionTags = tags;
            Use = attack;
        }

        public void TakeAction()
        {
            Enemy.Statistics.BaseStats.CurrentMana -= ManaCost;
            Use(Enemy, Player);
        }
    }
}
