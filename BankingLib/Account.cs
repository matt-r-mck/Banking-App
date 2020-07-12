using BankingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    public class Account { 
        
        //Must be set to static so that all instances receive same value.
        private static int NextAccountNumber = 1; 
        private static string RoutingNumber = "42361088";
        public int AccountNumber { get; private set; }
        private double Balance { get; set; } = 0;
        public string Description { get; set; }
        private static Account[] AccountArray = new Account[5]; 
        private static int NextIndex = 0;

        public Account() { 
            this.AccountNumber = NextAccountNumber++; 
            this.Description = "New Account";
        }

        /// <summary>
        /// Refactoring of fmethod to check if passed ammount is negative.
        /// Supports deposit and withdraw methods.
        /// </summary>
        /// <param name="Ammount"> Ammount user is trying to pass in callinng method. </param>
        /// <returns> Exception if negative, false if else. </returns>
        private bool IsAmmountNegative(double Ammount) { 
            if (Ammount < 0) {
                Console.WriteLine("ERROR: Must enter positive number.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Refactoring of an insufficient funds check.
        /// Supports any withdraw method.
        /// </summary>
        /// <param name="Ammount"> Ammount user is attampting to withdraw. </param>
        /// <returns> Exception if insufficient, false if else. </returns>
        private bool InsufficientFunds(double Ammount) { 
            if (Ammount > Balance) {
                var msg = $"Balance is {Balance}; Withdraw ammount is {Ammount}";
                var ex = new InsufficientFundsException(msg); 
                ex.AccountNumber = AccountNumber;
                ex.Description = Description;
                ex.Balance = Balance;
                ex.Ammount = Ammount;
                throw ex;
            }
  
            return false;
        }

        /// <summary>
        /// Method adds account to our bank.
        /// </summary>
        /// <param name="AccountInstance"> Information from instance of created account. </param>
        public static void AddAccount(Account AccountInstance) { 
            AccountArray[NextIndex] = AccountInstance;
            NextIndex++;
        }

        /// <summary>
        /// Writes info for all of our accounts to console.
        /// </summary>
        public static void ListAccounts() { 
            for(var idx = 0; idx < NextIndex; idx++) {
                var account = AccountArray[idx];
                Console.WriteLine($"ID: {account.AccountNumber}; Desc: {account.Description}; Bal: {account.CheckBalance()}");
            }
        }

        /// <summary>
        /// Transfer method calls both withdraw and deposit to move money to and from respective accounts.
        /// </summary>
        /// <param name="ToAccount"> Account to transfer funds to. </param>
        /// <param name="Ammount"> Ammount to be moved. </param>
        /// <returns> Exception if bubbles up from called methods, true and message if worked. </returns>
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

        /// <summary>
        /// Allows user to deposit money into account.
        /// </summary>
        /// <param name="Ammount"> Ammount to be deposited. </param>
        /// <returns> Exception if bubbles up, True and message if worked. </returns>
        public bool Deposit(double Ammount) {
            if (IsAmmountNegative(Ammount)) {
                return false;
            }
            InsufficientFunds(Ammount);

            Balance += Ammount;
            Console.WriteLine($"Deposit successful! Current Balance: {Balance}");
            return true;
        }

        /// <summary>
        /// Allows user to make withdraws from accounts.
        /// </summary>
        /// <param name="Ammount"> Ammount to be withdwarn. </param>
        /// <returns> Exception if bubbles up, True and message if worked. </returns>
        public bool Withdraw(double Ammount) {
            if (IsAmmountNegative(Ammount)) { 
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
 
        public static string GetRoutingNumber() {
            return RoutingNumber;
        }


    }
}
