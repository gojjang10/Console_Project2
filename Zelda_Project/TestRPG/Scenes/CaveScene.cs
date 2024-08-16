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
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true,  true, false,  true,  true,  true, false },
                { false, false, false,  true, false,  true,  true, false,  true,  true, false,  true,  true,  true, false },
                { false,  true,  true,  true, false,  true, false,  true, false,  true, false,  true,  true,  true, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true,  true, false,  true,  true,  true, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true,  true, false,  true,  true,  true, false },
                { false,  true,  true,  true, false,  true,  true,  true,  true,  true, false,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false,  true, false, false, false,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false, false, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
};
            
            playerPos = new Point(12, 13);
            gameObjects = new List<GameObject>();

            Place village = new Place(this);
            village.pos = new Point(13, 13);
            village.simbol = '●';
            village.color = ConsoleColor.Yellow;
            village.destination = SceneType.Village;

            gameObjects.Add(village);

            Item sword = ItemFactory.AddItem(this, "마스터 소드");
            sword.pos = new Point(7, 3);

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
