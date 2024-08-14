using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.GameObjects;

namespace TestRPG.Scenes
{
    public abstract class Scene
    {
        public bool[,] map;
        public Point playerPos;

        public List<GameObject> gameObjects;

        public ConsoleKey input;

        public Game game;

        public Scene(Game game)
        {
            this.game = game;
        }

        public abstract void Enter();
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Exit();

        protected void PrintMap()
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
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("■");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                Console.WriteLine();
            }
        }

        protected void PrintGameObject()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Console.SetCursorPosition(gameObject.pos.X, gameObject.pos.Y);
                Console.ForegroundColor = gameObject.color;
                Console.Write(gameObject.simbol);
                Console.ResetColor();
            }
        }

        protected void PrintPlayer()
        {
            Console.SetCursorPosition(playerPos.X, playerPos.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("●");
            Console.ResetColor();
        }

        protected void Move()
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

        protected void Interaction()
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
