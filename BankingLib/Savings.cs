using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {

    /// <summary>
    /// Models a savings account at our bank. 
    /// Inherits accouunt class, also accounts for intrest
    /// </summary>
    public class Savings : Account {
        
        /// <summary>
        /// Interest rate is set privately to allow other methods to use but not change rate.
        /// </summary>
        public double _InterestRate { get; private set; } = 0;
        
        /// <summary>
        /// Calculates interest rate privately within class.
        /// </summary>
        /// <param name="NumberOfMonths"> Interest gathered across this number of months. </param>
        /// <returns> Ammount to add to total. </returns>
        private double CalcualteIntrestAmmount (int NumberOfMonths) {
            return _InterestRate / 12 * NumberOfMonths * CheckBalance();
        }

        /// <summary>
        /// Calls to calculate interest to calculate interest and deposit.
        /// </summary>
        /// <param name="NumberOfMonths"></param>
        /// <returns></returns>
        public bool CalculateAndDepositInterest(int NumberOfMonths) {//calculates and deposits if interest rate passes test
            if(NumberOfMonths <= 0) {
                Console.WriteLine("Number of months must be greater than zero.");
                return false;
            }
            var InterestToBeDeposited = CalcualteIntrestAmmount(NumberOfMonths);
            return Deposit(InterestToBeDeposited);
        }

        /// <summary>
        /// Method to ensure interest rate stays within predefined range.
        /// </summary>
        /// <param name="NewInterestRate"></param>
        /// <returns></returns>
        public bool InterestRate (double NewInterestRate) { //sets interest rate
            if(NewInterestRate < 0) {
                Console.WriteLine("ERROR: Interest Rate must be positive.");
                return false;
            }
            if(NewInterestRate > 10) {
                Console.WriteLine("ERROR: Interest rate must be less than 10.0!");
                return false;
            }
            _InterestRate = NewInterestRate;
            return true;
        }

        /// <summary>
        /// Constructor differentiates itself as a Savings Account.
        /// </summary>
        public Savings() : base() {
            Description = "New Savings Account";

        }

    }
}
