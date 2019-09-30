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

        public bool CheckWin()
        {
            throw new NotImplementedException();
        }

        public bool Play()
        {
            CalculateIndices();
            var openLockers = Enumerable.Where(Lockers, x => x == true);
            return true;
        }

        private void CalculateIndices()
        {
            var indices = Enumerable.Range(0, 1000).ToArray();
            for (int i = 1; i <= 1000; i++)
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
        }
    }
}
