using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    public class Savings : Account {

        public double _InterestRate { get; private set; } = 0;//set by default, others can get, not set
        
        private double CalcualteIntrestAmmount (int NumberOfMonths) {
            return _InterestRate / 12 * NumberOfMonths * CheckBalance();
        }

        public bool CalculateAndDepositInterest(int NumberOfMonths) {//calculates and deposits if interest rate passes test
            if(NumberOfMonths <= 0) {
                Console.WriteLine("Number of months must be greater than zero.");
                return false;
            }
            var InterestToBeDeposited = CalcualteIntrestAmmount(NumberOfMonths);
            return Deposit(InterestToBeDeposited);
        }

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

        public Savings() : base() { //constructor
            Description = "New Savings Account";

        }

    }
}
