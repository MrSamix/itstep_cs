using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Exam
{
    public class Shop
    {
        public List<ShopItem> Items { get; set; }

        public Shop()
        {
            Items = new List<ShopItem>()
            {
                new ShopItem("Knife", "Збільшує силу на 2", "Gold", 20, (hero) => { hero.Strength += 2; }),
                new ShopItem("Shield", "Збільшує захист на 3", "Gold", 30, (hero) => { hero.Defense += 3; })
            };
        }

        public void Visit(Hero hero)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nЛаскаво просимо до магазину!");
            Console.ResetColor();
            Console.WriteLine("Ваші ресурси:");
            hero.ShowInventory();
            Console.WriteLine("Доступні предмети:");
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                Console.WriteLine($"{i + 1}. {item.Name} – {item.Description} – Вартість: {item.Cost} {item.CostResource}");
            }
            Console.Write("Введіть номер предмета для покупки або 0 для виходу: ");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice) && choice > 0 && choice <= Items.Count)
            {
                ShopItem selectedItem = Items[choice - 1];
                if (hero.Inventory.ContainsKey(selectedItem.CostResource) && hero.Inventory[selectedItem.CostResource] >= selectedItem.Cost)
                {
                    hero.Inventory[selectedItem.CostResource] -= selectedItem.Cost;
                    selectedItem.ApplyEffect(hero);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Ви придбали {selectedItem.Name}!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Недостатньо ресурсів для покупки!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вихід з магазину.");
            }
        }
    }
}
