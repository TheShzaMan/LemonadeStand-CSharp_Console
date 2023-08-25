using System;
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

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
        }

        // member methods (CAN DO)
        public void makeLemonadePitcher()
        {

            int numberOfPitchers = UserInterface.GetNumberOfPitchers();
            inventory.UseLemonsFromInventory(numberOfPitchers * recipe.numberOfLemons);
            inventory.UseSugarCubesFromInventory(numberOfPitchers * recipe.numberOfSugarCubes);
            inventory.UseIceCubesFromInventory(numberOfPitchers * recipe.numberOfIceCubes);
            inventory.AddLemonadeToInventory //need to add code for this.  Also add if statement here checking inventory levels vs requsted pitchers
                 
           

        }
    }
}
