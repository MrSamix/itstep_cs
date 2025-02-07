using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _20_Exam
{
    public class Enemy : GameObject
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Enemy(string name, int health, int attack, int defense, Position pos)
            : base(name, pos)
        {
            Health = health;
            Attack = attack;
            Defense = defense;
        }
        public bool Battle(Hero hero)
        {
            Console.WriteLine($"\nВи зустріли ворога: {Name} (Здоров’я: {Health}, Атака: {Attack}, Захист: {Defense})");
            Random rnd = new Random();
            while (Health > 0 && hero.Health > 0)
            {
                // Hero attack enemy
                int heroDamage = Math.Max(hero.Strength - Defense + rnd.Next(-2, 3), 1);
                Console.WriteLine($"Ви атакуєте {Name} і завдаєте {heroDamage} ушкоджень.");
                Health -= heroDamage;
                if (Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Ви перемогли {Name}!");
                    Console.ResetColor();
                    hero.AddResource("Gold", 10);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("З тіла ворога ви знайшли 10 Gold.");
                    Console.ResetColor();
                    return true;
                }

                // Enemy attack hero
                int enemyDamage = Math.Max(Attack - hero.Defense + rnd.Next(-2, 3), 1);
                Console.WriteLine($"{Name} атакує вас і завдає {enemyDamage} ушкоджень.");
                hero.Health -= enemyDamage;
                if (hero.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ви загинули в бою!");
                    Console.ResetColor();
                    return false;
                }
            }
            return false;
        }
    }
}
