using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Events
{
    public class SportsCar : Car
    {
        public SportsCar(string name) : base(name) { }

        public override void StartRace()
        {
            Console.WriteLine($"{Name} (SportsCar) starts the race!");
        }
    }

    public class SedanCar : Car
    {
        public SedanCar(string name) : base(name) { }

        public override void StartRace()
        {
            Console.WriteLine($"{Name} (SedanCar) starts the race!");
        }
    }

    public class Truck : Car
    {
        public Truck(string name) : base(name) { }

        public override void StartRace()
        {
            Console.WriteLine($"{Name} (Truck) starts the race!");
        }
    }

    public class Bus : Car
    {
        public Bus(string name) : base(name) { }

        public override void StartRace()
        {
            Console.WriteLine($"{Name} (Bus) starts the race!");
        }
    }
}
