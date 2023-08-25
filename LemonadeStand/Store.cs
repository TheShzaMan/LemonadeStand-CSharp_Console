using System;
using System.Collections.Generic;
using System.Linq;
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

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .50;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("Lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                player.wallet.PayMoneyForItems(transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }
        }

        public void SellSugarCubesCase(Player player)
        {
            int sugarCasesToPurchase = UserInterface.GetNumberOfItems("sugar cubes cases");
            double transactionAmount = CalculateTransactionAmount(sugarCasesToPurchase, (pricePerSugarCube * 10));
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarCasesToPurchase * 10);
            }
        }

        public void SellBagsOfIce(Player player)
        {
            int bagsOfIceToPurchase = UserInterface.GetNumberOfItems("bags of ice");
            double transactionAmount = CalculateTransactionAmount(bagsOfIceToPurchase, (pricePerIceCube * 100));
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(bagsOfIceToPurchase * 100);
            }
        }

        public void SellCups(Player player)
        {
            int fiftyCupsToPurchase = UserInterface.GetNumberOfItems("cases of 50 Cups");
            double transactionAmount = CalculateTransactionAmount(fiftyCupsToPurchase, (pricePerCup * 50));
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(fiftyCupsToPurchase * 50);
            }
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
            Console.WriteLine($"\nLemons..................${pricePerLemon:F2}ea\n" +
                $"Sugar Cubes (10/cs).....${pricePerSugarCube * 10:F2}\n" +
                $"Bag of Ice (100cubes)...${pricePerIceCube * 100:F2}\n" +
                $"Cups (50/cs)...........${pricePerCup * 50F:F2}");
        }
    }
}
