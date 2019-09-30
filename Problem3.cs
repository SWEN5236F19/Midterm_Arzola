using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Arzola
{
    public class Problem3 : IProblem
    {
        private int TwinsAge { get; set; }
        private int OldestAge { get; set; }
        private int HouseNumer { get; set; }

        public bool CheckWin()
        {
            HouseNumer = TwinsAge + TwinsAge + OldestAge;
            return Math.Pow(TwinsAge, 2) * OldestAge == 36;
        }

        public bool Play()
        {
            bool play = true;
            bool win = false;
            while (play)
            {
                Console.WriteLine("What are the twin's age?");
                TwinsAge = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the oldest's age?");
                OldestAge = int.Parse(Console.ReadLine());

                if (CheckWin())
                {
                    Console.WriteLine("Congratulations! You've solved the riddle!");
                    Console.WriteLine("The House Number is: " + HouseNumer);
                    Console.WriteLine();
                    play = false;
                    win = true;
                }
            }
            return win;
        }
    }
}
