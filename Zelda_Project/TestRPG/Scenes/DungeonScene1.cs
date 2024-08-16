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
    public class DungeonScene1 : Scene
    {
        public DungeonScene1(Game game) : base(game)
        {
            map = new bool[,]
           {
                { false, false, false, false, false, false, false, false },
                { false,  true, false,  true,  true,  true, false, false },
                { false,  true, false,  true, false,  true, false, false },
                { false,  true, false,  true, false,  true, false, false },
                { false,  true,  true,  true, false,  true,  true, false },
                { false,  true, false,  true, false, false,  true, false },
                { false,  true,  true, false, false,  true,  true, false },
                { false,  true,  true, false,  true,  true,  true, false },
                { false, false,  true, false,  true, false,  true, false },
                { false,  true,  true, false,  true, false,  true, false },
                { false,  true, false,  true,  true, false,  true, false },
                { false,  true, false,  true,  true, false,  true, false },
                { false,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false },
           };

            playerPos = new Point(1, 1);
            gameObjects = new List<GameObject>();

            Place village = new Place(this);
            village.pos = new Point(1, 1);
            village.simbol = '●';
            village.color = ConsoleColor.Yellow;
            village.destination = SceneType.Village;

            Place dungeon2 = new Place(this);
            dungeon2.pos = new Point(6, 7);
            dungeon2.simbol = '●';
            dungeon2.color = ConsoleColor.Red;
            dungeon2.destination = SceneType.Dungeon2;

            gameObjects.Add(village);
            gameObjects.Add(dungeon2);

            Monster octa1 = MonsterFactory.AddMonster(this, "옥타록");
            octa1.pos = new Point(2, 4);

            Monster octa2 = MonsterFactory.AddMonster(this, "옥타록");
            octa2.pos = new Point(1, 5);
            
            Monster octa3 = MonsterFactory.AddMonster(this, "옥타록");
            octa3.pos = new Point(6, 5);
           
            Monster octa4 = MonsterFactory.AddMonster(this, "옥타록");
            octa4.pos = new Point(4, 8);
            
            Monster octa5 = MonsterFactory.AddMonster(this, "옥타록");
            octa5.pos = new Point(6, 9);

            gameObjects.Add(octa1);
            gameObjects.Add(octa2);
            gameObjects.Add(octa3);
            gameObjects.Add(octa4);
            gameObjects.Add(octa5);
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
