
using System;

namespace BankWebApp.Model
{
    public class Transaction

    {
        public int TransactionId { get; set; }

        public string Type { get; set; }

        public string Comments { get; set; }

        public int AccountId { get; set; }

        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ErrorFlag { get; set; }

        public Transaction()
        {
        }
    }
}