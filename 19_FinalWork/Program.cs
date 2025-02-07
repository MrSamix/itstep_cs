using _19_FinalWork;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        LanguageDictionary dictionary = new LanguageDictionary("English", "Ukrainian", true);
        dictionary.Menu();

    }
}