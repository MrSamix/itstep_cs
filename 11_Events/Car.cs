using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Events
{
    public abstract class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Position { get; set; }

        public event Action<string> OnFinish;

        public Car(string name)
        {
            Name = name;
            Position = 0;
        }

        public virtual void Move()
        {
            // Випадкова зміна швидкості автомобіля
            Speed = new Random().Next(5, 20);
            Position += Speed;

            Console.WriteLine($"{Name} running. Current position: {Position}");

            // Перевірка на фініш
            if (Position >= 100)
            {
                OnFinish?.Invoke(Name);
            }
        }

        public abstract void StartRace();
    }
}
