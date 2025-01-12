using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class President : Worker
    {
        public President(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"President: {Name}");
        }
    }
}
