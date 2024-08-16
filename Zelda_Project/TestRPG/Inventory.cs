using TestRPG.GameObjects;

namespace TestRPG
{
    public class Inventory
    {
        public List<Item> slots = new List<Item>();

        public void AddItem(Item item)
        {
            slots.Add(item);
        }

        public bool IsHaveItem(string name)
        {
            foreach (Item item in slots)
            {
                if (name == item.name)
                {
                    return true;
                }
            }
            return false;
        }

        public void ShowItem()
        {
            Console.WriteLine("==========================================");
            Console.Write("소유하고 있는 아이템: ");
            for (int i = 0; i < slots.Count; i++)
            {
                Console.WriteLine($"{i} : {slots[i].name} ");
            }
            Console.WriteLine();
            Console.WriteLine("==========================================");
        }

        public void UseItem(int index)
        {
            if (index >= 0 && index < slots.Count)
            {
                Console.WriteLine($"{slots[index].name} 아이템을 사용하여 제거되었습니다.");
                Thread.Sleep(2000);
                slots.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("잘못된 수를 입력하였습니다. 다시 입력해주세요.");
            }
        }

    }
}




