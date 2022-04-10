using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Retarded_Game.Fighters.AI
{
    delegate void EnemyAttack(Fighter enemy, Player player);
    enum ActionTag
    {
        Attack,
        Spell,
        StatusEffect,
        Healing,
        Fire,
        Frost,
        Lightning,
        Magic,
        Basic,
        Buff,
        Debuff
    }

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
            Use(Enemy, Player);
        }
    }
}
