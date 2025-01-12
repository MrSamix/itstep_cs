using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Violin : MusicalInstrument
    {
        public Violin(string name, string characteristics) 
            : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Violin sound: Screech");
        }

        public override void History()
        {
            Console.WriteLine("The violin was first developed in the 16th century in Italy.");
        }
    }
}
