using _11_Events;

internal class Program
{
    private static void Main(string[] args)
    {
        // Створення автомобілів
        Car[] cars = new Car[]
        {
            new SportsCar("Ferrari"),
            new SedanCar("Opel"),
            new Truck("Volvo"),
            new Bus("MAN")
        };

        // Створення гонки
        Race race = new Race(cars);

        // Підписка на подію про фініш
        race.SubscribeToRaceEvent(winner => Console.WriteLine($"Winner the race: {winner}"));

        // Початок гонки
        race.Start();
    }
}