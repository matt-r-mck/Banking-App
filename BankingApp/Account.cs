using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    class Account {

        public int AccountNumber { get; set; }
        public double Balance { get; set; }
        public string Description { get; set; }

        public void Deposit(double Ammount) {
            if (Ammount < 0) { 
                Console.WriteLine("ERROR: Ammount must be positive");
            return;
        }
            Balance += Ammount;
        }

        public void Withdraw(double Ammount) {
            if (Ammount <= 0) {
                Console.WriteLine("Error: can only enter positive number");
                return; }
            else 
            if (Ammount > Balance) {
                Console.WriteLine("ERROR: Insufficient Funds");
                return;
            }
                Balance -= Ammount;
        }

        public double CheckBalance() {
            return Balance;
        }

        public Account() { //default constructor sets initial name for account
            this.AccountNumber = 0;
            this.Description = "New Account";
        }

    }
}
