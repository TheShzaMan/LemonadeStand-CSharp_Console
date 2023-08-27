using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;
        public string[] ItemNames;
        public double[] Prices; ///////fix these arrays so that they can be used everywhere.
        /// </summary>
        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .50;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
            ItemNames = new string[] { "lemons", "cases of sugar cubes", "bags of ice", "cases of cups" };
            Prices = new double[] { pricePerLemon, pricePerSugarCube, pricePerIceCube, pricePerCup};

        }

        // member methods (CAN DO)
        
        public void SellItems(Player player)
        {
            int indexOfItemToBuy = UserInterface.ChooseItem(ItemNames);
            string itemName = ItemNames[indexOfItemToBuy];
            int quantityToBuy = UserInterface.GetNumberOfItems(itemName);
            
            double transactionAmount = CalculateTransactionAmount(quantityToBuy, Prices[indexOfItemToBuy]);
            if (player.wallet.Money >= transactionAmount)
            {
                player.wallet.PayMoneyForItems(transactionAmount);

                if(indexOfItemToBuy == 0) 
                { 
                    player.inventory.AddLemonsToInventory(quantityToBuy); 
                }
                if(indexOfItemToBuy == 1)
                {
                    player.inventory.AddSugarCubesToInventory(quantityToBuy * 10);
                }
                if (indexOfItemToBuy == 2)
                {
                    player.inventory.AddIceCubesToInventory(quantityToBuy * 100);
                }
                if (indexOfItemToBuy == 3)
                {
                    player.inventory.AddCupsToInventory(quantityToBuy * 50);
                }
            }
            //else "sorry you don't have enough money to make this purchase"
                
        }
        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }

        public void DisplayCatalog()
        {
            Console.WriteLine($"\nItem#\t    Item Name\t       Price\n" +
                $" [1]\tLemons (ea).............${pricePerLemon:F2}ea\n" +
                $" [2]\tSugar Cubes (10/cs).....${pricePerSugarCube * 10:F2}\n" +
                $" [3]\tBag of Ice (100cubes)...${pricePerIceCube * 100:F2}\n" +
                $" [4]\tCups (50/cs)...........${pricePerCup * 50F:F2}");
        }
        //public void SellLemons(Player player)
        //{
        //    int lemonsToPurchase = UserInterface.GetNumberOfItems("Lemons");
        //    double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
        //    if(player.wallet.Money >= transactionAmount)
        //    {
        //        player.wallet.PayMoneyForItems(transactionAmount);
        //        player.inventory.AddLemonsToInventory(lemonsToPurchase);
        //    }
        //}

        //public void SellSugarCubesCase(Player player)
        //{
        //    int sugarCasesToPurchase = UserInterface.GetNumberOfItems("sugar cubes cases");
        //    double transactionAmount = CalculateTransactionAmount(sugarCasesToPurchase, (pricePerSugarCube * 10));
        //    if(player.wallet.Money >= transactionAmount)
        //    {
        //        PerformTransaction(player.wallet, transactionAmount);
        //        player.inventory.AddSugarCubesToInventory(sugarCasesToPurchase * 10);
        //    }
        //}

        //public void SellBagsOfIce(Player player)
        //{
        //    int bagsOfIceToPurchase = UserInterface.GetNumberOfItems("bags of ice");
        //    double transactionAmount = CalculateTransactionAmount(bagsOfIceToPurchase, (pricePerIceCube * 100));
        //    if(player.wallet.Money >= transactionAmount)
        //    {
        //        PerformTransaction(player.wallet, transactionAmount);
        //        player.inventory.AddIceCubesToInventory(bagsOfIceToPurchase * 100);
        //    }
        //}

        //public void SellCups(Player player)
        //{
        //    int fiftyCupsToPurchase = UserInterface.GetNumberOfItems("cases of 50 Cups");
        //    double transactionAmount = CalculateTransactionAmount(fiftyCupsToPurchase, (pricePerCup * 50));
        //    if(player.wallet.Money >= transactionAmount)
        //    {
        //        PerformTransaction(player.wallet, transactionAmount);
        //        player.inventory.AddCupsToInventory(fiftyCupsToPurchase * 50);
        //    }
        //}

    }
}
