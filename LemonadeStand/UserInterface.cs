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
                Console.WriteLine($"Please enter the amount of {itemName} you would like to buy, or enter 0 to cancel");

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
                Console.WriteLine("Each pitcher (1) of lemonade pours 8 Cups. How many pitchers would you like to make?");
                Console.WriteLine("Please enter a whole number for the amount. For example, if you want 2 pitchers, enter (2):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }
            return quantityOfItem;
        }
        public static string GetPlayerName()
        {
            string playerNameInput = "";

            while (playerNameInput == "")
            {
                Console.WriteLine("\nPlease enter a name for yourself:");
                playerNameInput = Console.ReadLine();
            }
            Console.WriteLine($"\nHello {playerNameInput}, pleasure to meet you!\n" +
                $"<press 'enter' to continue>"); Console.ReadLine();
            return playerNameInput;
        }
        public static int GetGameLength()
        {
            int numberOfDays = -1;
            bool userInputIsAnInteger = false;
            
            while (!userInputIsAnInteger ||  numberOfDays <= 0) 
            {
                Console.WriteLine("How many days would you like this simulation to play out?\n\nPlease enter a positive integer. For example, if you wanted three days, enter '3'. If a week, enter '7')");
                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(),out numberOfDays);
            }
            return numberOfDays;
        }
        
        ///////////////////// -static polymorphism-  in the future, make a similar version of the method below and overload it to get more use out of singe method.  
        ////////////////////          It could replace most of the above methods in this class for less code and be more universal. 
        public static double GetPositiveNumber(string promptToBeRepeatedUntilInputMatch)
        {
            double neededNumber = -1;
            bool correctInputType = false;

            while (!correctInputType || neededNumber < 0)
            {
                Console.WriteLine($"{promptToBeRepeatedUntilInputMatch}");
                correctInputType = Double.TryParse(Console.ReadLine(), out neededNumber);
            }
           return neededNumber;
        }
        public static int GetPositiveNumber(string promptToBeRepeatedUntilInputMatch, bool requestingTypeInt)
        {
            int neededNumber = -1;
            bool correctInputType = false;

            while (!correctInputType || neededNumber < 0)
            {
                Console.WriteLine($"{promptToBeRepeatedUntilInputMatch}");
                correctInputType = Int32.TryParse(Console.ReadLine(), out neededNumber);
            }
            
            return neededNumber;
        }
    }
}
