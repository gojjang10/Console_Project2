using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.GameObjects;
using TestRPG.Monsters;

namespace TestRPG.Scenes
{
    public class DungeonScene : Scene
    {
        public DungeonScene (Game game) : base(game)
        {
            map = new bool[,]
           {
                { false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false },
           };

            playerPos = new Point(2, 1);
            gameObjects = new List<GameObject>();

            Place village = new Place(this);
            village.pos = new Point(1, 1);
            village.simbol = '●';
            village.color = ConsoleColor.Yellow;
            village.destination = SceneType.Village;

            gameObjects.Add(village);

            Monster ganon = new Monster(this);
            ganon.name = "가논";
            ganon.color = ConsoleColor.Red;
            ganon.simbol = '◈';
            ganon.curHp = 100;
            ganon.attack = 30;
            ganon.defense = 20;
            ganon.pos = new Point(6, 6);
            ganon.removeWhenInteract = false;

            gameObjects.Add(ganon);
        }

        public override void Enter()
        {
            Console.CursorVisible = false;
            Console.Clear();
        }

        public override void Exit()
        {
            Console.CursorVisible = true;
        }

        public override void Input()
        {
            input = Console.ReadKey().Key;
        }

        public override void Render()
        {
            Console.Clear();
            PrintMap();
            PrintGameObject();
            PrintPlayer();
        }

        public override void Update()
        {
            Move();
            Interaction();
        }
    }
}
