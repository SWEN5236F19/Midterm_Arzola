using Midterm_Arzola;
using System;

public class Problem5 : IProblem
{
    #region Properties
    private WaterProblem WaterProblem { get; set; } = new WaterProblem();
    private int Moves { get; set; }
    #endregion

    #region Interface Implementation
    /// <summary>
    /// Checks if there are 4 gallons in one bucket and also if user hasn't exceeded the moves
    /// </summary>
    /// <returns></returns>
    public bool CheckWin()
    {
        var fourGallonsOneBucket = (WaterProblem.FiveUnitContainer == 4) ? true : false;
        var numMovesLessThanFive = (Moves < 10) ? true : false;
        return (fourGallonsOneBucket && numMovesLessThanFive);
    }

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
                    Moves++;
                    break;
                case "f5":
                    WaterProblem.FillFiveUnitContainer();
                    Moves++;
                    break;
                case "p3":
                    WaterProblem.PourToFiveUnitContainer();
                    Moves++;
                    break;
                case "p5":
                    WaterProblem.PourToThreeUnitContainer();
                    Moves++;
                    break;
                case "e3":
                    WaterProblem.EmptyThreeUnitContainer();
                    Moves++;
                    break;
                case "e5":
                    WaterProblem.EmptyFiveUnitContainer();
                    Moves++;
                    break;
                case "exit":
                    play = false;
                    break;
            }
            PrintStatus();
            if (CheckWin())
            {
                play = false;
                won = true;
                Console.WriteLine("Congratulations you won!");
                Console.WriteLine();
            }
        }
        return won;
    }

    #endregion

    #region Private Methods
    private void PrintStatus()
    {
        WaterProblem.PrintStatus("Three Gallon Bucket", "Five Gallon Bucket");
        Console.WriteLine("Moves: " + Moves);
    }

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
