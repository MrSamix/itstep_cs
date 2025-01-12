using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal abstract class Worker
    {
        public string Name { get; set; }

        public Worker(string name)
        {
            Name = name;
        }

        public abstract void Print();
    }
}
