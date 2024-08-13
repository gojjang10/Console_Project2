using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.GameObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestRPG.Scenes
{
    public class VillageScene : Scene
    {
        private bool[,] map;
        private Point playerPos;

        private List<GameObject> gameObjects;

        private ConsoleKey input;

        public VillageScene(Game game) : base(game)
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

            playerPos = new Point(1, 1);
            gameObjects = new List<GameObject>();

            Place town = new Place(this);
            town.pos = new Point(1, 1);
            town.simbol = 'T';
            town.color = ConsoleColor.Yellow;
            town.destination = SceneType.Town;

            Place shop = new Place(this);
            shop.pos = new Point(5, 1);
            shop.color = ConsoleColor.Gray;
            shop.simbol = 'S';
            shop.destination = SceneType.Shop;

            gameObjects.Add(town);
            gameObjects.Add(shop);

            Monster monster1 = new Monster(this);
            monster1.name = "슬라임";
            monster1.color = ConsoleColor.Red;
            monster1.simbol = 'S';
            monster1.attack = 10;
            monster1.defense = 10;
            monster1.hp = 50;
            monster1.pos = new Point(5, 5);

            Monster monster2 = new Monster(this);
            monster2.name = "오크";
            monster2.color = ConsoleColor.Red;
            monster2.simbol = 'O';
            monster2.attack = 30;
            monster2.defense = 20;
            monster2.hp = 100;
            monster2.pos = new Point(4, 6);

            gameObjects.Add(monster1);
            gameObjects.Add(monster2);
        }

        public override void Enter()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine("숲으로 이동합니다...");
            Thread.Sleep(2000);
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

        private void PrintMap()
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }

        private void PrintGameObject()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Console.SetCursorPosition(gameObject.pos.X, gameObject.pos.Y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.simbol);
                Console.ResetColor();
            }
        }

        private void PrintPlayer()
        {
            Console.SetCursorPosition(playerPos.X, playerPos.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }

        private void Move()
        {
            Point next = playerPos;

            switch (input)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    next = new Point(playerPos.X, playerPos.Y - 1);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    next = new Point(playerPos.X, playerPos.Y + 1);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    next = new Point(playerPos.X - 1, playerPos.Y);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    next = new Point(playerPos.X + 1, playerPos.Y);
                    break;
            }

            if (map[next.Y, next.X])
            {
                playerPos = next;
            }
        }

        private void Interaction()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                if (playerPos.X == gameObject.pos.X &&
                    playerPos.Y == gameObject.pos.Y)
                {
                    gameObject.Interaction(game.Player);
                    if (gameObject.removeWhenInteract)
                    {
                        gameObjects.Remove(gameObject);
                    }
                    return;
                }
            }
        }
    }
}
