using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public string Name;

        // constructor (SPAWNER)
        public Player(string name)
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            Name = name;
        }

        // member methods (CAN DO)
       
        public void MakeLemonade()
        {
            Console.WriteLine($"Okay {Name}, let's make some lemonade!\n");
            recipe.DisplayRecipe();
            recipe.AdjustPrice(Name);
            int numberOfPitchers = UserInterface.GetNumberOfPitchers();
            bool hasEnoughToMakeLemonade = EvaluateRequest(numberOfPitchers);
            if (hasEnoughToMakeLemonade)
            {
                inventory.UseLemonsFromInventory(numberOfPitchers * recipe.numberOfLemons);
                inventory.UseSugarCubesFromInventory(numberOfPitchers * recipe.numberOfSugarCubes);
                inventory.UseIceCubesFromInventory(numberOfPitchers * recipe.numberOfIceCubes);
                inventory.AddLemonadeToInventory(numberOfPitchers);
            }
        }
        public bool EvaluateRequest(int numberOfPitchers)
        {
            bool hasEnoughToMakeLemonade = false;
            int lemonsNeeded = numberOfPitchers * recipe.numberOfLemons;
            int sugarCubesNeeded = numberOfPitchers * recipe.numberOfSugarCubes;
            int iceCubesNeeded = numberOfPitchers * recipe.numberOfIceCubes;
            int cupsNeeded = numberOfPitchers * 8;
            if (inventory.Lemons.Count >= lemonsNeeded && 
                inventory.SugarCubes.Count >= sugarCubesNeeded && 
                inventory.IceCubes.Count >= iceCubesNeeded && 
                inventory.Cups.Count >= cupsNeeded)
            {
                hasEnoughToMakeLemonade = true;
            }
            else
            {
                Console.WriteLine("You don't have enough inventory to make that much.");
            }
            return hasEnoughToMakeLemonade;

        }
        public double SellLemonade(int servingsOrdered)
        {
            bool canSell = true;
            double income = 0;
            while (canSell)
            {
                if (inventory.LemonadeServings.Count > servingsOrdered)
                {
                    inventory.UseLemonadeFromInventory(servingsOrdered);
                    income = (servingsOrdered * recipe.price);
                    wallet.AcceptMoney(income);

                    Console.WriteLine($"{Name}: Thank you so much!  Enjoy!");
                    return income;
                }
                else if (inventory.LemonadeServings.Count < servingsOrdered)
                {
                    Console.WriteLine($"\n{Name}: Sorry, I've only got enough sell you {inventory.LemonadeServings.Count}\n\nYou have sold out for the day.");
                    income = (inventory.LemonadeServings.Count * recipe.price);
                    wallet.AcceptMoney(income);
                    inventory.UseLemonadeFromInventory(inventory.LemonadeServings.Count);
                    canSell = false;
                    return income;
                }
                else
                {
                    inventory.UseLemonadeFromInventory(servingsOrdered);
                    income = (servingsOrdered * recipe.price);
                    wallet.AcceptMoney(income);
                    Console.WriteLine($"{Name}: Thank you so much!  Enjoy!\n\nYou have sold out for the day.");
                    canSell = false;
                    return income;
                }
            }
            return income;
        }
    }
}
