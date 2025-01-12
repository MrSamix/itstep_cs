using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Steamboat : Device
    {
        public Steamboat(string name, string characteristics) : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Steamboat sound: Horn");
        }
    }
}
