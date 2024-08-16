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
    public class DungeonScene2 : Scene
    {
        public DungeonScene2(Game game) : base(game)
        {
            map = new bool[,]
           {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true,  true, false, false,  true,  true, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true,  true, false, false,  true,  true, false },
                { false, false,  true,  true, false,  true, false, false,  true,  true, false, false,  true,  true, false },
                { false, false,  true,  true, false,  true,  true, false,  true,  true, false, false,  true,  true, false },
                { false, false,  true, false, false,  true,  true, false,  true,  true, false, false,  true,  true, false },
                { false, false,  true, false,  true,  true,  true, false,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true, false,  true,  true,  true, false,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true, false,  true, false, false, false,  true,  true,  true, false,  true,  true, false },
                { false,  true, false, false,  true,  true,  true, false,  true,  true, false, false,  true,  true, false },
                { false,  true, false,  true,  true,  true,  true, false,  true,  true, false, false,  true,  true, false },
                { false,  true, false, false, false,  true,  true, false,  true,  true, false, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false,  true,  true, false, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false,  true,  true, false, false,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
           };

            playerPos = new Point(1, 1);
            gameObjects = new List<GameObject>();

            Place dungeon1 = new Place(this);
            dungeon1.pos = new Point(1, 1);
            dungeon1.simbol = '●';
            dungeon1.color = ConsoleColor.Red;
            dungeon1.destination = SceneType.Dungeon1;

            Place dungeon3 = new Place(this);
            dungeon3.pos = new Point(13, 7);
            dungeon3.simbol = '●';
            dungeon3.color = ConsoleColor.Red;
            dungeon3.destination = SceneType.Dungeon3;

            gameObjects.Add(dungeon1);
            gameObjects.Add(dungeon3);

            Monster octa1 = MonsterFactory.AddMonster(this, "옥타록");
            octa1.pos = new Point(2, 5);

            Monster octa2 = MonsterFactory.AddMonster(this, "옥타록");
            octa2.pos = new Point(5, 3);

            Monster lionel1 = MonsterFactory.AddMonster(this, "라이넬");
            lionel1.pos = new Point(11, 7);

            gameObjects.Add(octa1);
            gameObjects.Add(octa2);
            gameObjects.Add(lionel1);
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
