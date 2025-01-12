using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Device
    {
        public string Name { get; set; }
        public string Characteristics { get; set; }

        public Device(string name, string characteristics)
        {
            Name = name;
            Characteristics = characteristics;
        }

        public virtual void Sound()
        {
            Console.WriteLine("Device sound");
        }

        public void Show()
        {
            Console.WriteLine($"Device Name: {Name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Device Description: {Characteristics}");
        }
    }
}
