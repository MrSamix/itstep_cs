using _08_Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        _08_Interfaces.Array arr = new _08_Interfaces.Array(2, 5, 4, 7, 8, 9, 6, 3, 3);

        arr.Show();

        Console.WriteLine($"Counts of number less 4 = {arr.Less(4)}");
        Console.WriteLine($"Counts of number greater 5 = {arr.Greater(5)}");

        Console.WriteLine("Even numbers: ");
        arr.ShowEven();
        Console.WriteLine("Odd numbers: ");
        arr.ShowOdd();
        Console.WriteLine($"Count unique numbers in arr = {arr.CountDistinct()}");
        Console.WriteLine($"Count of numbers equal to 3 = {arr.EqualToValue(3)}");
    }
}