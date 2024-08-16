using TestRPG.Monsters;
using TestRPG.Players;

namespace TestRPG.Scenes
{
    public class BattleScene : Scene
    {
        private Monster monster;
        private Player player;
        Random randomValue = new Random();

        public BattleScene(Game game) : base(game)
        {
        }
        public void SetBattle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;

            this.player.MaxHP = this.player.CurHP;
            this.monster.maxHp = this.monster.curHp;
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine($"{monster.name} 이/가 나타났다!");
            Thread.Sleep(2000);
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            // TODO : 전투 입력
            input = Console.ReadKey().Key;
            Console.Write("\b");
        }

        public override void Render()
        {
            // TODO : 전투 상황 출력
            Console.Clear();
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"현재 링크의 HP : {player.CurHP}");
            Console.WriteLine($"현재 링크의 공격력 : {player.Attack}");
            Console.WriteLine($"현재 링크의 방어력 : {player.Defense}");
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"현재 {monster.name}의 HP : {monster.curHp}");
            Console.WriteLine($"현재 {monster.name}의 공격력 : {monster.attack}");
            Console.WriteLine("=======================================================================");

            Console.WriteLine("\n행동을 고르세요");
            Console.WriteLine("\n1. 공격\n2. 방어(성공 시 방어력만큼 HP회복)");
        }

        public override void Update()
        {
            // TODO : 전투 진행
            Fight();
        }

        public void RestHealth()
        {
            player.CurHP = player.MaxHP;
            monster.curHp = monster.maxHp;
        }

        public void Fight()
        {
            int playerRandom;
            int monsterRandom;

            playerRandom = randomValue.Next(0, 3);  
            monsterRandom = randomValue.Next(0, 3);

            if (input == ConsoleKey.D1)
            //  공격 선택시
            {
                if (playerRandom > monsterRandom)
                {
                    monster.curHp -= player.Attack;
                    Console.WriteLine();
                    Console.WriteLine("공격에 성공하였습니다.");
                    Thread.Sleep(1000);
                   
                    if (monster.curHp <= 0)
                    {
                        Win();
                    }
                }
                else if (playerRandom < monsterRandom)
                {
                    Console.WriteLine();
                    Console.WriteLine("공격에 실패하였습니다.\n");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{monster.name} 이/가 공격해옵니다.");
                    Thread.Sleep(1000);
                    player.CurHP -= monster.attack;
                    
                    if (player.CurHP <= 0)
                    {
                        Lose();
                    }
                }

                else if (playerRandom == monsterRandom)
                {
                    Console.WriteLine();
                    Console.WriteLine("서로가 공격하여 공격이 상쇄되었습니다.");
                    Thread.Sleep(1000);
                }

            }

            else if (input == ConsoleKey.D2)
            //  방어 선택시
            {
                if(playerRandom > monsterRandom)
                {
                    player.CurHP += player.Defense;
                    Console.WriteLine();
                    Console.WriteLine("방어에 성공하였습니다.");
                    Thread.Sleep(1000);

                }

                else if(playerRandom < monsterRandom)
                {
                    player.CurHP -= monster.attack;
                    Console.WriteLine();
                    Console.WriteLine("방어에 실패하였습니다.");
                    Thread.Sleep(1000);

                    if (player.CurHP <= 0)
                    {
                        Lose();
                    }
                }

                else if(playerRandom == monsterRandom)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{monster.name}의 공격이 빗나갔습니다.");
                    Thread.Sleep(1000);
                }


            }

            else
            //  잘못 입력시
            {
                Console.WriteLine();
                Console.WriteLine("잘못 입력하였습니다. 알맞은 숫자를 입력해주세요.");
                Thread.Sleep(1000);
            }

        }


        public void Win()
        {
            RestHealth();
            monster.RemoveMonster(monster);
            game.ReturnScene();
           
            if (monster.name == "가논")
            {
                game.ChangeScene(SceneType.GameOver);
            }
        }

        public void Lose()
        {

            Console.Clear();
            Console.WriteLine("전투에서 패배하였습니다...");
            Thread.Sleep(1000);
            RestHealth();


            game.ReturnScene();

        }
    }
}

