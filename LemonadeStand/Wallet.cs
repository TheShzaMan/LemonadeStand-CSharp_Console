using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Wallet
    {
        // member variables (HAS A)
        private double money;
        public double Money
        {
            get
            {
                return money;
            }
        }

        //constructor (SPAWNER)
        public Wallet()
        {
            money = 20.00;
        }

        //Member Methods (CAN DO)
        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }

        public double AcceptMoney(double income)
        {
            money += income;
            return income;

        }
        public void ShowBalance()
        {
            Console.WriteLine($"\nYou have a total of ${money} in your wallet.\n <press enter>");Console.ReadLine();
        }
    }
}
