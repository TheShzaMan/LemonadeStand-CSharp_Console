using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class TypeX : Customer
    {
        public TypeX()
        {
            Type = "TypeX";
            buyProbability = new List<string> { "buy", "no" };
        }
        public override void DecideToBuy(string actualWeather, int actualTemp, double pricePerServing)
        {
           
            buyChoice = buyProbability[Rndm.Next(buyProbability.Count)];
            if (buyChoice == "buy")
            {
                willBuy = true;
                if (pricePerServing == 1)
                {
                    servingsOrdered = 1;
                }
                else if (pricePerServing == 2)
                {
                    servingsOrdered = 2;
                }
                else if (pricePerServing >= 4)
                {
                    servingsOrdered = 4;
                }
                else
                {
                    willBuy = false;
                }
            }
        }
    }
}
