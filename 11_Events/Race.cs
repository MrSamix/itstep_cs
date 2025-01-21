using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Events
{
    public class Race
    {
        public delegate void RaceEvent(string winner);

        private Car[] cars;
        private RaceEvent raceEvent;

        public Race(Car[] cars)
        {
            this.cars = cars;
        }

        public void Start()
        {
            foreach (var car in cars)
            {
                car.OnFinish += OnRaceFinish;
            }

            foreach (var car in cars)
            {
                car.StartRace();
            }

            while (true)
            {
                Console.Clear();
                foreach (var car in cars)
                {
                    car.Move();
                }

                if (Array.Exists(cars, car => car.Position >= 100))
                {
                    break;
                }
                Thread.Sleep(500); // Затримка для кращої видимості
            }
        }

        private void OnRaceFinish(string winner)
        {
            Console.WriteLine($"{winner} won the race!");
            raceEvent?.Invoke(winner);
        }

        public void SubscribeToRaceEvent(RaceEvent raceEvent)
        {
            this.raceEvent += raceEvent;
        }
    }
}
