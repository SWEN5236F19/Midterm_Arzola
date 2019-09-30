using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Arzola
{
    static class Program
    {
        static int level = 1;

        static Dictionary<string, bool> level1 = new Dictionary<string, bool>()
        {
            {"problem1",  false},
            {"problem2",  false}
        };
        static Dictionary<string, bool> level2 = new Dictionary<string, bool>()
        {
            {"problem3",  false},
            {"problem4",  false}
        };
        static Dictionary<string, bool> level3 = new Dictionary<string, bool>()
        {
            {"problem4",  false},
            {"problem5",  false}
        };

        static void Main(string[] args)
        {
            bool play = true;
            while (play)
            {
                PrintMenu();
                var opt = Console.ReadLine().ToLower();

                switch (opt)
                {
                    case "1":
                        Problem1 prob1 = new Problem1();
                        var completed = prob1.Play();
                        if (completed) { MarkGameCompleted("problem1"); }
                        break;
                    case "2":
                        break;
                    case "3":
                        break;

                    case "exit":
                        play = false;
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Welcome to Astronaut Mind Teasers");
            Console.Write("You are on level - " + level);
            Console.WriteLine("Please Select from the following games: \n");
            if (level == 1)
            {
                Console.WriteLine("1 - A bartender has a three-pint glass and a five-pint glass. A customer " +
                    "walks in and orders four pints of beer. Without a measuring cup but with" +
                    "an unlimited supply of beer how does he get a single pint in either glass ? ");
                Console.WriteLine("2 - Using just a five-gallon bucket and a three-gallon bucket, can you put" +
                    "four gallons of water in the five - gallon bucket ? (Assume that you have" +
                    "an unlimited supply of water and that there are no measurement" +
                    "markings of any kind on the buckets.)");
            }
            else if (level == 2)
            {
                Console.WriteLine("3 - Tom is from the U.S. Census Bureau and greets Mary at her door. " +
                    "They have the following conversation:\n" +
                    "Tom: I need to know how old your three kids are.\n" +
                    "Mary: The product of their ages is 36.\n" +
                    "Tom: I still don't know their ages.\n" +
                    "Mary: The sum of their ages is the same as my house number.\n" +
                    "Tom: I still don't know their ages.\n" +
                    "Mary: The younger two are twins.\n" +
                    "Tom: Now I know their ages!Thanks!" +
                     "How old are Mary's kids and what is Mary's house number ?\n");
            }
            else if (level == 3)
            {

            }
            Console.WriteLine("Exit - To Close Game");
        }

        private static void MarkGameCompleted(string problem)
        {
            if (level == 1)
            {
                level1[problem] = true;
                var level1Completed = Array.TrueForAll<bool>(level1.Values.ToArray(), val => val);
                if (level1Completed) { level = 2; }
            }
            if (level == 2)
            {
                level2[problem] = true;
                var level2Completed = Array.TrueForAll<bool>(level2.Values.ToArray(), val => val);
                if (level2Completed) { level = 3; }

            }
            if (level == 3)
            {
                level3[problem] = true;
                var level3Completed = Array.TrueForAll<bool>(level3.Values.ToArray(), val => val);
                Console.WriteLine("Congratulations, you've mastered the game!");
            }
        }

    }
}
