using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPG.Monsters;
using TestRPG.Players;
using TestRPG.Scenes;

namespace TestRPG
{
    public class Game
    {
        private bool isRunning;
        public bool IsRunning { set { isRunning = value; } }

        public Inventory inventory = new Inventory();

        private Scene[] scenes;
        private Scene curScene;
        private Scene prevScene;
        public Scene CurScene { get { return curScene; } }

        private Player player = new Player();
        public Player Player { get { return player; } set { player = value; } }

        public void Run()
        {
            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
            End();
        }

        public void ChangeScene(SceneType sceneType)
        {
            curScene.Exit();
            curScene = scenes[(int)sceneType];
            curScene.Enter();
        }
        public void ReturnScene()
        {
            curScene.Exit();
            curScene = prevScene;
            curScene.playerPos = prevScene.prePos;

            curScene.Enter();
        }

        public void StartBattle(Monster monster)
        {
            prevScene = curScene;  
            curScene.Exit();
            curScene = scenes[(int)SceneType.Battle];
            BattleScene battleScene = (BattleScene)curScene;
            battleScene.SetBattle(player, monster);
            curScene.Enter();
        }

        public void Over()
        {
            isRunning = false;
        }

        private void Start()
        {
            isRunning = true;

            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Title] = new TitleScene(this);

            scenes[(int)SceneType.Village] = new VillageScene(this);
            scenes[(int)SceneType.Cave] = new CaveScene(this);
            scenes[(int)SceneType.Dungeon1] = new DungeonScene1(this);
            scenes[(int)SceneType.Dungeon2] = new DungeonScene2(this);
            scenes[(int)SceneType.Dungeon3] = new DungeonScene3(this);
            scenes[(int)SceneType.Battle] = new BattleScene(this);
            scenes[(int)SceneType.GameOver] = new GameOver(this);

            curScene = scenes[(int)SceneType.Title];
            curScene.Enter();
        }

        private void End()
        {
            curScene.Exit();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }

        private void Update()
        {
            curScene.Update();
        }
    }
}
