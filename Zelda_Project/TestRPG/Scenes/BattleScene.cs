using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.Players;

namespace TestRPG.Scenes
{
    public class BattleScene : Scene
    {
        private Monster monster;
        private Player player;


        public BattleScene(Game game) : base(game)
        {
        }
        public void SetBattle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
        }

        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine($"{monster.name} 이/가 나타났다!!!");
            Thread.Sleep(2000);
        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            // TODO : 전투 입력
            input = Console.ReadKey().Key;
        }

        public override void Render()
        {
            // TODO : 전투 상황 출력
            Console.Clear();
            Console.WriteLine($"현재 링크의 HP : {player.CurHP}");
            Console.WriteLine($"현재 {monster.name}의 HP : {monster.hp}");

            Console.WriteLine("\n행동을 고르세요");
            Console.WriteLine("\n1. 공격\n2. 방어(성공 시 HP회복)");
        }

        public override void Update()
        {
            bool win = false;    // for debug
                                 // TODO : 전투 진행
            if (win)
            {
                game.ReturnScene();
            }
            else if (game.Player.CurHP <= 0)
            {
                game.ChangeScene(SceneType.GameOver);
            }

            if (monster.hp > 0)
            {
                if (input == ConsoleKey.D1)
                {
                    monster.hp -= player.Attack;
                    Console.WriteLine("공격에 성공하였습니다.");
                    Thread.Sleep(1000);
                    
                    if (monster.hp <= 0)
                    {
                        win = true;
                    }
                }

                else if (input == ConsoleKey.D2)
                {
                    monster.attack -= player.CurHP;
                    Console.WriteLine("방어에 실패하였습니다.");
                    Thread.Sleep(1000);
                }
            }



        }
    }
}
