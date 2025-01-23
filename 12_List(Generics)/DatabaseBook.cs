using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_List_Generics_
{
    internal class DatabaseBook
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public void EditBook(Book book)
        {
            Console.WriteLine("Enter new name: ");
            book.Name = Console.ReadLine()!;
            Console.WriteLine("Enter new author: ");
            book.Author = Console.ReadLine()!;
            Console.WriteLine("Enter new genre: ");
            book.Genre = Console.ReadLine()!;
            Console.WriteLine("Enter new year: ");
            try
            {
                book.Year = int.Parse(Console.ReadLine()!);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect number");
                Console.ResetColor();
            }
        }
        public void ShowBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Database is empty.");
                return;
            }
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }


        public void FindBook(string name)
        {
            bool isFound = false;
            foreach (var book in books)
            {
                if (book.Name == name)
                {
                    Console.WriteLine(book);
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("Book not found!");
            }
        }

        public void FindBook(int year)
        {
            bool isFound = false;
            foreach (var book in books)
            {
                if (book.Year == year)
                {
                    Console.WriteLine(book);
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("Book not found!");
            }
        }


        public void FindBook(string author, string genre)
        {
            bool isFound = false;
            foreach (var book in books)
            {
                if (book.Author == author && book.Genre == genre)
                {
                    Console.WriteLine(book);
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("Book not found!");
            }
        }


        public void AddBookToStart(Book book)
        {
            books.Insert(0, book);
        }

        public void AddBookToIndex(Book book, int index)
        {
            if (index >= books.Count)
            {
                Console.WriteLine("Error index. Size = " + books.Count);
            }
            else
            {
                books.Insert(index, book);
            }
        }

        public void AddBookToEnd(Book book)
        {
            books.Add(book);
        }

        public void RemoveBookFromStart()
        {
            books.RemoveAt(0);
        }

        public void RemoveBookFromIndex(int index)
        {
            if (index >= books.Count)
            {
                Console.WriteLine("Error index. Size = " + books.Count);
            }
            else
            {
                books.RemoveAt(index);
            }
        }

        public void RemoveBookFromEnd()
        {
            books.RemoveAt(books.Count - 1);
        }
    }
}
