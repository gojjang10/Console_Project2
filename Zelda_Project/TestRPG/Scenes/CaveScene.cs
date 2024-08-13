using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.GameObjects;
using TestRPG.Players;

namespace TestRPG.Scenes
{
    public class CaveScene : Scene
    {
        
        public CaveScene(Game game) : base(game)
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

            playerPos = new Point(5, 6);
            gameObjects = new List<GameObject>();

            Place village = new Place(this);
            village.pos = new Point(6, 6);
            village.simbol = '●';
            village.color = ConsoleColor.Yellow;
            village.destination = SceneType.Village;

            gameObjects.Add(village);

            Item sword = new Item(this);
            sword.name = "마스터 소드";
            sword.pos = new Point(3, 1);
            sword.simbol = '↓';
            sword.color = ConsoleColor.Yellow;
            sword.removeWhenInteract = true;

            gameObjects.Add(sword);

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
