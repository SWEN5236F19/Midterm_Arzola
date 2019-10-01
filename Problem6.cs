using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Arzola
{
    public class Problem6 : IProblem
    {
        private Dictionary<char, Stack<int>> Pegs = new Dictionary<char, Stack<int>>()
        {
            { 'a', new Stack<int>(new int[]{3,2,1 }) },
            { 'b', new Stack<int>() },
            { 'c', new Stack<int>() }
        };

        public bool CheckWin()
        {
            var goalStack = new Stack<int>(new int[] { 3, 2, 1 });
            return (Enumerable.SequenceEqual(goalStack.ToArray(), Pegs['b'].ToArray()) ||
                Enumerable.SequenceEqual(goalStack.ToArray(), Pegs['c'].ToArray())) ;
        }

        public bool Play()
        {
            bool win = false;
            bool play = true;

            while (play)
            {
                PrintMenu();

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TowersOfHanoi('a', 'b');
                        break;
                    case "2":
                        TowersOfHanoi('a', 'c');
                        break;
                    case "3":
                        TowersOfHanoi('b', 'a');
                        break;
                    case "4":
                        TowersOfHanoi('b', 'c');
                        break;
                    case "5":
                        TowersOfHanoi('c', 'a');
                        break;
                    case "6":
                        TowersOfHanoi('c', 'b');
                        break;
                    case "exit":
                        play = false;
                        break;
                }

                PrintStatus();
                if (CheckWin())
                {
                    Console.WriteLine("Congratulations you won!");
                    Console.WriteLine();
                    win = true;
                    play = false;
                }
            }
            return win;
        }

        private void PrintStatus()
        {
            if (Pegs['a'].Count > 0) { Console.WriteLine("Peg A: " + string.Join(",", Pegs['a'].Reverse())); }
            else { Console.WriteLine("Peg A: Empty"); }
            if (Pegs['b'].Count > 0) { Console.WriteLine("Peg B: " + string.Join(",", Pegs['b'].Reverse())); }
            else { Console.WriteLine("Peg B: Empty"); }
            if (Pegs['c'].Count > 0) { Console.WriteLine("Peg C: " + string.Join(",", Pegs['c'].Reverse())); }
            else { Console.WriteLine("Peg C: Empty"); }
        }

        private void TowersOfHanoi(char startPeg, char endPeg)
        {
            if (Pegs[startPeg].Count > 0)
            {
                var disk = Pegs[startPeg].Peek();
                if(Pegs[endPeg].Count > 0 && Pegs[endPeg].Peek() < disk)
                {
                    Console.WriteLine("Disk on Peg: " + endPeg + " is smaller than " + disk);
                }
                else
                {
                    Pegs[endPeg].Push(Pegs[startPeg].Pop());
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("1 - Move A to B");
            Console.WriteLine("2 - Move A to C");
            Console.WriteLine("3 - Move B to A");
            Console.WriteLine("4 - Move B to C");
            Console.WriteLine("5 - Move C to A");
            Console.WriteLine("6 - Move C to B");
        }
    }
}
