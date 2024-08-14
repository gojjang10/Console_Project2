using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Players;
using TestRPG.Scenes;

namespace TestRPG.GameObjects
{
    public class Item : GameObject
    {
        public string name;
 

        public Item(Scene scene) : base(scene)
        {

        }

        public override void Interaction(Player player)
        {
            if(this.name == "마스터 소드")
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("                                         ");
                Console.WriteLine("                   *                   ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                 *****                      ");
                Console.WriteLine("                  ***                  ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("            ***** *** *****                   ");
                Console.WriteLine("           **   *******   **                  ");
                Console.WriteLine("          *       ***       *              ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                 *****                     ");
                Console.WriteLine("                 *****                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                      ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                     ");
                Console.WriteLine("                  ***                    ");
                Console.WriteLine("                   *                     ");
                Console.WriteLine("                                         ");
                Console.WriteLine("======================================");
                Console.WriteLine("땅에 꽂혀있는 성검 마스터 소드를 얻었다!");
                Thread.Sleep(2000);

                Console.WriteLine("\n검을 뽑은자여...\n");
                Thread.Sleep(2000);
                Console.WriteLine("정진하여라...!\n");
                Thread.Sleep(3000);

                inventory.AddItem(this);
            }
        }
    }
}
