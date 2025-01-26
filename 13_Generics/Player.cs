using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Generics
{
    //internal class Player
    //{
    //    public string Name { get; set; }
    //    public Queue<Karta> Cards { get; set; }

    //    public Player(string name)
    //    {
    //        Name = name;
    //        Cards = new Queue<Karta>();
    //    }

    //    public void PrintCards()
    //    {
    //        Console.WriteLine($"{Name}'s cards: {string.Join(", ", Cards)}");
    //    }
    //}

    internal class Player
    {
        public string Name { get; set; }
        public List<Karta> Cards { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new List<Karta>();
        }

        public void PrintCards()
        {
            Console.WriteLine($"{Name}'s cards: {string.Join(", ", Cards)}");
        }
    }
}
