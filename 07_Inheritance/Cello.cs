using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Cello : MusicalInstrument
    {
        public Cello(string name, string characteristics) : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Cello sound: Deep and rich");
        }

        public override void History()
        {
            Console.WriteLine("The cello was developed in the 16th century in Italy.");
        }
    }
}
