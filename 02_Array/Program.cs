internal class Program
{
    static int[] CreateArr(int size)
    {
        return new int[size];
    }
    static void FillRandArr(int[] arr, int left = 0, int right = 100)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = new Random().Next(left, right);
        }
    }
    static void PrintArr(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static int FirstPositive(int[] arr)
    {
        int firstPositive = Array.FindIndex(arr, a => a > 0);
        if (firstPositive == -1)
            return 0;
        return arr[firstPositive];
    }
    static int CountEven(int[] arr)
    {
        return arr.Count(a => a % 2 == 0);
    }
    static int DivBy7(int[] arr)
    {
        return Array.FindIndex(arr, a => a % 7 == 0);
    }
    private static void Main(string[] args)
    {
        int[] arr = CreateArr(10);
        FillRandArr(arr);
        PrintArr(arr);
        // Swap
        for (int i = 0; i < arr.Length; i+=2)
        {
            Swap(ref arr[i], ref arr[i + 1]);
        }
        Console.Write("After swap: ");
        PrintArr(arr);
        Console.WriteLine("First positive: " + FirstPositive(arr));
        Console.WriteLine("Count of even: " + CountEven(arr));
        Console.WriteLine("First divisible by 7: " + DivBy7(arr));
    }
}