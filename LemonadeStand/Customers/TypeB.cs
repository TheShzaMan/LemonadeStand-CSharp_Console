using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class TypeB : Customer
    {
        public TypeB()
        {
            Type = "TypeB";
            buyProbability = new List<string> { "buy", "buy", "no", "no", "no" };
        }
        public override void DecideToBuy(string actualWeather, int actualTemp, double pricePerServing)
        {
            if (actualWeather == "sunny")
            {
                buyProbability.Add("buy");
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
                buyProbability.Add("no");
            }
            if (actualWeather == "stormy")
            {
                buyProbability.Add("buy");

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
                    servingsOrdered = 1;
                }
                else
                {
                    willBuy = false;
                }
            }
        }
    }
}
