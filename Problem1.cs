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
        public bool ThreePintGlassOnePint { get; set; }
        public bool FivePintGlassOnePint { get; set; }

        public WaterProblem WaterProblem { get; set; } = new WaterProblem();
        #endregion

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
                    case "exit":
                    case "q":
                        play = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option try again");
                        break;
                }

                PrintStatus();
                CheckVolumes();

                if (CheckWin())
                {
                    Console.WriteLine("Congratulations you won!");
                    Console.WriteLine("");
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
            return (ThreePintGlassOnePint && FivePintGlassOnePint);
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
        // Method to check if 1 pint has been in either glass
        private void CheckVolumes()
        {
            if (!ThreePintGlassOnePint) { ThreePintGlassOnePint = (WaterProblem.ThreeUnitContainer == 1) ? true : false; }
            if (!FivePintGlassOnePint) { FivePintGlassOnePint = (WaterProblem.FiveUnitContainer == 1) ? true : false; }
        }

        // Get Glass Index
        private void PrintMenu()
        {
            Console.WriteLine("F3 - Fill Three Pint Glass");
            Console.WriteLine("F5 - Fill Five Pint Glass");
            Console.WriteLine("P3 - Pour Three Pint Glass to Five Pint Glass");
            Console.WriteLine("P5 - Pour Five Pint Glass to Three Pint Glass");
            Console.WriteLine("E3 - Empty Three Pint Glass");
            Console.WriteLine("E5 - Empty Five Pint Glass");
            Console.WriteLine();
        }
        #endregion
    }
}
