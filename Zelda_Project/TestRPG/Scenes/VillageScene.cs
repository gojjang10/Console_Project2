using System.Drawing;
using TestRPG.GameObjects;
using TestRPG.Players;
using TestRPG;

namespace TestRPG.Scenes
{
    public class VillageScene : Scene
    {
        public Player player;
        public VillageScene(Game game) : base(game)
        {
            map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true,  true,  true, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true,  true, false,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true, false },
                { false,  true,  true, false,  true,  true, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false, false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };

            playerPos = new Point(7, 8);
            gameObjects = new List<GameObject>();

            Place cave = new Place(this);
            cave.pos = new Point(1, 1);
            cave.simbol = '●';
            cave.color = ConsoleColor.Yellow;
            cave.destination = SceneType.Cave;

            Place dungeon = new Place(this);
            dungeon.pos = new Point(13, 8);
            dungeon.color = ConsoleColor.Red;
            dungeon.simbol = '●';
            dungeon.destination = SceneType.Dungeon1;

            gameObjects.Add(cave);
            gameObjects.Add(dungeon);
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



