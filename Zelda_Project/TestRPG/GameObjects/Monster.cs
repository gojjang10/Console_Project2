using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.GameObjects;
using TestRPG.Players;
using TestRPG.Scenes;

namespace TestRPG.Monsters
{
    public class Monster : GameObject
    {
        public string name;

        public int curHp;
        public int maxHp;
        public int attack;
        public int defense;

        public Monster(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            game.StartBattle(this);
        }
    }
}
