using _07_Inheritance;

internal class Program
{
    private static void Main(string[] args)
    {
        // Task 1
        Product p1 = new Product("Bread", 5, 50);
        try
        {
            p1.MinusPrice(5, 60);
            Console.WriteLine(p1);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Task 2
        Console.WriteLine("Task 2");
        Device[] devices = new Device[]
        {
            new Kettle("Kettle", "Boils water"),
            new Car("Car", "Drives"),
            new Steamboat("Steamboat", "Floats")
        };

        foreach (Device device in devices)
        {
            device.Show();
            device.Desc();
            device.Sound();
            Console.WriteLine();
        }

        // Task 3
        Console.WriteLine("Task 3");
        MusicalInstrument[] musicalInstruments = new MusicalInstrument[]
        {
            new Violin("Violin", "String instrument with a high pitch"),
            new Trombone("Trombone", "Brass instrument with a slide"),
            new Ukulele("Ukulele", "Small string instrument from Hawaii"),
            new Cello("Cello", "Large string instrument with a deep sound"),
        };

        foreach (MusicalInstrument musicalInstrument in musicalInstruments)
        {
            musicalInstrument.Show();
            musicalInstrument.Desc();
            musicalInstrument.Sound();
            musicalInstrument.History();
            Console.WriteLine();
        }



        // Task 4
        Console.WriteLine("Task 4");
        Worker[] workers = new Worker[]
        {
            new President("John Doe"),
            new Security("Jane Smith"),
            new Manager("Alice Johnson"),
            new Engineer("Bob Brown")
        };

        foreach (Worker worker in workers)
        {
            worker.Print();
            Console.WriteLine();
        }
    }
}