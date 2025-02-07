using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Exam
{
    public abstract class GameObject
    {
        public Position Position { get; set; }
        public string Name { get; set; }

        public GameObject(string name, Position pos)
        {
            Name = name;
            Position = pos;
        }
    }
}
