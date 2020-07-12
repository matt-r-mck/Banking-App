using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp.Exceptions {

    /// <summary>
    /// Exception class to produce Account Number and details of account thrown.
    /// </summary>
    public class InsufficientFundsException : Exception {

        public int AccountNumber { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public double Ammount { get; set; }

        /// base constructor
        public InsufficientFundsException() : base() { } 

        //with message
        public InsufficientFundsException(string message) : base (message) { } 

        //with inner exception
        public InsufficientFundsException(string message, Exception innerException) : base(message, innerException) { } 

    }
}
