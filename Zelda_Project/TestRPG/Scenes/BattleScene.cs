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
        }

        public override void Render()
        {
            // TODO : 전투 상황 출력
        }

        public override void Update()
        {
            // TODO : 전투 진행

            game.ChangeScene(SceneType.Village);
        }
    }
}
