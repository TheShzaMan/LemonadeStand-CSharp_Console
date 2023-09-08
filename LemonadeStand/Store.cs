using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        private string[] ItemNames;
        private double[] Prices; 
        
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
        public void DisplayCatalog()
        {
            Console.WriteLine($"\nItem#\t    Item Name\t       Price\n" +
                $" [1]\tLemons (ea).............${pricePerLemon:F2}ea\n" +
                $" [2]\tSugar Cubes (10/cs).....${pricePerSugarCube * 10:F2}\n" +
                $" [3]\tBag of Ice (100cubes)...${pricePerIceCube * 100:F2}\n" +
                $" [4]\tCups (25/cs)...........${pricePerCup * 25:F2}");
        }
        public void SellItems(Player player)
        {
            string itemName;
            int quantityToBuy;
            int indexOfItemToBuy = -2;

            do
            {
                indexOfItemToBuy = UserInterface.ChooseItem(ItemNames);
                if (indexOfItemToBuy == -1)
                break;
                itemName = ItemNames[indexOfItemToBuy];
                double transactionAmount; 
                    
                if (indexOfItemToBuy == 0)
                {
                    quantityToBuy = UserInterface.GetNumberOfItems(itemName);
                    transactionAmount = CalculateTransactionAmount(quantityToBuy, Prices[indexOfItemToBuy]);
                    if (transactionAmount <= player.wallet.Money)
                    {
                        player.wallet.PayMoneyForItems(transactionAmount);
                        player.inventory.AddLemonsToInventory(quantityToBuy);
                        Console.WriteLine($"You now have {player.inventory.Lemons.Count} lemons and ${player.wallet.Money} in your wallet.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money to cover this purchase.");
                    }
                }
                else if (indexOfItemToBuy == 1)
                {
                    quantityToBuy = UserInterface.GetNumberOfItems(itemName);
                    transactionAmount = CalculateTransactionAmount(quantityToBuy * 10, Prices[indexOfItemToBuy]);
                    if (transactionAmount <= player.wallet.Money)
                    {
                        player.wallet.PayMoneyForItems(transactionAmount);
                        player.inventory.AddSugarCubesToInventory(quantityToBuy * 10);
                        Console.WriteLine($"You now have {player.inventory.SugarCubes.Count} sugar cubes and ${player.wallet.Money} in your wallet.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money to cover this purchase.");
                    }
                }
                else if (indexOfItemToBuy == 2)
                {
                    quantityToBuy = UserInterface.GetNumberOfItems(itemName);
                    transactionAmount = CalculateTransactionAmount(quantityToBuy * 100, Prices[indexOfItemToBuy]);
                    if (transactionAmount <= player.wallet.Money)
                    {
                        player.wallet.PayMoneyForItems(transactionAmount);
                        player.inventory.AddIceCubesToInventory(quantityToBuy * 100);
                        Console.WriteLine($"You now have {player.inventory.IceCubes.Count} ice cubes and ${player.wallet.Money} in your wallet.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money to cover this purchase.");
                    }
                }
                else if (indexOfItemToBuy == 3)
                {
                    quantityToBuy = UserInterface.GetNumberOfItems(itemName);
                    transactionAmount = CalculateTransactionAmount(quantityToBuy * 25, Prices[indexOfItemToBuy]);
                    if (transactionAmount <= player.wallet.Money)
                    {
                        player.wallet.PayMoneyForItems(transactionAmount);
                        player.inventory.AddCupsToInventory(quantityToBuy * 25);
                        Console.WriteLine($"You now have {player.inventory.Cups.Count} cups and ${player.wallet.Money} in your wallet.");
                        indexOfItemToBuy = -2;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money to cover this purchase.");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, but you don't have enough money to make this purchase");
                    indexOfItemToBuy = -2;
                }
            } while (indexOfItemToBuy != -1);
;
        }
        
        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }
        
       
        //private void PerformTransaction(Wallet wallet, double transactionAmount)
        //{
        //    wallet.PayMoneyForItems(transactionAmount);
        //}
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
