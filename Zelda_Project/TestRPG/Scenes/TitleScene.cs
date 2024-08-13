using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPG.Scenes
{
    public class TitleScene : Scene
    {
        public TitleScene(Game game) : base(game)
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
            Console.ReadKey();
        }

        public override void Render()
        {
            Console.CursorVisible = false; //커서는 안보이게
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("                                               *                                          ");
            Console.WriteLine("                                              ***                                         ");
            Console.WriteLine("                                             *****                                        ");
            Console.WriteLine("                                            *******                                       ");
            Console.WriteLine("                                           *********                                      ");
            Console.WriteLine("                                          ***********                                     ");
            Console.WriteLine("                                         *************                                    ");
            Console.WriteLine("                                        ***************                                   ");
            Console.WriteLine("                                       *               *                                  ");
            Console.WriteLine("                                      ***             ***                                 ");
            Console.WriteLine("                                     *****           *****                                ");
            Console.WriteLine("                                    *******         *******                               ");
            Console.WriteLine("                                   *********       *********                              ");
            Console.WriteLine("                                  ***********     ***********                             ");
            Console.WriteLine("                                 *************   *************                            ");
            Console.WriteLine("                                *******************************                           ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                      The Legend Of Zelda                                 ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("                                                                                          ");
            Console.WriteLine("==========================================================================================");

            Console.WriteLine("Please any key");
        }

        public override void Update()
        {
            Console.Clear(); // 콘솔 창 정리

            Console.WriteLine("링크...");
            Thread.Sleep(1000);
            Console.WriteLine("눈을 뜨세요........ ");
            Thread.Sleep(1000);
            Console.WriteLine("가논을 쓰러트리고 하이랄을 되찾아 주세요........");
            Thread.Sleep(2000);

            game.ChangeScene(SceneType.Village);
        }
    }
}
