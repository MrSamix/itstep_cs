using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritance
{
    internal class Money
    {
        private int uah;
        private int kopiyki;
        public int UAH { get => uah; set => uah = value >= 0 ? value : 0; }
        public int Kopiyki { 
            get => kopiyki; 
            set
            {
                if (value >= 0)
                {
                    kopiyki = value;
                    if (kopiyki >= 100)
                    {
                        uah++;
                        kopiyki -= 100;
                    }
                }
                else
                {
                    kopiyki = 0;
                }
            }
        }

        public Money(int uah, int kopiyki)
        {
            UAH = uah;
            Kopiyki = kopiyki;
        }

        public override string ToString()
        {
            return $"{UAH} grn. {Kopiyki} kop.";
        }
    }
}
