using _06_Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
		try
		{
			CreditCard card = new CreditCard("Visa", "4444111188889999", new DateTime(2022,05,30), 555, "Oleksandr Panchuk"); // exception
			Console.WriteLine(card);
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR:");
			Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("Source: " + ex.Source);
            Console.ResetColor();
        }
        Console.WriteLine();
        try
        {
            CreditCard card = new CreditCard("Visa", "4444111188889999", new DateTime(2025, 05, 30), 6666, "Oleksandr Panchuk"); // exception
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR:");
            Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("Source: " + ex.Source);
            Console.ResetColor();
        }
        Console.WriteLine();
        try
        {
            CreditCard card = new CreditCard("Visa", "4444111188889999", new DateTime(2025, 05, 30), 555, "Oleksandr Panchuk"); // normal
            Console.WriteLine(card);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR:");
            Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("Source: " + ex.Source);
            Console.ResetColor();
        }
    }
}