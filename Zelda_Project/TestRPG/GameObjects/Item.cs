using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestRPG.Monsters;
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
                Thread.Sleep(1000);

                Console.WriteLine("\n검을 뽑은자여...\n");
                Thread.Sleep(1000);
                Console.WriteLine("정진하여라...!\n");
                Thread.Sleep(1000);

                game.inventory.AddItem(this);
            }

            if ( this.name == "물약")
            {
                Console.Clear();
                Console.WriteLine("물약을 획득했다!");
                Thread.Sleep(1000);

                game.inventory.AddItem(this);
            }
        }
    }

    public static class ItemFactory
    {
        public static Item AddItem(Scene scene, string name)
        {
            if (name == "마스터 소드")
            {
                return new Item(scene)
                {
                    name = "마스터 소드",
                    color = ConsoleColor.Yellow,
                    simbol = '↓',
                    removeWhenInteract = true
                };
            }

            if (name == "물약")
            {
                return new Item(scene)
                {
                    name = "물약",
                    color = ConsoleColor.Blue,
                    simbol = '★',
                    removeWhenInteract = true
                };
            }
            return null;
        }
    }
}
