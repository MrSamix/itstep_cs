using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Exam
{
    public class Hero : GameObject
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public Dictionary<string, int> Inventory { get; set; }

        public Hero(string name, Position pos)
            : base(name, pos)
        {
            Health = 100;
            Strength = 10;
            Defense = 5;
            Inventory = new Dictionary<string, int>();
        }

        public void AddResource(string resourceType, int amount)
        {
            if (Inventory.ContainsKey(resourceType))
                Inventory[resourceType] += amount;
            else
                Inventory[resourceType] = amount;
        }

        public void ShowInventory()
        {
            Console.WriteLine("\nІнвентар:");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("\tПорожній");
            }
            else
            {
                foreach (var item in Inventory)
                {
                    Console.WriteLine($"\t{item.Key}: {item.Value}");
                }
            }
        }
    }
}
