﻿namespace TestRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
}
// 처음으로 진행했었던 콘솔 프로젝트를 다시 리팩토링 하는 방향으로 목표를 설정하고 두번째 프로젝트 진행해보았습니다.

// 가장 우선시 되어야하는 목표가 기존에 있었던 기능들을 구현하는 것이였고 목표는 달성했다고 생각합니다.
// 다음으로 추가하고 싶었던 기능들을 나열해보자면

// 1.   bool 타입 맵이 아닌 int 형 맵으로 하여 정수마다 다양한 색과 모양을 가지고 있는 문양을 저장해서 다채로운 색 조합으로 맵을 좀 더 생동감 있게 구현하고자 하였습니다.
//      제공해주신 샘플 위에 리팩토링을 진행해서 구현을 마치고 어떤 기능을 추가해야할까 생각했을때 떠올랐던 아이디어라 시간 관계상 다시 뜯어고치는 시간이 부족했습니다ㅠ

// 2.   인벤토리 씬을 만들어서 맵을 이동할 수 있는 상태일땐 어디서든 인벤토리를 확인해볼 수 있게 구현은 하였지만
//      실질적으로 현재 게임에서 아이템의 의미가 있는 아이템은 "마스터 소드" 밖에 없는 상태입니다.
//      그렇기에 아이템을 더 추가하여 아이템들마다 고유한 능력들과 플레이어에 영향을 주거나 이동 할 수 없는 곳을 갈 수 있게 해주는 기능들을 추가해주고 싶었습니다. 

// 3.   배틀씬의 밸런싱을 좀 더 흥미진진하게 바꾸고자 하였습니다.
//      현재 배틀씬은 랜덤값을 받아와서 단순 확률게임으로 데미지를 주고, 받고, HP회복에 성공하거나 실패하는 단조로운 구성을 가지고 있습니다.
//      아이템을 사용해서 플레이어의 공격력이나 방어력을 올려준 상태로 배틀에 진입하게 하거나 배틀씬 안에서 아이템을 사용할 수 있게 만들면 좋을 것 같다고 생각했습니다.
//      그리고 현재 구현되어있는 단순 확률게임을 정수형 랜덤값을 받아서 진행하는 것이 아닌 더블형을 받아와서 공격 명중률 같은 개념을 도입해보면 어떨까 생각했습니다.
//      또한 현재 전투는 이기거나 지거나 어떤 경우여도 전투가 종료되면 다시 플레이어의 체력은 처음 가지고 있던 체력으로 초기화됩니다.
//      때문에 전투를 할때마다 긴장감이 느껴지기보단 그저 단순 반복인 느낌이 강합니다.
//      전투에서 입은 피해를 저장하고 다음 전투를 진행했을때도 피해를 입은 상태의 HP로 진행하게 만들어야 더욱 흥미진진한 게임이 될 것 같다고 생각했습니다.
//      (체력 회복 아이템을 만들어서 체력을 보충하게 한다거나 몬스터를 처치했을때 나오는 전리품으로 회복, 골드 개념을 사용해서 상점씬을 만들어 아이템을 구매하는 기능)

// 4.   키를 꾹 누르거나 화면이 전환되거나할때 미리 키를 입력해놓으면 다음 게임진행이 미리 진행되는 것을 방지하는 기능을 추가해야겠다고 생각했습니다.

// 5.   텍스트로 진행하는 RPG게임이 아닌 직접 플레이어의 좌표를 찍어서 이동시키는 방식이기에 시각적인 부분이 중요하다고 생각하는데
//      이동할때마다 Console.Clear()를 사용하여 맵을 다시 그리는 방식으로 랜더링을 하고있는 코드이기에
//      현재 게임은 이동할때마다 깜빡이는 현상이 매끄럽지 못하다고 생각했습니다.
//      그래서 교수님이 지나가듯 말씀하신 이중버퍼를 나중에 적용해보면 더 매끄러운 게임이 되지않을까 생각이 들어서 구현하면 좋겠다고 생각했습니다. 
