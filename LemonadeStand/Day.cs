using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LemonadeStand
{
    internal class Day
    {
        // member variables (HAS A)
        //public Player Player;
        public Weather Weather;
        public List<Customer> TodaysCustomers;
        public int DayNumber;
        public double DailySales;

        // constructor (SPAWNER)
        public Day(int dayNumber)
        {
            DailySales = 0;
            DayNumber = dayNumber;
            Weather = new Weather();
            //Weather.GenerateWeatherCondition();
            //Weather.GenerateTemperature();
            //Weather.ForecastTemp();
            TodaysCustomers = new List<Customer> { new TypeA(), new TypeB(), new TypeC(), new TypeX() };
        }

        // member methods (CAN DO)
       
        public void SetupTheDay(Player player)
        {
            //Player = player;
            Console.WriteLine($"\n\n\t**DAY {DayNumber}**\n\n");
            Weather.DisplayForecast();
            player.inventory.DisplayCurrentInventory();
            player.wallet.ShowBalance();
            Console.WriteLine($"\nAlright {player.Name}, let's head to the store to prepare for today's business\n <press enter>");
            Console.ReadLine();
        }
        //public void RunDay()
        //{

        //}
        public void DisplayActualWeather()
        {
            Console.WriteLine($"Today's actual weather turned out to be {Weather.ActualTemp} degrees and {Weather.ActualCondition}.\n" +
                $"Press enter to see how it effects the lemonade biz...\n"); Console.ReadLine();
        }
        public void AddCustomer()
        {
            Random rndm = new Random();
            int rndmCustIndex = rndm.Next(TodaysCustomers.Count);
            int numberOfCusts;
            
            if (Weather.ActualTemp > 70 && Weather.ActualCondition == "sunny")
            {
                numberOfCusts = rndm.Next(15, 20);
                for (int i = 0; i < numberOfCusts; i++)
                {
                    
                    TodaysCustomers.Add(TodaysCustomers[rndmCustIndex]);
                }
            }
            else if ((Weather.ActualCondition == "stormy" || Weather.ActualCondition == "windy") && Weather.ActualTemp > 40)
            {
                numberOfCusts = rndm.Next(5, 15);
                for (int i = 0; i < numberOfCusts; i++)
                {
                    TodaysCustomers.Add(TodaysCustomers[rndmCustIndex]);
                }
            }
            else if (Weather.ActualCondition == "freezing" || Weather.ActualTemp <= 40)
            {
                numberOfCusts = rndm.Next(10);
                for (int i = 0; i < numberOfCusts; i++)
                {
                    TodaysCustomers.Add(TodaysCustomers[rndmCustIndex]);
                }
            }
        }
        public void OpenForBusiness(Player player)
        {
            while (player.canSell)
            {
                foreach (Customer customer in TodaysCustomers)
                {
                    customer.DecideToBuy(Weather.ActualCondition, Weather.ActualTemp, player.recipe.price);
                    double income = customer.BuyLemonade(player);
                    DailySales += income;
                }
            }
            Console.WriteLine($"Your total sales for the day were ${DailySales}!\n\n");
        }
    }
}
