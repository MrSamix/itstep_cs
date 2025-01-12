using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07_Inheritance
{
    internal class Microwave : Device
    {
        public Microwave(string name, string characteristics)
            : base(name, characteristics)
        { }
        public override void Sound()
        {
            Console.WriteLine("Microwave sound: Beep");
        }
    }
}
