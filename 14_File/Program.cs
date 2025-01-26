using _14_File;

internal class Program
{
    private static void Main(string[] args)
    {
        Moderator moderator = new Moderator("../../../text.txt", "../../../banwords.txt");
        moderator.CheckText();
    }
}