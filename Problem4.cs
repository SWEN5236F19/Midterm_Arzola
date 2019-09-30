using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Arzola
{
    public class Problem4 : IProblem
    {
        public bool[] Lockers { get; set; } = new bool[1000];
        public int[] OpenLockerIndices { get; set; }
        public int[] PlayerResponse { get; set; }

        public bool CheckWin()
        {
            return Enumerable.SequenceEqual(OpenLockerIndices, PlayerResponse);
        }

        public bool Play()
        {
            CalculateIndices();
            bool play = false;
            bool win = false;
            while(play){
                Console.WriteLine("Please enter which lockers numbers were left open from 1-1000, seperated by comas");
                Console.WriteLine("E.g. 1,5,9");
                var input = Console.ReadLine();
                if(input.ToLower().Equals("exit")) { break ;}
                
                PlayerResponse = Array.ConvertAll(input.Split(','), int.Parse);
                if(CheckWin()){
                    win = true;
                    play = false;
                    Console.WriteLine("Congratulations you won!");
                }
            }
            return win;
        }

        private void CalculateIndices()
        {
            var indices = Enumerable.Range(1, 1000).ToArray();
            for (int i = 1; i <= 1000; i++)
            {
                if (i == 1)
                {
                    Lockers = Enumerable.Repeat<bool>(true, 1000).ToArray();
                }
                else
                {
                    var evenIndices = Enumerable.Where(indices, x => x + 1 % i == 0).ToArray();
                    Array.ForEach(evenIndices, index => Lockers[index] = !Lockers[index]);
                }
            }
            Lockers[0] = false; //we're ignoring 0
            OpenLockerIndices = Enumerable.Where(indices, x => Lockers[x]).ToArray();
        }
    }
}
