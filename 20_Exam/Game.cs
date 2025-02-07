using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Exam
{
    public class Game
    {
        private int MapWidth = 5;
        private int MapHeight = 5;
        private Hero hero;
        private List<GameObject> gameObjects;
        private Shop shop;

        public Game()
        {
            hero = new Hero("Hero", new Position(0, 0));
            shop = new Shop();
            gameObjects = new List<GameObject>();
            var rnd = new Random();

            gameObjects.Add(new Resource("Wood", extractionSteps: 1, quantity: 1, pos: new Position(rnd.Next(MapWidth), rnd.Next(MapHeight))));
            gameObjects.Add(new Resource("Gold", extractionSteps: 2, quantity: 5, pos: new Position(rnd.Next(MapWidth), rnd.Next(MapHeight))));
            gameObjects.Add(new Enemy("Goblin", health: 30, attack: 8, defense: 3, pos: new Position(rnd.Next(MapWidth), rnd.Next(MapHeight))));
            gameObjects.Add(new Enemy("Dragon", health: 50, attack: 12, defense: 5, pos: new Position(rnd.Next(MapWidth), rnd.Next(MapHeight))));
        }

        public void Run()
        {
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"Ваша поточна позиція: {hero.Position}");
                Console.WriteLine($"Здоров’я: {hero.Health} | Сила: {hero.Strength} | Захист: {hero.Defense}");
                Console.WriteLine("Доступні дії:");
                Console.WriteLine("W - Рух вгору");
                Console.WriteLine("S - Рух вниз");
                Console.WriteLine("A - Рух вліво");
                Console.WriteLine("D - Рух вправо");
                Console.WriteLine("I - Показати інвентар");
                Console.WriteLine("P - Відвідати магазин");
                Console.WriteLine("Q - Вийти з гри");
                Console.Write("Введіть дію: ");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.A:
                    case ConsoleKey.S:
                    case ConsoleKey.D:
                        MoveHero(key);
                        CheckCurrentPosition();
                        break;
                    case ConsoleKey.I:
                        hero.ShowInventory();
                        break;
                    case ConsoleKey.P:
                        shop.Visit(hero);
                        break;
                    case ConsoleKey.Q:
                        gameRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nНевідома команда.");
                        break;
                }

                if (hero.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nГра закінчена. Ви загинули.");
                    Console.ResetColor();
                    gameRunning = false;
                }
                if (gameObjects.FindAll(x=>x is Enemy).Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nГра закічнена. Ви виграли! Ви вбили всіх босів!");
                    Console.ResetColor();
                    gameRunning = false;
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nДякуємо за гру!");
            Console.ResetColor();
        }

        private void MoveHero(ConsoleKey direction)
        {
            int newX = hero.Position.X;
            int newY = hero.Position.Y;
            switch (direction)
            {
                case ConsoleKey.W: newY += 1; break;
                case ConsoleKey.S: newY -= 1; break;
                case ConsoleKey.A: newX -= 1; break;
                case ConsoleKey.D: newX += 1; break;
            }
            if (newX < 0 || newX >= MapWidth || newY < 0 || newY >= MapHeight)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВи не можете вийти за межі карти.");
                Console.ResetColor();
            }
            else
            {
                hero.Position = new Position(newX, newY);
            }
        }

        private void CheckCurrentPosition()
        {
            GameObject obj = gameObjects.Find(o => o.Position.X == hero.Position.X && o.Position.Y == hero.Position.Y);
            if (obj != null)
            {
                if (obj is Resource resource)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nВи знайшли ресурс: {resource.ResourceType}.");
                    Console.ResetColor();
                    Console.Write("Бажаєте видобути ресурс? (Y/N): ");
                    ConsoleKey choice = Console.ReadKey().Key;
                    if (choice == ConsoleKey.Y)
                    {
                        resource.Extract(hero);
                        gameObjects.Remove(obj);
                    }
                }
                else if (obj is Enemy enemy)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nВи зустріли ворога: {enemy.Name}.");
                    Console.ResetColor();
                    Console.Write("Бажаєте вступити в бій? (Y/N): ");
                    ConsoleKey choice = Console.ReadKey().Key;
                    if (choice == ConsoleKey.Y)
                    {
                        bool won = enemy.Battle(hero);
                        if (won)
                        {
                            gameObjects.Remove(obj);
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nТут нічого немає.");
                Console.ResetColor();
            }
        }
    }
}
