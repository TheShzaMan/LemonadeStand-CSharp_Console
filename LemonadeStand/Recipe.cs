using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        // member variables (HAS A)
        public int numberOfLemons;
        public int numberOfSugarCubes;
        public int numberOfIceCubes;
        public double price;


        // constructor (SPAWNER)
        public Recipe()
        {
            numberOfLemons = 4;
            numberOfSugarCubes = 5;
            numberOfIceCubes = 10;
            price = 1;
        }

        //Member Methods (CAN DO)
        public void DisplayRecipe()
        {
            //Console.WriteLine($"Currently, your recipe for making 1 pitcher of lemonade calls for:"); ////**sub in if adding option for recipe changes
            Console.WriteLine($"\nThe recipe for making 1 pitcher of lemonade calls for:");
            Console.WriteLine($"{numberOfLemons} lemons\n" +
                $"{numberOfSugarCubes} sugar cubes\n" +
                $"{numberOfIceCubes} ice cubes\n" +
                $"you will also need to have at least 8 cups per pitcher to serve your lemonade.");
            //Console.WriteLine("Press 1 if you would like to adjust the recipe, or press 2 to keep it as is for now...);////add in if adding this as an option
            Console.WriteLine($"\nYou have the price set at ${price} per cup");
        }
        public void AdjustPrice()
        {
            double newPrice = 0;
            
            Console.WriteLine("You can change the price if you'd like, just keep in mind how it could effect sales.");
            newPrice = UserInterface.GetPositiveNumber("To change price, enter a positive number without dollar sign. Enter 0 to keep current price");

            if (newPrice > 0)
            {
                price = newPrice;
                Console.WriteLine($"\nYou have the price set at ${price} per cup");
            }
            else if (newPrice == 0) ;
            

            
        }
    }
}
