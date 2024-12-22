using _05_Overload_operators;

internal class Program
{
    private static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(3, 4);
        Vector v3 = v1 + v2;
        Vector v4 = v1 - v2;
        Vector v5 = v1 * 2;
        double v6 = v1 * v2;
        double v7 = (double)v1;
        Vector v8 = v7;
        Console.WriteLine($"v1 = {v1}");
        Console.WriteLine($"v2 = {v2}");
        Console.WriteLine($"v1 + v2 = {v3}");
        Console.WriteLine($"v1 - v2 = {v4}");
        Console.WriteLine($"v1 * 2 = {v5}");
        Console.WriteLine($"v1 * v2 = {v6}");
        Console.WriteLine($"v1 to double(explicit) = {v7}");
        Console.WriteLine($"v7(double) to Vector(implicit) = {v8}");
        Console.WriteLine();
        Console.WriteLine($"v1 == v2? {v1 == v2}");
        Console.WriteLine($"v1 != v2? {v1 != v2}");
        Console.WriteLine($"v1 != v3? {v1 != v3}");
        Console.WriteLine($"v1 == v3? {v1 == v3}");
        Console.WriteLine($"v1 != v4? {v1 != v4}");
        Console.WriteLine($"v1 == v4? {v1 == v4}");
        Console.WriteLine($"v1 != v5? {v1 != v5}");
        Console.WriteLine($"v1 == v5? {v1 == v5}");

        Console.WriteLine();

        Console.WriteLine($"v3 = {v3}");
        Console.WriteLine($"v3 += v1 = {v3 += v1}");
        Console.WriteLine($"v3 -= v1 = {v3 -= v1}");
        Console.WriteLine($"v3 *= 2 = {v3 *= 2}");
    }
}