using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {
        public static int ChooseItem(string[] itemArray)
        {
            bool userInputIsAnInteger = false;
            int itemNumberSelection = -1;
            while (!userInputIsAnInteger || itemNumberSelection < 0 || itemNumberSelection > itemArray.Length)
            {
                Console.WriteLine("Enter an item number to continue to purchase (or 0 to exit)");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out itemNumberSelection);
            }
            ///////////Need to account for input 0.  If itemNumberSelection = 0 then exit store
            int itemIndex = itemNumberSelection - 1;
            //string itemIndex = Store.ItemNames[itemIndex];
            return itemIndex;
        }
        public static int GetNumberOfItems(string itemName)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;
           
            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemName + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }
            return quantityOfItem;
        }

        public static int GetNumberOfPitchers()
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("Each pitcher pours 8 Cups. How many pitchers would you like to make?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }
            return quantityOfItem;
        }
        public static string GetPlayerName()
        {
            string playerNameInput;

            Console.WriteLine("\nPlease enter a name for yourself:");
            playerNameInput = Console.ReadLine();
            Console.WriteLine($"\nHello {playerNameInput}, pleasure to meet you!\n" +
                $"press 'enter' to continue"); Console.ReadLine();
            return playerNameInput;
        }
        public static int GetGameLength()
        {
            int numberOfDays = -1;
            bool userInputIsAnInteger = false;
            
            while (!userInputIsAnInteger ||  numberOfDays <= 0) 
            {
                Console.WriteLine("How many days would you like to play?\n\nPlease enter a positive integer. For example, if you wanted three days, enter '3'. If a week, enter '7')");
                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(),out numberOfDays);
            }
            return numberOfDays;
        }
    }
}
