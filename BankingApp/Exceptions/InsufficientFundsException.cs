using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Exceptions {
    public class InsufficientFundsException : Exception {

        public int AccountNumber { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public double Ammount { get; set; }

        public InsufficientFundsException() : base() { } /// base constructor

        public InsufficientFundsException(string message) : base (message) { } //with message

        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { } //with inner exception

    }
}
