using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    public class Checking : Account {

        /// <summary>
        /// Models a checking account.
        /// Inherits properties of withdraw class.
        /// Handles check numbers and a "WriteCheck" withdraw.
        /// </summary>

        public int NextElectronicCheckNumber { get; private set; } = 10000;

        /// <summary>
        /// Models a check withdraw rater than electronic.
        /// Accounts for increment of check number.
        /// </summary>
        /// <param name="Payee"> Receiving account. </param>
        /// <param name="Ammount"> Ammount on check. </param>
        /// <param name="PaperCheckNumber"> Current check number to get incremented. Defaults to null. </param>
        /// <returns></returns>
        public bool WriteCheck(string Payee, double Ammount, int? PaperCheckNumber = null) {
            var checkNumber = (PaperCheckNumber == null) 
                ? NextElectronicCheckNumber++ 
                : PaperCheckNumber.Value;
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
