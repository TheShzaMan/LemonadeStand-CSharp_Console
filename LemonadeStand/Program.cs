using System.Data.SqlTypes;

namespace LemonadeStand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            //store.DisplayCatalog();
            Game game1 = new Game();
            game1.RunGame();
            Inventory inventory = new Inventory();
            //inventory.DisplayCurrentInventory();
           // player.MakeLemonade(UserInterface.GetNumberOfPitchers());
           // player.SellLemonade(6);

        }
    }
}