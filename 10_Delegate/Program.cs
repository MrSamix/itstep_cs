using _10_Delegate;
internal class Program
{
    private static void Main(string[] args)
    {
        // Task 1

        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine($"Numbers: {String.Join(", ", ints)}");

        int[] evenints = ints.ShowEven();
        Console.WriteLine($"Even numbers: {String.Join(", ", evenints)}");

        int[] oddints = ints.ShowOdd();
        Console.WriteLine($"Odd numbers: {String.Join(", ", oddints)}");

        int[] primeints = ints.ShowPrime();
        Console.WriteLine($"Prime numbers: {String.Join(", ", primeints)}");

        int[] fibonachiints = ints.ShowFibonachi();
        Console.WriteLine($"Fibonachi numbers: {String.Join(", ", fibonachiints)}");


        // Task 2
        Task2.ShowTime();
        Task2.ShowDate();
        Task2.ShowWeekday();
        Task2.ShowAreaOfTriangle(3, 4, 5, 12);
        Task2.ShowAreaOfRectangle(3, 4);

    }
}