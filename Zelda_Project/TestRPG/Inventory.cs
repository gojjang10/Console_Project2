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

        public void RemoveItem(Item item)
        {
            slots.Remove(item);
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

    }
}




