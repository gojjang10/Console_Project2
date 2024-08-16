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
    public class DungeonScene3 : Scene
    {
        public DungeonScene3 (Game game) : base(game)
        {
            map = new bool[,]
           {                                                                                                 
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
           };

            playerPos = new Point(1, 1);
            gameObjects = new List<GameObject>();

            Place dungeon2 = new Place(this);
            dungeon2.pos = new Point(1, 1);
            dungeon2.simbol = '●';
            dungeon2.color = ConsoleColor.Red;
            dungeon2.destination = SceneType.Dungeon2;

            gameObjects.Add(dungeon2);

            Monster ganon = MonsterFactory.AddMonster(this, "가논");
            ganon.pos = new Point(7, 7);

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
            prePos = playerPos;
            Move();
            Interaction();
        }
    }
}
