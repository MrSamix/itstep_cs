using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Security : Worker
    {
        public Security(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"Security: {Name}");
        }
    }
}
