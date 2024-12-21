using _04_Class;

internal class Program
{
    private static void Main(string[] args)
    {
        // Task 1
        Website website = new Website("Google", "https://google.com", "Web search", "216.58.212.238");
        Console.WriteLine(website);
        Console.WriteLine();

        Website website1 = new Website();
        website1.InputData();
        Console.WriteLine(website1);

        Console.WriteLine("\n");

        // Task 2
        Journal journal = new Journal("Journal", 2021, "Journal description", "123456789", "journal@journal.ua");
        Console.WriteLine(journal);
        Console.WriteLine();

        Journal journal1 = new Journal();
        journal1.InputData();
        Console.WriteLine(journal1);
    }
}