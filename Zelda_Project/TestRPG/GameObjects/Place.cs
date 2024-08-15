using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;
using TestRPG.Scenes;

namespace TestRPG.GameObjects
{
    public class Place : GameObject
    {
        public SceneType destination;

        public Place(Scene scene) : base(scene)
        {

        }

        public override void Interaction(Player player)
        {
            if(destination == SceneType.Dungeon3)
            {
                if (game.inventory.IsHaveItem("마스터 소드"))
                {
                    game.ChangeScene(destination);
                }
                else
                {
                    Console.Clear();
                    Console.Write("위험해보인다. 나를 지킬 수 있는 것을 찾아보자.");
                    Thread.Sleep(2000);
                    return;
                }
            }

            game.ChangeScene(destination);
        }
    }
}
