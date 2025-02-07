using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Exam
{
    public class Resource : GameObject
    {
        public string ResourceType { get; set; }
        public int ExtractionSteps { get; set; }
        public int Quantity { get; set; }

        public Resource(string resourceType, int extractionSteps, int quantity, Position pos)
            : base(resourceType, pos)
        {
            ResourceType = resourceType;
            ExtractionSteps = extractionSteps;
            Quantity = quantity;
        }

        public void Extract(Hero hero)
        {
            Console.WriteLine($"\nПочинається видобуток ресурсу {ResourceType}. Потрібно виконати {ExtractionSteps} крок(ів).");
            for (int i = 1; i <= ExtractionSteps; i++)
            {
                Console.WriteLine($"Крок {i}/{ExtractionSteps}. Натисніть Enter для продовження...");
                Console.ReadLine();
            }
            hero.AddResource(ResourceType, Quantity);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Видобуток завершено! Ви отримали {Quantity} одиниць {ResourceType}.");
            Console.ResetColor();
        }
    }
}
