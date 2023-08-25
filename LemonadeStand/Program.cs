using System.Data.SqlTypes;

namespace LemonadeStand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game game1 = new Game();
            //game1.RunGame();
            Inventory inventory = new Inventory();
            inventory.UseLemonsFromInventory(30);
            

        }
    }
}