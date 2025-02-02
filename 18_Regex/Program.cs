using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        // Task 1
        var rnd = new Random();
        int[] ints = new int[10];
        for (int i = 0; i < 10; i++)
        {
            ints[i] = rnd.Next(0, 100000);
        }
        string array = String.Join(" ", ints);
        Console.WriteLine($"Array: {array}");

        var pattern = @"\b\d{4}\b";
        var regex = new Regex(pattern);
        var result = regex.Matches(array);
        Console.WriteLine($"Result: {String.Join(" ", result)}");

        // Task 2
        Console.WriteLine(new string('-', 50));

        pattern = @"\b[a-zA-Z]{3}\d{3}[a-zA-Z]{3}\d{3}\b";
        regex = new Regex(pattern);
        string input = "asd123zxc456";
        Console.WriteLine($"Input: {input} \nResult: {regex.IsMatch(input)}");
        Console.WriteLine();
        input = "asd123zxc45d";
        Console.WriteLine($"Input: {input} \nResult: {regex.IsMatch(input)}");

        // Task 3
        Console.WriteLine(new string('-', 50));

        var text = "wWw WWW COM NET NeT 45 UKr";
        pattern = @"\b[A-Z]{3}\b";
        var matches = Regex.Matches(text, pattern);
        Console.WriteLine($"Input: {text}");
        Console.WriteLine($"Matches: {String.Join(" ", matches)}");
        
        // Task 4
        Console.WriteLine(new string('-', 50));

        pattern = @"(19[0-9]\d|20[0-9]\d)";
        regex = new Regex(pattern);
        input = "1900 2000 2050 20550 2120 6520 0000";
        matches = regex.Matches(input);
        Console.WriteLine($"Result: {String.Join(", ", matches)}");

        // Task 5
        Console.WriteLine(new string('-', 50));
        
        List<string> phoneDirectory = new List<string>
        {
            "+38-050-1234567",
            "+38-067-8900023",
            "+38-093-0001234",
            "+38-050-4560023",
            "+38-067-1234500"
        };

        
        string pattern1 = @"\+38-0\d{2}-\d{5}23";
        regex = new Regex(pattern1);
        Console.WriteLine("Numbers, which ends on '23':");
        foreach (string phone in phoneDirectory)
        {
            if (regex.IsMatch(phone))
            {
                Console.WriteLine($"Phone: {phone}");
            }
        }
        
        
        string pattern2 = @"\+38-0\d{2}-\d*00\d*";
        regex = new Regex(pattern2);
        Console.WriteLine("\nNumbers, which contains '00':");
        foreach (string phone in phoneDirectory)
        {
            if (regex.IsMatch(phone))
            {
                Console.WriteLine($"Phone: {phone}");
            }
        }
    }
}