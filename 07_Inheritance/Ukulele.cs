using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Ukulele : MusicalInstrument
    {
        public Ukulele(string name, string characteristics)
            : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Ukulele sound: Strum");
        }

        public override void History()
        {
            Console.WriteLine("The ukulele originated in the 19th century in Hawaii.");
        }
    }
}
