using _16_FileSystem;

internal class Program
{
    private static void Main(string[] args)
    {
        FileManager fileManager = new FileManager("../../..");
        fileManager.Menu();
    }
}