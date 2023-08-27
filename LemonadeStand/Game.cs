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
        //public List<Day> Days;
        public Day[] Days;
        // constructor (SPAWNER)
        public Game()
        {
            Store = new Store();
            
        }

        // member methods (CAN DO)
        public void RunGame()
        {

            DisplayWelcome();

            Days = new Day[Duration];

            foreach (Day day in Days) 
            {
                Day newDay = new Day(1);
                Console.WriteLine($"Day {(Duration + 1) - Duration});
            }

            EnterStore();
        }
        public void EnterStore()
        {
            Console.WriteLine("Welcome to... Nothin' but LemonadeStand Supply Co.\n ");
            Store.DisplayCatalog();
            Store.SellItems(Player);
        }
        public void DisplayWelcome()
        {
            Console.WriteLine("Lemonade Stand\n");/////////// explain the game play and objectives...."
            Player = new Player(UserInterface.GetPlayerName());
            Duration = UserInterface.GetGameLength();
            Console.WriteLine($"Alright {Player.Name}, you have {Duration} day/s to make as much profit as you can.  Let's begin!");
        }
    }
}
