using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Interfaces
{
    internal class Array : ICalc, IOutput2, ICalc2
    {
        private int[] ints;
        public Array(params int[] numbers)
        {
            ints = numbers;
        }

        

        public void Show()
        {
            
            //foreach (var i in ints)
            //{
            //    Console.WriteLine(i);
            //}
            Console.WriteLine(String.Join(", ", ints)); // для зручності, щоб виводило в рядок
        }

        public void Show(string info)
        {
            if (!String.IsNullOrWhiteSpace(info))
            {
                Console.WriteLine(info);
            }
            Show();
        }

        public int Less(int valueToCompare)
        {
            return ints.Count(i => i < valueToCompare);
        }
        public int Greater(int valueToCompare)
        {
            return ints.Count(i => i > valueToCompare);
        }

        public void ShowEven()
        {
            int[] even_ints = new int[0];
            foreach (var i in ints)
            {
                if (i % 2 == 0)
                {
                    System.Array.Resize(ref even_ints, even_ints.Length + 1);
                    even_ints[even_ints.Length - 1] = i;
                }
            }
            Console.WriteLine(String.Join(", ", even_ints));
        }

        public void ShowOdd()
        {
            int[] odd_ints = new int[0];
            foreach (var i in ints)
            {
                if (i % 2 != 0)
                {
                    System.Array.Resize(ref odd_ints, odd_ints.Length + 1);
                    odd_ints[odd_ints.Length - 1] = i;
                }
            }
            Console.WriteLine(String.Join(", ", odd_ints));
        }

        public int CountDistinct()
        {
            return ints.Distinct().Count();
        }

        public int EqualToValue(int valueToCompare)
        {
            return ints.Count(i => i == valueToCompare);
        }
    }
}
