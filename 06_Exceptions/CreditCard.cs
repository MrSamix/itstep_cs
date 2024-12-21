using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Exceptions
{
    internal class CreditCard
    {
        private string name = "NoName";
        private string number = "NoNumber";
        private DateTime expirationDate;
        private int cvv;
        private string owner = "NoOwner";

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
            }
        }
        public string Number
        {
            get => number;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Number cannot be null or empty.");
                }
                else if (value.Length != 16)
                {
                    throw new ArgumentException("Number must be 16 digits long.");
                }
                number = value;
            }
        }
        public DateTime ExpirationDate
        {
            get => expirationDate;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Expiration date mustn't be older than now");
                }
                expirationDate = value;
            }
        }
        public int Cvv
        {
            get => cvv;
            set
            {
                if (value < 100 || value > 999)
                {
                    throw new ArgumentException("CVV must be 3 digits long.");
                }
                cvv = value;
            }
        }
        public string Owner
        {
            get => owner;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Owner cannot be null or empty.");
                }
                owner = value;
            }
        }
        public CreditCard(string name, string number, DateTime expirationDate, int cvv, string owner)
        {
            Name = name;
            Number = number;
            ExpirationDate = expirationDate;
            Cvv = cvv;
            Owner = owner;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nNumber: {Number}\nExpiration Date: {ExpirationDate.ToShortDateString()}\nCVV: {Cvv}\nOwner: {Owner}";
        }
    }
}