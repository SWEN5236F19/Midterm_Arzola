using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Arzola
{
    public class Problem1 : IProblem
    {
        #region Properties
        private int[] _FourPints = new int[4];

        public int[] FourPints
        {
            get { return _FourPints; }
        }

        public WaterProblem WaterProblem { get; set; } = new WaterProblem();
        #endregion

        /// <summary>
        /// WaterProblem Extenstion Method to Pour ThreeUnitContainer in Custom Container
        /// </summary>
        /// <param name="waterProblem">parent object</param>
        /// <param name="index">glass index</param>
        public void PourThreePintToFourPintGlass(int index)
        {
            if(index < FourPints.Length)
            {
                var remaining = AddToFourPintGlass(index, WaterProblem.ThreeUnitContainer);
                WaterProblem.ThreeUnitContainer = remaining;
            }
        }

        /// <summary>
        /// WaterProblem Extenstion Method to Pour FiveUnitContainer in Custom Container
        /// </summary>
        /// <param name="waterProblem">parent obejct</param>
        /// <param name="index">glass index</param>
        public void PourFivePintToFourPintGlass(int index)
        {
            if (index < this.FourPints.Length)
            {
                var remaining = AddToFourPintGlass(index, WaterProblem.FiveUnitContainer);
                WaterProblem.FiveUnitContainer = remaining;
            }
        }

        #region Interface Implementation
        /// <summary>
        /// Play Game
        /// </summary>
        /// <returns>Boolean Value indicated game was won</returns>
        public bool Play()
        {
            var play = true;
            bool won = false;
            while (play)
            {
                PrintMenu();

                var opt = Console.ReadLine().ToLower();

                switch (opt)
                {
                    case "f3":
                        WaterProblem.FillThreeUnitContainer();
                        break;
                    case "f5":
                        WaterProblem.FillFiveUnitContainer();
                        break;
                    case "p3":
                        WaterProblem.PourToFiveUnitContainer();
                        break;
                    case "p5":
                        WaterProblem.PourToThreeUnitContainer();
                        break;
                    case "e3":
                        WaterProblem.EmptyThreeUnitContainer();
                        break;
                    case "e5":
                        WaterProblem.EmptyFiveUnitContainer();
                        break;
                    case "p32g":
                        int index = GetGlassNumber();
                        PourThreePintToFourPintGlass(index);
                        break;
                    case "p52g":
                        int glassNum = GetGlassNumber();
                        PourFivePintToFourPintGlass(glassNum);
                        break;
                    case "exit":
                    case "q":
                        play = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option try again");
                        break;
                }

                PrintStatus();
                PrintGlassesStatus();

                if (CheckWin())
                {
                    Console.WriteLine("Congratulations you won!");
                    play = false;
                    won = true;
                }
            }
            return won;
        }

        /// <summary>
        /// Utilizes funcional programming to determine if all glasses have exactly one pint
        /// </summary>
        /// <returns></returns>
        public bool CheckWin()
        {
            var allOne = Array.TrueForAll(FourPints, val => val.Equals(1));
            return allOne;
        }

        /// <summary>
        /// Prints Glass Status
        /// </summary>
        public void PrintStatus()
        {
            Console.WriteLine("Bartender:");
            WaterProblem.PrintStatus("Three Pint Glass", "Five Pint Glass");
        }
        #endregion

        #region Private Methods


        //Adds given amount to given glass index and returns remaining amount
        private int AddToFourPintGlass(int index, int amount)
        {
            var freeVolume = 4 - FourPints[index];
            int remaining = 0;
            if (freeVolume >= amount)
            {
                FourPints[index] += amount;
                remaining = 0;
            }
            else
            {
                remaining = amount - freeVolume;
                FourPints[index] += freeVolume;
            }
            return remaining;
        }

        // Get Glass Index
        public int GetGlassNumber()
        {
            Console.WriteLine("Which of the Four Glasses would you like to pour to? (1-4)");
            int glass = -1;
            int.TryParse(Console.ReadLine(), out glass);
            if (glass > -1) { glass -= 1; }
            return glass;
        }

        private void PrintMenu()
        {
            Console.WriteLine("F3 - Fill Three Pint Glass");
            Console.WriteLine("F5 - Fill Five Pint Glass");
            Console.WriteLine("P3 - Pour Three Pint Glass to Five Pint Glass");
            Console.WriteLine("P5 - Pour Five Pint Glass to Three Pint Glass");
            Console.WriteLine("E3 - Empty Three Pint Glass");
            Console.WriteLine("E5 - Empty Five Pint Glass");
            Console.WriteLine("P32G - Pour to Three Pint Glass to One of the Four Pint Glasses");
            Console.WriteLine("P52G - Pour to Five Pint Glass to One of the Four Pint Glasses");
            Console.WriteLine();
        }

        private void PrintGlassesStatus()
        {
            Console.WriteLine("Glasses:");
            Console.Write("Glass 1: " + FourPints[0] + " pints | ");
            Console.Write("Glass 2: " + FourPints[1] + " pints | ");
            Console.Write("Glass 3: " + FourPints[2] + " pints | ");
            Console.Write("Glass 4: " + FourPints[3] + " pints\n");
            Console.WriteLine();
        }
        #endregion
    }
}
