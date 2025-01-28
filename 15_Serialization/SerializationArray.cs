using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _15_Serialization
{
    public class SerializationArray
    {
        private bool IsPrime(int e)
        {
            if (e <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(e); i++)
            {
                if (e % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsFibonachi(int e)
        {
            int a = 0, b = 1, c = 0;
            while (c < e)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c == e;
        }
        public List<int> Ints { get; set; }

        public SerializationArray()
        {
            Ints = new List<int>();
        }

        public void Program()
        {
            while (true)
            {
                Console.WriteLine("Menu: \n[1] Input \n[2] Print \n[3] Filter \n[4] Serialize \n[5] Serialize and save to file \n[6] DeSerialize from file \n[0] Exit");
                char choice = (char)Console.Read()!;
                if (choice == '\r' || choice == '\n') { }
                else
                {
                    switch (choice)
                    {
                        case '1':
                            Input();
                            break;
                        case '2':
                            Print();
                            break;
                        case '3':
                            Filter(); 
                            break;
                        case '4':
                            Console.WriteLine("JSON: " + Serialize());
                            break;
                        case '5':
                            choice = (char)Console.Read();
                            choice = (char)Console.Read(); // заглушки на нажатий enter
                            Console.Write("Enter a path to file: ");
                            string path = Console.ReadLine()!;
                            SerializeToFile(path);
                            break;
                        case '6':
                            choice = (char)Console.Read();
                            choice = (char)Console.Read(); // заглушки на нажатий enter
                            Console.Write("Enter a path to file: ");
                            path = Console.ReadLine()!;
                            DeSerializeFromFile(path);
                            break;
                        case '0':
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Please try again!");
                            break;
                    }
                }
            }
            
        }


        public void Input()
        {
            while (true)
            {
                Console.WriteLine("Enter a numbers(enter -1, if you have a stop)");
                string input = Console.ReadLine()!;
                if (input == null || input == "")
                {

                }
                else {
                    int num = int.Parse(input);
                    if (num == -1)
                    {
                        break;
                    }
                    else
                    {
                        Ints.Add(num);
                    }
                }

                
            }
        }

        public void Print() => Console.WriteLine("List: " + String.Join(", ", Ints));
        

        public void Filter()
        {
            List<int> temp = new List<int>();
            Console.WriteLine("[1] Fibonachi numbers \n[2] Prime numbers");
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    Console.WriteLine("Fibonachi numbers");
                    foreach (int i in Ints)
                    {
                        if (IsFibonachi(i))
                        {
                            temp.Add(i);
                        }
                    }
                    Console.WriteLine($"Result: {String.Join(", ", temp)}");
                    Ints.Clear();
                    Ints = new List<int>(temp);
                    break;
                case '2':
                    Console.WriteLine("Prime numbers");
                    foreach (int i in Ints)
                    {
                        if (IsPrime(i))
                        {
                            temp.Add(i);
                        }
                    }
                    Console.WriteLine($"Result: {String.Join(", ", temp)}");
                    Ints.Clear();
                    Ints = new List<int>(temp);
                    break;
                default:
                    Console.WriteLine("Error input. Please try again!");
                    break;
            }
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize<List<int>>(Ints);
        }

        public void SerializeToFile(string path)
        {
            string json = Serialize();
            try
            {
                File.WriteAllText(path, json);
                Console.WriteLine("Saved to " + path);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error! Message: {e.Message}");
                Console.ResetColor();
            }
        }


        public void DeSerializeFromFile(string path) 
        {
            try
            {
                string json = File.ReadAllText(path);
                var res = JsonSerializer.Deserialize<List<int>>(json);
                if (res == null)
                {
                    throw new Exception("File is empty! Not imported!");
                }
                else { 
                    Ints = new List<int>(res);
                    Console.WriteLine("DONE!");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error! Message: {e.Message}");
                Console.ResetColor();
            }
            
        }

    }
}
