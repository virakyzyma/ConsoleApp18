namespace ConsoleApp18
{
    class Program
    {
        static void Main()
        {
            Player player = new Player();
            player.AddItem(new Item
            {
                Name = "Knife",
                Level = 2,
                Value = 20,
                Weight = 150.5f
            });

            player.AddItem(new Item
            {
                Name = "Poison",
                Level = 9,
                Value = 30,
                Weight = 20.9f
            });

            player.AddItem(new Item
            {
                Name = "Halmet",
                Level = 8,
                Value = 30,
                Weight = 220.3f
            });

            foreach (Item item in player.Inventory)
            {
                Console.WriteLine(item.Info());
            }

            player.RemoveItemByIndex(0);

            Console.WriteLine(new string('-', 40));
            foreach (Item item in player.Inventory)
            {
                Console.WriteLine(item.Info());
            }

            Console.WriteLine(player.TotalWeight);
            Console.WriteLine(player.TotalPrice);
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public decimal Value { get; set; }
        public float Weight { get; set; }

        public string Info()
        {
            return $"Name: {Name} , Lvl: {Level} , Value: {Value} , Weight: {Weight}";
        }
    }
    public class Player
    {
        public string Name { get; set; }
        private Item[] inventory;
        public Item[] Inventory
        {
            get
            { 
                return inventory; 
            }
            private set 
            { 
                inventory = value; 
            }
        }
        public Item[] GetItemsByLesel(int level)
        {
            int itemsCount = 0;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].Level == level)
                {
                    itemsCount++;
                }
            }
            Item[] items = new Item[itemsCount];
            for (int i = 0, j = 0; i < inventory.Length; i++)
            {
                if (inventory[i].Level == level)
                {
                    items[j++] = inventory[i];
                }
            }
            return items;
        }
        public float TotalWeight
        {
            get
            {
                float totalWeight = 0f;
                for (int i = 0; i < inventory.Length; i++) { totalWeight += inventory[i].Weight; }
                return totalWeight;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                for (int i = 0; i < inventory.Length; i++) 
                { 
                    totalPrice += inventory[i].Value; 
                }
                return totalPrice;
            }
        }
        public Player()
        {
            inventory = new Item[0];
        }
        public void RemoveItemByIndex(int index)
        {
            Item[] items =new Item[inventory.Length - 1];
            for (int i = 0, j = 0; i < inventory.Length; i++)
            {
                if(i == index)
                {
                    continue;
                }
                items[j++] = inventory[i];
            }
            inventory = items;
        }
        public void AddItem(Item item)
        {
            Item[] items = new Item[inventory.Length + 1];
            for (int i = 0; i < inventory.Length; i++)
            {
                items[i] = inventory[i];
            }
            items[items.Length - 1] = item;
            inventory = items;
        }
    }
}