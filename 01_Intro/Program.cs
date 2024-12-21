internal class Program
{
    // Task 1
    static void CountEarn(string position, int hoursWorked)
    {
        double hourlyRate;

        switch (position)
        {
            case "Manager":
                hourlyRate = 25.0;
                break;
            case "Developer":
                hourlyRate = 20.0;
                break;
            case "Designer":
                hourlyRate = 18.0;
                break;
            default:
                hourlyRate = 15.0;
                break;
        }

        double earnings = hourlyRate * hoursWorked;
        Console.WriteLine($"The employee's earnings are: {earnings}");
    }
    // Task 2
    static void CustomPrint()
    {
        Console.WriteLine("Enter number a: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number b: ");
        int b = int.Parse(Console.ReadLine());
        if (a < b)
        {
            for (int i = a; i <= b; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"{i, -5}");
                }
                Console.WriteLine();
            }
        }
    }

    // Task 3
    static void inputChar()
    {
        int countSpace = 0;
        int countNumbers = 0;
        int countLetters = 0;
        int countSymbols = 0;
        char input;
        while (true)
        {
            Console.WriteLine("Enter a char");
            input = (char)Console.Read();
            Console.ReadLine(); // fix the bug
            if (input == '.')
            {
                break;
            }
            else if (input == ' ')
            {
                countSpace++;
            }
            else if (char.IsDigit(input))
            {
                countNumbers++;
            }
            else if (char.IsLetter(input))
            {
                countLetters++;
            }
            else if (char.IsSymbol(input))
            {
                countSymbols++;
            }
        }
        Console.WriteLine($"Spaces: {countSpace}");
        Console.WriteLine($"Numbers: {countNumbers}");
        Console.WriteLine($"Letters: {countLetters}");
        Console.WriteLine($"Characters: {countSymbols}");
    }

    // Task 4
    static void inputChar_2()
    {
        while (true)
        {
            Console.WriteLine("Enter a char");
            char input = (char)Console.Read();
            char changed;
            Console.ReadLine(); // fix the bug
            if (!char.IsLetter(input))
            {
                break;
            }
            else if (char.IsLower(input))
            {
                changed = char.ToUpper(input);
            }
            else
            {
                changed = char.ToLower(input);
            }
            Console.WriteLine($"Original: {input} \t Changed: {changed}");
        }
    }

    private static void Main(string[] args)
    {
        // Task 1
        string position = "Developer";
        int hoursWorked = 40;

        CountEarn(position, hoursWorked);

        // Task 2
        CustomPrint();
        // Task 3
        inputChar();
        // Task 4
        inputChar_2();
    }
}
