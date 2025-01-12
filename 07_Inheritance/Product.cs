using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Product : Money
    {
        private string name;
        public string Name { get => name; set => name = String.IsNullOrWhiteSpace(value) ? "NOName" : value; }

        public Product(string name, int uah, int kopiyki) 
            : base(uah, kopiyki)
        {
            Name = name;
        }

        public void MinusPrice(int uah, int kopiyki)
        {
            if (uah > this.UAH)
            {
                throw new ArgumentException("Not enough money");
            }
            if (kopiyki > this.Kopiyki)
            {
                if (UAH-1-uah >= 0)
                {
                    UAH--;
                    Kopiyki = (100+this.Kopiyki)-kopiyki;
                }
                else
                {
                    throw new ArgumentException("Not enough money");
                }
            }
            else
            {
                Kopiyki -= kopiyki;
            }

            UAH -= uah;
        }

        public override string ToString()
        {
            return $"{Name} - {base.ToString()}";
        }
    }
}
