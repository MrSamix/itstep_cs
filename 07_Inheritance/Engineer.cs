using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Engineer : Worker
    {
        public Engineer(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"Engineer: {Name}");
        }
    }
}
