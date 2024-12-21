using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Class
{
    internal class Journal
    {
        private string name = "NoName";
        private int yearCreation = 0;
        private string description = "NoDescription";
        private string phoneNumber = "NoPhoneNumber";
        private string email = "NoEmail";
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
        public int YearCreation
        {
            get => yearCreation;
            set
            {
                if (value > 0)
                {
                    yearCreation = value;
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
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    phoneNumber = value;
                }
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    email = value;
                }
            }
        }
        public Journal(string name, int yearCreation, string description, string phoneNumber, string email)
        {
            Name = name;
            YearCreation = yearCreation;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public Journal()
        { }
        public void InputData()
        {
            Console.WriteLine("Enter journal name:");
            Name = Console.ReadLine()!;

            Console.WriteLine("Enter year of creation:");
            YearCreation = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter journal description:");
            Description = Console.ReadLine()!;

            Console.WriteLine("Enter phone number:");
            PhoneNumber = Console.ReadLine()!;

            Console.WriteLine("Enter email:");
            Email = Console.ReadLine()!;
        }
        public void Print()
        {
            Console.WriteLine("Journal name:" + Name);
            Console.WriteLine("Year of creation:" + YearCreation);
            Console.WriteLine("Description:" + Description);
            Console.WriteLine("Phone number:" + PhoneNumber);
            Console.WriteLine("Email:" + Email);
        }
        public override string ToString()
        {
            return $"Journal name: {Name}\nYear of creation: {YearCreation}\nDescription: {Description}\nPhone number: {PhoneNumber}\nEmail: {Email}";
        }
    }
}
