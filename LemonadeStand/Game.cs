using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LemonadeStand
{
    internal class Game
    {
        // member variables (HAS A)
        public Player Player;
        public Store Store;
        public int Duration;
        public Day CurrentDay;
        public double DailySalesTotal;
        public double GrandTotalSales;
        //public List<Day> Days;
        public Day[] Days;
        // constructor (SPAWNER)
        public Game()
        {
            Store = new Store();
            DailySalesTotal = 0;

        }

        // member methods (CAN DO)
        public void RunGame()
        {
            DisplayWelcome();
            RollTheDay();

                //DisplayGrandTotalSales(DailySalesTotal);
        }
        public double RollTheDay()
        {
            for (int i = 0; i < Duration; i++) 
            {
                int dayNumber = i + 1;
                CurrentDay = new Day(dayNumber);
                CurrentDay.SetupTheDay(Player);

                EnterStore();

                Player.MakeLemonade();

                CurrentDay.DisplayActualWeather(); 

                CurrentDay.AddCustomer();

                DailySalesTotal = CurrentDay.OpenForBusiness();
            }
            return DailySalesTotal;
            
        }
        public void EnterStore()
        {
            Console.WriteLine("Welcome to... Nothin' but LemonadeStand Supply Co.\n ");
            Store.DisplayCatalog();
            Store.SellItems(Player);
        }
        public void DisplayWelcome()
        {
            Console.WriteLine("\tWelcome to Lemonade Stand\n\n" +
                "  In this simulation you will be able to tap into your inner entrepreneur as you\n" +
                "play out the amount of days of your choosing, from forecasting your business sales depending on weather and\n" +
                "and price, to stocking up on supplies at the store and making just enough lemonade to match those predictions.\n" +
                "You'll start off with a small inventory and some cash and the weather prediction for the day.  With that info you'll head\n" +
                "first to the supply store to prepare for the business day. \n" +
                "Any extra lemonade will be thrown out at night.  \n" +
                "If you run out of product your day will end and if you run out of money,\n" +
                "the game ends in a loss.  \nYour total sales are tracked for the day and for the duration of days you will choose at the start.\n" +
                "Try to not only make it to the end, but set your profit sights to the moon and rule the lemonade game");               
            
            Player = new Player(UserInterface.GetPlayerName());
            Duration = UserInterface.GetGameLength();
            
            Console.WriteLine($"Alright {Player.Name}, you have {Duration} day/s to make as much profit as you can.  Let's begin!");
        }
        public void DisplayGrandTotalSales(double dailySales)
        {
            DailySalesTotal = dailySales;
            GrandTotalSales += DailySalesTotal; 
            Console.WriteLine($"Your grand total sales throughout this current game are ${GrandTotalSales}!\n\n");

        }
    }
}

        //public double DailySales(double income)
        //{
        //    double incomeFromSale = income;
        //    DailySalesTotal = DailySalesTotal + incomeFromSale;
        //    Console.WriteLine($"Your total sales for the day were ${DailySalesTotal}!\n\n");
        //    return DailySalesTotal;
        //}