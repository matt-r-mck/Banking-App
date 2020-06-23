using BankingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    public class Account { //default access modifier internal
        //properties
        private static int NextAccountNumber = 1; //must be set to static so that all instances call same value
        private static string RoutingNumber = "42361088";
        public int AccountNumber { get; private set; }//can be seen publicly, can be set privately
        private double Balance { get; set; } = 0;//can call balance, but can't see it
        public string Description { get; set; }
        private static Account[] AccountArray = new Account[5]; //needed to print statements makes AccountArray an array type. allows 5 total acounts
        private static int NextIndex = 0;

        public Account() { //default constructor sets initial name for account
            this.AccountNumber = NextAccountNumber++; //sets new account number to 1 first, increments
            this.Description = "New Account";
        }

        private bool IsAmmountNegative(double Ammount) { //refactoring duplicated code
            if (Ammount < 0) {
                Console.WriteLine("ERROR: Must enter positive number.");
                return true;
            }
            return false;
        }

        private bool InsufficientFunds(double Ammount) {//refactoring
            if (Ammount > Balance) {
                var msg = $"Balance is {Balance}; Withdraw ammount is {Ammount}";
                var ex = new InsufficientFundsException(msg); //Exception.Insuff...
                ex.AccountNumber = AccountNumber;
                ex.Description = Description;
                ex.Balance = Balance;
                ex.Ammount = Ammount;
                throw ex;
            }
  
            return false;
        }

        public static void AddAccount(Account AccountInstance) { //adds accounts to array
            AccountArray[NextIndex] = AccountInstance;
            NextIndex++;
        }

        public static void ListAccounts() { //gets balances and id's to print statement
            for(var idx = 0; idx < NextIndex; idx++) {
                var account = AccountArray[idx];
                Console.WriteLine($"ID: {account.AccountNumber}; Desc: {account.Description}; Bal: {account.CheckBalance()}");
            }
        }

        public bool Transfer(Account ToAccount, double Ammount) {
            var success = Withdraw(Ammount);
            if (!success) {
                Console.WriteLine("ERROR: Transfer Failed - See log file");
                return false;
            }
            success = ToAccount.Deposit(Ammount);
            if (!success) {
                Console.WriteLine("ERROR: Transfer Failed - See log file");
                Deposit(Ammount);
                return false;
            }
            Console.WriteLine($"Transfer of {Ammount} successful! Current Balance: {Balance}");
                return true;
        }

        public bool Deposit(double Ammount) {
            if (IsAmmountNegative(Ammount)) { //inserts new method to refactor code and returns bool
                return false;
            }
            InsufficientFunds(Ammount);

            Balance += Ammount;
            Console.WriteLine($"Deposit successful! Current Balance: {Balance}");
            return true;
        }

        public bool Withdraw(double Ammount) {
            if (IsAmmountNegative(Ammount)) { //inserts new method to refactor code and returns bool
                return false;
            }
            try {
                InsufficientFunds(Ammount);
            } catch (Exceptions.InsufficientFundsException ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
            Balance -= Ammount;
            Console.WriteLine($"Withdraw successful! Current Balance: {Balance}");
            return true;
        }

        public double CheckBalance() {
            return Balance;
        }
 
        public static string GetRoutingNumber() { //makinga method static == can call without an instance/constructor
            return RoutingNumber;
        }


    }
}
