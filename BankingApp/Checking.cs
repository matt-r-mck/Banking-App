using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    public class Checking : Account {

        public int NextElectronicCheckNumber { get; private set; } = 10000;

        public bool WriteCheck(string Payee, double Ammount, int? PaperCheckNumber = null) { //if null is electronic check which must be assigned
            var checkNumber = (PaperCheckNumber == null) //ternary operator sets check number equal to next number then increments if null
                ? NextElectronicCheckNumber++ 
                : PaperCheckNumber.Value;//else sets to entered paper check number
            if (!Withdraw(Ammount)) {
                Console.WriteLine("ERROR: WriteCheck Failed; see log!");
                return false;
            }
            return true;
        }

        public Checking() : base() {
            Description = "New Checking Acount";

        }

    }
}
