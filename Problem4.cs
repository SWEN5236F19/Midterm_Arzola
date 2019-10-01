using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Arzola
{
    public class Problem4 : IProblem
    {
        #region Properties
        public bool[] Lockers { get; set; } = new bool[1000];
        public int[] OpenLockerIndices { get; set; }
        public int[] PlayerResponse { get; set; }
        #endregion

        #region Interface Implementation
        /// <summary>
        /// Checks if the values input by user match the indices of the open lockers
        /// </summary>
        /// <returns></returns>
        public bool CheckWin()
        {
            return Enumerable.SequenceEqual(OpenLockerIndices, PlayerResponse);
        }

        /// <summary>
        /// Play Game
        /// </summary>
        /// <returns>Boolean Value indicated game was won</returns>
        public bool Play()
        {
            CalculateIndices();
            bool play = true;
            bool win = false;
            while(play){
                Console.WriteLine("Please enter which lockers numbers were left open from 0-999, seperated by comas");
                Console.WriteLine("E.g. 1,5,9");
                var input = Console.ReadLine();
                if(input.ToLower().Equals("exit")) { break ;}
                
                PlayerResponse = Array.ConvertAll(input.Split(','), int.Parse);
                if(CheckWin()){
                    win = true;
                    play = false;
                    Console.WriteLine("Congratulations you won!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Nope, Please try again");
                }
            }
            return win;
        }
        #endregion

        // Calculates the solution
        private void CalculateIndices()
        {
            var indices = Enumerable.Range(0, 1000).ToArray();
            for (int i = 1; i < 1000; i++)
            {
                if (i == 1)
                {
                    Lockers = Enumerable.Repeat<bool>(true, 1000).ToArray();
                }
                else
                {
                    var evenIndices = Enumerable.Where(indices, x => x % i == 0).ToArray();
                    Array.ForEach(evenIndices, index => Lockers[index] = !Lockers[index]);
                }
            }
            OpenLockerIndices = Enumerable.Where(indices, x => Lockers[x]).ToArray();
        }
    }
}
