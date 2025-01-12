using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class MusicalInstrument
    {
        public string Name { get; set; }
        public string Characteristics { get; set; }

        public MusicalInstrument(string name, string characteristics)
        {
            Name = name;
            Characteristics = characteristics;
        }

        public virtual void Sound()
        {
            Console.WriteLine("Musical instrument sound");
        }

        public void Show()
        {
            Console.WriteLine($"Instrument Name: {Name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Instrument Description: {Characteristics}");
        }

        public virtual void History()
        {
            Console.WriteLine("History of the musical instrument");
        }
    }
}
