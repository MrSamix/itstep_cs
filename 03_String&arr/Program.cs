using System.Collections.Specialized;
using System.Text;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    // Task 1
    static void Task1()
    {
        int[] A = new int[5];
        float[,] B = new float[3, 4];

        Random rnd = new Random();

        for (int i = 0; i < A.Length; i++)
        {
            Console.Write("Enter a number: ");
            A[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                float rand = (float)rnd.NextDouble() * 100;
                B[i, j] = rand;
            }
        }

        // print
        foreach (var item in A)
        {
            Console.Write(item + "\t");
        }
        Console.WriteLine("\n");

        float maxB = B[0, 0];
        float minB = B[0, 0];
        float sumB = 0;
        float multB = 1;
        float neparnisumB = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (maxB < B[i, j])
                {
                    maxB = B[i, j];
                }
                if (minB > B[i, j])
                {
                    minB = B[i, j];
                }
                if ((j + 1) % 2 != 0)
                {
                    neparnisumB += B[i, j];
                }
                Console.Write($"{B[i, j],-15}");
                sumB += B[i, j];
                multB *= B[i, j];
            }
            Console.WriteLine();
        }

        int maxA = A.Max();
        int minA = A.Min();
        int sumA = A.Sum();
        int multA = 1;
        int parnisumA = 0;
        for (int i = 0; i < A.Length; i++)
        {
            multA *= A[i];
            if ((i + 1) % 2 == 0)
            {
                parnisumA += A[i];
            }
        }

        float max = maxA > maxB ? maxA : maxB;
        Console.WriteLine("Max: " + max);

        float min = minA > minB ? minB : minA;
        Console.WriteLine("Min: " + min);

        float sum = sumA + sumB;
        Console.WriteLine("Sum: " + sum);

        float mult = multA * multB;
        Console.WriteLine("Mult: " + mult);

        Console.WriteLine("Sum even A: " + parnisumA);
        Console.WriteLine("Sum odd cols B: " + neparnisumB);
    }

    // Task 2
    static void Task2()
    {
        int[,] array = new int[5, 5];
        Random rand = new Random();

        // fill
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array[i, j] = rand.Next(-100, 101);
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }

        // find min and max
        int min = int.MaxValue, max = int.MinValue;
        int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (array[i, j] < min)
                {
                    min = array[i, j];
                    minRow = i;
                    minCol = j;
                }
                if (array[i, j] > max)
                {
                    max = array[i, j];
                    maxRow = i;
                    maxCol = j;
                }
            }
        }

        int sum = 0;
        bool startSumming = false;
        // sum between min and max
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if ((i == minRow && j == minCol) || (i == maxRow && j == maxCol))
                {
                    if (startSumming)
                    {
                        sum += array[i, j];
                        startSumming = false;
                    }
                    else
                    {
                        startSumming = true;
                    }
                }
                else if (startSumming)
                {
                    sum += array[i, j];
                }
            }
        }
        Console.WriteLine($"Sum of elements between min ({min}) and max ({max}) is: {sum}");
    }

    // Task 3
    static void Task3()
    {
        Console.WriteLine("Enter a string:");
        string line = Console.ReadLine()!;
        StringBuilder newline = new StringBuilder(line);
        Console.WriteLine("Menu:\n[1] Encrypt\n[2] Descrypt");
        char choice = (char)Console.Read();
        switch (choice)
        {
            case '1':
                {
                    // Encrypt
                    Console.WriteLine("Encrypting...");
                    for (int i = 0; i < newline.Length; i++)
                    {
                        char letter = newline[i];
                        if (char.IsLetter(letter))
                        {
                            // Apply Caesar cipher
                            if (!char.IsUpper(letter))
                            {
                                char encryptedLetter = (char)(letter + 3);
                                if (encryptedLetter > 'z')
                                {
                                    encryptedLetter = (char)(encryptedLetter - 26);
                                }
                                newline[i] = encryptedLetter;
                            }
                            else
                            {
                                char encryptedLetter = (char)(letter + 3);
                                if (encryptedLetter > 'Z')
                                {
                                    encryptedLetter = (char)(encryptedLetter - 26);
                                }
                                newline[i] = encryptedLetter;
                            }
                        }
                    }
                    Console.WriteLine("Encrypted string: " + newline.ToString());
                    break;
                }
            case '2':
            {
                    // Descrypt
                    Console.WriteLine("Decrypting...");
                    for (int i = 0; i < newline.Length; i++)
                    {
                        char letter = newline[i];
                        if (char.IsLetter(letter))
                        {
                            if (char.IsUpper(letter))
                            {
                                char decryptedLetter = (char)(letter - 3);
                                if (decryptedLetter < 'A')
                                {
                                    decryptedLetter = (char)(decryptedLetter + 26);
                                }
                                newline[i] = decryptedLetter;
                            }
                            else
                            {
                                char decryptedLetter = (char)(letter - 3);
                                if (decryptedLetter < 'a')
                                {
                                    decryptedLetter = (char)(decryptedLetter + 26);
                                }
                                newline[i] = decryptedLetter;
                            }
                        }
                    }
                    Console.WriteLine("Dencrypted string: " + newline.ToString());
                    break;
                }
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    // Task 4
    static int[,] MultiplyByScalar(int[,] matrix, int scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }


    static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];
        if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
        {
            Console.WriteLine("This matrix with different sizes! Returned first matrix!");
            return matrix1;
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (rows1 != rows2 || cols1 != cols2)
        {
            Console.WriteLine("This matrix with different sizes! Returned first matrix!");
            return matrix1;
        }

        int[,] result = new int[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    private static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        int[,] matrix1 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        Console.WriteLine("Matrix 1:");
        PrintMatrix(matrix1);
        int[,] matrix2 = {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
        };
        Console.WriteLine("Matrix 2:");
        PrintMatrix(matrix2);

        int scalar = 2;

        int[,] multipliedByScalar = MultiplyByScalar(matrix1, scalar);
        Console.WriteLine("Matrix 1 multiplied by scalar:");
        PrintMatrix(multipliedByScalar);

        int[,] addedMatrices = AddMatrices(matrix1, matrix2);
        Console.WriteLine("Sum of matrices:");
        PrintMatrix(addedMatrices);

        int[,] multipliedMatrices = MultiplyMatrices(matrix1, matrix2);
        Console.WriteLine("Product of matrices:");
        PrintMatrix(multipliedMatrices);
    }
}