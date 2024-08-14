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
        bool win = false;

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
            Console.Write("\b");
        }

        public override void Render()
        {
            // TODO : 전투 상황 출력
            Console.Clear();
            Console.WriteLine($"현재 링크의 HP : {player.CurHP}");
            Console.WriteLine($"현재 {monster.name}의 HP : {monster.curHp}");

            Console.WriteLine("\n행동을 고르세요");
            Console.WriteLine("\n1. 공격\n2. 방어(성공 시 HP회복)");
        }

        public override void Update()
        {
            // TODO : 전투 진행
            if (monster.curHp > 0)
            {
                if (input == ConsoleKey.D1)
                {
                    monster.curHp -= player.Attack;
                    Console.WriteLine("공격에 성공하였습니다.");
                    Thread.Sleep(1000);

                    if (monster.curHp <= 0)
                    {
                        win = true;
                        game.ReturnScene();
                        
                        if (monster.name == "가논")
                        {
                            game.ChangeScene(SceneType.GameOver);
                        }
                    }
                }

                else if (input == ConsoleKey.D2)
                {
                    player.CurHP -= monster.attack;
                    Console.WriteLine("방어에 실패하였습니다.");
                    Thread.Sleep(1000);
                    
                    if (game.Player.CurHP <= 0)
                    {
                        Console.WriteLine("전투에서 패배하였습니다...");
                        Thread.Sleep(1000);
                        RestHealth();

                        game.ReturnScene();
                    }
                }
            }
        }

        public void RestHealth()
        {
            player.CurHP = player.MaxHP;
            monster.curHp = monster.maxHp;
        }
    }
}
