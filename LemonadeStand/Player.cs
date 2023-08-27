﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
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
       
        public bool EvaluateRequest(int numberOfPitchers)
        {
            bool hasEnoughToMakeLemonade = false;
            int lemonsNeeded = numberOfPitchers * recipe.numberOfLemons;
            int sugarCubesNeeded = numberOfPitchers * recipe.numberOfSugarCubes;
            int iceCubesNeeded = numberOfPitchers * recipe.numberOfIceCubes;
            int cupsNeeded = numberOfPitchers * 8;
            if (inventory.Lemons.Count >= lemonsNeeded && 
                inventory.SugarCubes.Count >= iceCubesNeeded && 
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
        public void MakeLemonade(int numberOfPitchers)
        {
            if (EvaluateRequest(numberOfPitchers))
            {
                inventory.UseLemonsFromInventory(numberOfPitchers * recipe.numberOfLemons);
                inventory.UseSugarCubesFromInventory(numberOfPitchers * recipe.numberOfSugarCubes);
                inventory.UseIceCubesFromInventory(numberOfPitchers * recipe.numberOfIceCubes);
                inventory.AddLemonadeToInventory(numberOfPitchers);
            }
        }
        public void SellLemonade(int servingsOrdered)
        {
            if (inventory.LemonadeServings.Count >= servingsOrdered)
            {
                inventory.UseLemonadeFromInventory(servingsOrdered);
                double income = (servingsOrdered * recipe.price);
                wallet.AcceptMoney(income);
                Console.WriteLine($"{Name}: Thank you so much!  Enjoy!");
            }
            else if ((inventory.LemonadeServings.Count - servingsOrdered) < 0)
            {
                Console.WriteLine($"\n{Name}: Sorry, I've only got enough sell you {inventory.LemonadeServings.Count}\n\nYou have sold out for the day.");
                double incomeToSoldOut = (inventory.LemonadeServings.Count * recipe.price);
                wallet.AcceptMoney(incomeToSoldOut);
                inventory.UseLemonadeFromInventory(inventory.LemonadeServings.Count);
            }
            else
            {
                inventory.UseLemonadeFromInventory(servingsOrdered);
                double income = (servingsOrdered * recipe.price);
                wallet.AcceptMoney(income);
                Console.WriteLine($"{Name}: Thank you so much!  Enjoy!\n\nYou have sold out for the day.");
            }
        }
    }
}
