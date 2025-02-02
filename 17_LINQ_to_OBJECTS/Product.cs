using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_LINQ_to_OBJECTS
{
    public class Product
    {
        public enum CategoryProduct
        {
            Category1, Category2, Category3
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public float Price { get; set; }
        public CategoryProduct Category { get; set; }
        public int Year { get; set; }
        public override string ToString()
        {
            return $"Product name :: {Name,-10} Country :: {Country,-10} Price :: {Price,-10} Category :: {Category.ToString(),-15} Year :: {Year}";
        }
    }
}
