using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Manager : Worker
    {
        public Manager(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"Manager: {Name}");
        }
    }
}
