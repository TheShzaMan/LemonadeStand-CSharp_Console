using System.Data.SqlTypes;

namespace LemonadeStand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Game game1 = new Game();
            
            game1.RunGame();
            
            /// UserStories: Pinpoint 2 examples of using SOLID and discuss
            /// 
            ///  Use of the S, or single responsibility principle is demonstrated here with the customer class and its children classes, 
            ///  instead of just one class holding the unique members and methods of the four very different family members, each one has it's own class 
            ///  inheriting from the base customer class.  Each can be multiplied or removed or whatever we need, without fear of disrupting the code of the others.
            ///  
            ///  Use of the O, or Open/Closed principle in SOLID can be seen in a few different classes here, but to pinpoint one, let's look at the Store class.  
            ///  It has many parts within such as groups of objects offered for sale, each with its own price and special grouping which could be tricky
            ///  to update or change if it wasn't designed using Open/closed principle, any of the objects within can be taken out, added on or modified without changing 
            ///  the existing code of other parts.
            

        }
    }
}