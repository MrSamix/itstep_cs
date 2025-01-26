using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Generics
{
    internal class Karta
    {
        public string Mast { get; set; }
        public string Typ { get; set; }
        public int Value { get; set; }

        public Karta(string mast, string typ, int value)
        {
            Mast = mast;
            Typ = typ;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Typ} {Mast}";
        }
    }
}
