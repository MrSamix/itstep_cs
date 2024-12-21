using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Class
{
    internal class Website
    {
        private string name = "NoName";
        private string path = "NoPath";
        private string description = "NoDescription";
        private string ipAddress = "NoIPAddress";
        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
            }
        }
        public string Path { get => path; 
            set 
            { 
                if (!string.IsNullOrWhiteSpace(value))
                {
                    path = value;
                }
            } 
        }
        public string Description
        {
            get => description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }
        public string IpAddress
        {
            get => ipAddress;
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ipAddress = value;
                }
            }
        }
        public Website(string name, string path, string description, string ipAddress)
        {
            Name = name;
            Path = path;
            Description = description;
            IpAddress = ipAddress;
        }
        public Website()
        {}

        public void InputData()
        {
            Console.WriteLine("Enter website name:");
            Name = Console.ReadLine()!;

            Console.WriteLine("Enter website path:");
            Path = Console.ReadLine()!;

            Console.WriteLine("Enter website description:");
            Description = Console.ReadLine()!;

            Console.WriteLine("Enter website IP address:");
            IpAddress = Console.ReadLine()!;
        }

        public void Print()
        {
            Console.WriteLine("Website Name: " + Name);
            Console.WriteLine("Website Path: " + Path);
            Console.WriteLine("Website Description: " + Description);
            Console.WriteLine("Website IP Address: " + IpAddress);
        }
        public override string ToString()
        {
            return $"Website Name: {Name} \nWebsite Path: {Path} \nWebsite Description: {Description} \nWebsite IP Address: {ipAddress}";
        }
    }
}
