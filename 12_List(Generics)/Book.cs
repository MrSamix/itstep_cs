using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_List_Generics_
{
    internal class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }


        public Book(string name, string author, string genre, int year)
        {
            Name = name;
            Author = author;
            Genre = genre;
            Year = year;
        }


        public override string ToString()
        {
            return $"Name: {Name}\n Author: {Author}\n Genre: {Genre}\n Year: {Year}";
        }
    }
}
