using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Arzola
{
    public class Problem2 : IProblem
    {
        #region Properties
        public WaterProblem WaterProblem { get; set; } = new WaterProblem();
        #endregion

        #region Interface Implementation
        public bool CheckWin()
        {
            return (WaterProblem.FiveUnitContainer == 4) ? true : false;
        }

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
                        play = false;
                        break;
                }
                PrintStatus();
                if (CheckWin())
                {
                    Console.WriteLine("Congratulations you won!");
                    play = false;
                    won = true;
                }
            }
            return won;
        }

        public void PrintStatus()
        {
            WaterProblem.PrintStatus("Three Gallon Bucket", "Five Gallon Bucket");
        }
        #endregion

        #region Private Methods
        private void PrintMenu()
        {
            Console.WriteLine("F3 - Fill Three Gallon Bucket");
            Console.WriteLine("F5 - Fill Five Gallon Bucket");
            Console.WriteLine("P3 - Pour Three Gallon Buckets to Five Gallon Bucket");
            Console.WriteLine("P5 - Pour Five Gallon Bucket to Three Gallon Bucket");
            Console.WriteLine("E3 - Empty Three Gallon Bucket");
            Console.WriteLine("E5 - Empty Five Gallon Bucket");
            Console.WriteLine();
        }
        #endregion
    }
}
