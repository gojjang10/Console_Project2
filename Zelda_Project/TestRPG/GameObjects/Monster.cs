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

    public static class MonsterFactory
    {
        public static Monster AddMonster(Scene scene, string name) 
        {
            if (name == "가논")
            {
                return new Monster(scene)
                {
                    name = "가논",
                    curHp = 100,
                    maxHp = 100,
                    attack = 30,
                    defense = 20,
                    color = ConsoleColor.Red,
                    simbol = '◈'
                };
            }

            else if ( name == "옥타록")
            {
                return new Monster(scene)
                {
                    name = "옥타록",
                    curHp = 30,
                    maxHp = 30,
                    attack = 5,
                    defense = 5,
                    color = ConsoleColor.Red,
                    simbol = '●'
                };
            }

            else if (name == "라이넬")
            {
                return new Monster(scene)
                {
                    name = "라이넬",
                    curHp = 50,
                    maxHp = 50,
                    attack = 15,
                    defense = 10,
                    color = ConsoleColor.Red,
                    simbol = '♠'
                };
            }
            return null;
        }
    }
}
