using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Customer
    {
        // member variables (HAS A)
        public string Type;
        public List<string> buyProbability;
        public Random Rndm;
        public bool willBuy;
        public string buyChoice;
        public int servingsOrdered;
        
        // constructor (builder, spawner)
        public Customer()
        {
            Rndm = new Random();
        }
        // methods (CAN DO)
        public virtual void DecideToBuy(string actualWeather, int actualTemp, double pricePerServing)
        {
            
            if (actualWeather == "sunny")
            {
                buyProbability.Add("buy");
                buyProbability.Add("buy");
            }
            if (actualTemp > 80)
            {
                buyProbability.Add("buy");
                buyProbability.Add("buy");
            }
            if (actualWeather == "windy")
            {
                buyProbability.Add("no");
                buyProbability.Add("no");
            }
            if (actualTemp < 55)
            {
                buyProbability.Add("no");
            }
            if (actualWeather == "freezing")
            {
                buyProbability.Add("no");
                buyProbability.Add("no");
                buyProbability.Add("no");
            }
            if (actualWeather == "stormy")
            {
                buyProbability.Add("no");
                buyProbability.Add("no");
            }
            
            buyChoice = buyProbability[Rndm.Next(buyProbability.Count)];
            if (buyChoice == "buy")
            {
                willBuy = true;
                if(pricePerServing <= 2)
                {
                    servingsOrdered = 2;
                }
                else if (pricePerServing <= 4)
                {
                    servingsOrdered = 1;
                }
                else
                {
                    willBuy = false;
                }
            }
        }
        public double BuyLemonade(Player player)
        {
            if (willBuy)
            {
                Console.WriteLine($"Customer: {servingsOrdered} please!");
                double moneyMade = player.SellLemonade(servingsOrdered);
                return moneyMade;
            }
            else
            {
                Console.WriteLine("Nope, not today");
            }
            return 0;
        }
    }
}
