using _12_List_Generics_;

internal class Program
{
    private static void Main(string[] args)
    {
        Book book = new Book("Harry Potter", "J.K. Rowling", "Fantasy", 1997);
        Book book1 = new Book("The Lord of the Rings", "J.R.R. Tolkien", "Fantasy", 1954);
        Book book2 = new Book("The Da Vinci Code", "Dan Brown", "Mystery", 2003);
        Book book3 = new Book("The Catcher in the Rye", "J.D. Salinger", "Fiction", 1951);

        DatabaseBook dbBook = new DatabaseBook();
        dbBook.AddBook(book);
        dbBook.AddBookToStart(book1);
        dbBook.AddBookToIndex(book2, 1);
        dbBook.AddBookToEnd(book3);

        dbBook.ShowBooks();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 30) + " Find Harry Potter book " + new string('-', 30));
        Console.ResetColor();

        dbBook.FindBook("Harry Potter");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 30) + " Remove Harry Potter book " + new string('-', 30));
        Console.ResetColor();
        dbBook.RemoveBook(book);

        dbBook.ShowBooks();

        dbBook.EditBook(book1);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 30) + " After edit book " + new string('-', 30));
        Console.ResetColor();

        dbBook.ShowBooks();

        dbBook.RemoveBookFromEnd();

        dbBook.RemoveBookFromStart();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 30) + " After removed first and last book " + new string('-', 30));
        Console.ResetColor();

        dbBook.ShowBooks();
    }
}