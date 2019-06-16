
using System;

namespace BankWebApp.Model
{
    public class Account

    {
        public int AccountId { get; set; }

        public string Type { get; set; }

        public string Comments { get; set; }

        public int EmployeeId { get; set; }

        public string ActiveFlag { get; set; }

        public DateTime CreatedDate { get; set; }

        private int CreditLimit { get; set; }

        public int CustomerId { get; set; }

        public Account()
        {
        }
    }
}