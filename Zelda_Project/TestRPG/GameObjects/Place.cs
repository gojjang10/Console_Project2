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
            game.ChangeScene(destination);
        }
    }
}
