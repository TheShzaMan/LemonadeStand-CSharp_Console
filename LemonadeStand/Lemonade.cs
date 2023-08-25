using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Lemonade : Item
    {
        public int ServingsOfLemonade;
        public Lemonade()
        {
            ServingsOfLemonade = 0;
        }
        public void PourLemonade(int servings)
        {
            if (ServingsOfLemonade >= servings)
            { 
                ServingsOfLemonade -= servings;
            }
            else
            {
                Console.WriteLine();
            }
    }
}
