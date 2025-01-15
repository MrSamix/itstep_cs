using _09_Structure;

internal class Program
{
    private static void Main(string[] args)
    {
        Vector3D v1 = new Vector3D(1, 2, 3);
        Vector3D v2 = new Vector3D(4, 5, 6);

        Console.WriteLine("v1: " + v1);
        Console.WriteLine("v2: " + v2);
        

        Vector3D v3 = v1 + v2;
        Console.WriteLine("v1 + v2: " + v3);
        
        Vector3D v4 = v2 - v1;
        Console.WriteLine("v2 - v1: " + v4);
        
        Vector3D mult = v2.Mult(2);
        Console.WriteLine("v2 * 2: " + mult);
    }
}