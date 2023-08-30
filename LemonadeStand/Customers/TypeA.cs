using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class TypeA : Customer
    {
        public TypeA()
        {
            Type = "TypeA";
            buyProbability = new List<string> { "buy", "buy", "buy", "no", "no" };
        }
        public override void DecideToBuy(string actualWeather, int actualTemp, double pricePerServing)
        {
            if (actualWeather == "sunny")
            {
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
                buyProbability.Add("no");
            }
            if (actualTemp < 55)
            {
                buyProbability.Add("no");
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
                if (pricePerServing <= 1)
                {
                    servingsOrdered = 3;
                }
                else if (pricePerServing <= 4)
                {
                    servingsOrdered = 2;
                }
                else
                {
                    willBuy = false;
                }
            }

        }
    }
}
