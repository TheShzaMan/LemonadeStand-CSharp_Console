using System.Data.SqlTypes;

namespace LemonadeStand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game game1 = new Game();
            //game1.RunGame();
            Player player = new Player(UserInterface.GetPlayerName());
            Inventory inventory = new Inventory();
            //inventory.DisplayCurrentInventory();
            player.MakeLemonade(UserInterface.GetNumberOfPitchers());
            player.SellLemonade(6);

        }
    }
}