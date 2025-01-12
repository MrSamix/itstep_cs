using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Trombone : MusicalInstrument
    {
        public Trombone(string name, string characteristics) 
            : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Trombone sound: Blare");
        }

        public override void History()
        {
            Console.WriteLine("The trombone was developed in the 15th century in Europe.");
        }
    }
}
