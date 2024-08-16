namespace TestRPG.Scenes
{
    public class InventoryScene : Scene
    {
        public InventoryScene(Game game) : base(game)
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
            input = Console.ReadKey().Key;
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("==========================================================");
            Console.WriteLine("                         인벤토리                         ");
            Console.WriteLine("==========================================================");
            game.Player.ShowInfo();
            Console.WriteLine();
            game.inventory.ShowItem();
        }

        public override void Update()
        {
            int itemNum;
            if (input == ConsoleKey.I)
            {
                game.ReturnScene();
            }

            if (input == ConsoleKey.D0)
            {
                itemNum = 0;
                game.inventory.UseItem(itemNum);
            }

            if (input == ConsoleKey.D1)
            {
                itemNum = 1;
                game.inventory.UseItem(itemNum);
            }
            if (input == ConsoleKey.D2)
            {
                itemNum = 2;
                game.inventory.UseItem(itemNum);
            }

        }
    }
}
