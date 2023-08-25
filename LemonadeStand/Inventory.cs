using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        // member variables (HAS A)
        public List<Lemon> Lemons;
        public List<SugarCube> SugarCubes;
        public List<IceCube> IceCubes;
        public List<Cup> Cups;
        public Lemonade Lemonade;

        // constructor (SPAWNER)
        public Inventory()
        {
            Lemons = new List<Lemon>();
            SugarCubes = new List<SugarCube>();
            IceCubes = new List<IceCube>();
            Cups = new List<Cup>();
            AddLemonsToInventory(20);
            AddSugarCubesToInventory(20);
            AddIceCubesToInventory(100);
            AddCupsToInventory(30);
        }

        // member methods (CAN DO)
        public void DisplayCurrentInventory()
        {
            Console.WriteLine($"\nYou currently have:\n {Lemons.Count} lemons,\n" +
                $"{SugarCubes.Count} sugar cubes,\n" +
                $"{IceCubes.Count} ice cubes and\n" +
                $"{Cups.Count} cups\n");
        }
        public void AddLemonsToInventory(int numberOfLemons)
        {
            for(int i = 0; i < numberOfLemons; i++)
            {
                Lemon lemon = new Lemon();
                Lemons.Add(lemon);
            }
        }
        public void UseLemonsFromInventory(int totalLemonsNeeded)
        {

            for (int i = 0; i < totalLemonsNeeded; i++)
            {
                Lemons.Remove(Lemons[0]);

            }
        }

        public void AddSugarCubesToInventory(int numberOfSugarCubesCases)
        {
            int numberOfSugarCubes = numberOfSugarCubesCases * 10;
            for (int i = 0; i < numberOfSugarCubes; i++)
            {
                SugarCube sugarCube = new SugarCube();
                SugarCubes.Add(sugarCube);
            }
        }
        public void UseSugarCubesFromInventory(int totalSugarCubesNeeded)
        {

            for (int i = 0; i < totalSugarCubesNeeded; i++)
            {
                SugarCubes.Remove(SugarCubes[0]);

            }
        }

        public void AddIceCubesToInventory(int numberOfIceCubesCases)
        {
            int numberOfIceCubes = numberOfIceCubesCases * 100;
            for(int i = 0; i < numberOfIceCubes; i++)
            {
                IceCube iceCube = new IceCube();
                IceCubes.Add(iceCube);
            }
        }
         public void UseIceCubesFromInventory(int totalIceCubesNeeded)
        {

            for (int i = 0; i < totalIceCubesNeeded; i++)
            {
                IceCubes.Remove(IceCubes[0]);

            }
        }

        public void AddCupsToInventory(int numberOfCupsCases)
        {
            int numberOfCups = numberOfCupsCases * 50;
            for (int i = 0; i < numberOfCups; i++)
            {
                Cup cup = new Cup();
                Cups.Add(cup);
            }
        }
        public void UseCupsFromInventory(int numberOfCupsSold)
        {

            for (int i = 0; i < numberOfCupsSold; i++)
            {
                Cups.Remove(Cups[0]);
            }
        }


    }
}
