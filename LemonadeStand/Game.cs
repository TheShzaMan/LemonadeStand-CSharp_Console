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
        // constructor (SPAWNER)
        public Game()
        {
            Store = new Store();
        }
        
        // member methods (CAN DO)
        public void RunGame()
        {

            //DisplayWelcome();
            Player = new Player(UserInterface.GetPlayerName());
            //GoToStore();
        }
        public void GoToStore()
        {
            Console.WriteLine("Welcome to... Nothin' but LemonadeStand Supply Co.\n ");
            Store.DisplayCatalog();
            Player.buyItems(itemToBuy, quantity) UserInterface.GetNumberOfItems("lemons"); //stopped here end of night. add a buy items method to player and pass in item and quantity
            UserInterface.GetNumberOfItems("Sugar Cubes");
            UserInterface.GetNumberOfItems("Bag of Ice");
            UserInterface.GetNumberOfItems("Cups");


        }
    }
}
