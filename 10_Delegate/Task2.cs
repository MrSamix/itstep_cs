using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _10_Delegate
{
    static class Task2
    {
        public static Func<string> Time = () => DateTime.Now.ToShortTimeString();
        public static Func<string> Date = () => DateTime.Now.ToShortDateString();
        public static Func<string> Weekday = () => DateTime.Now.DayOfWeek.ToString();

        public static Func<int,int,int,int, double> CountAreaOfTriangle = (p1, p2, p3, perimetr) =>
        {
            double p = perimetr / 2;
            double s = Math.Sqrt(p * (p - p1) * (p - p2) * (p - p3));
            return s;
        };

        public static Func<int,int, int> CountAreaOfRectangle = (a, b) => a * b;
        public static void ShowTime()
        {
            Console.WriteLine($"Time: {Time()}");
        }

        public static void ShowDate()
        {
            Console.WriteLine($"Date: {Date()}");
        }

        public static void ShowWeekday()
        {
            Console.WriteLine($"Weekday: {Weekday()}");
        }

        public static void ShowAreaOfTriangle(int p1, int p2, int p3, int perimetr)
        {
            Console.WriteLine($"Area triangle: {CountAreaOfTriangle(p1, p2, p3, perimetr)}");
        }

        public static void ShowAreaOfRectangle(int a, int b)
        {
            Console.WriteLine($"Area rectangle: {CountAreaOfRectangle(a, b)}");
        }
    }
}