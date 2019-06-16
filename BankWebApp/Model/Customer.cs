using System;

namespace BankWebApp.Model
{
    public class Customer
    {
        public long CustomerId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string CreatedDate { get; set; }

        public string ActiveFlag { get; set; }

        public string Comments { get; set; }

        public Customer()
        {
        }
    }
}