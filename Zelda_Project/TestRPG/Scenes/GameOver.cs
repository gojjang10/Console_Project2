using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG.Scenes
{
    public class GameOver : Scene
    {
        public GameOver(Game game) : base(game)
        {

        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            
        }

        public override void Render()
        {
            Console.CursorVisible = false;
            Console.Clear();

            Console.WriteLine("하이랄 대륙에 안개가 걷히고..");
            Thread.Sleep(1000);
            Console.WriteLine("파란 하늘과 함께 빛을 띄기 시작합니다...");
            Thread.Sleep(1000);

            Console.WriteLine("==========================================================================================");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                       Game Over                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("==========================================================================================");
            game.IsRunning = false;
        }

        public override void Update()
        {
            
        }
    }
}
