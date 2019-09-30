using System;

namespace Midterm_Arzola
{
    public class WaterProblem
    {
        #region Properties
        public int FiveUnitContainer { get; set; }

        public int ThreeUnitContainer { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Empties Five Unit Container
        /// </summary>
        public void EmptyFiveUnitContainer()
        {
            this.FiveUnitContainer = 0;
        }

        /// <summary>
        /// Empties Three Unit Container
        /// </summary>
        public void EmptyThreeUnitContainer()
        {
            this.ThreeUnitContainer = 0;
        }

        /// <summary>
        /// Fills the Five Unit Container to the top
        /// </summary>
        public void FillFiveUnitContainer()
        {
            this.FiveUnitContainer = 5;
        }

        /// <summary>
        /// Fills the three unit container to the top
        /// </summary>
        public void FillThreeUnitContainer()
        {
            this.ThreeUnitContainer = 3;
        }

        /// <summary>
        /// Pours volume from ThreeUnitContainer to FiveUnitContainer and sets remaining amount in ThreeUnitContainer
        /// </summary>
        public void PourToFiveUnitContainer()
        {
            var remaining = AddToFiveUnitContainer(this.ThreeUnitContainer);
            this.ThreeUnitContainer = remaining;
        }

        /// <summary>
        /// Pours volume from FiveUnitContainer to ThreeUnitContainer and sets remaining amount in FiveUnitContainer
        /// </summary>
        public void PourToThreeUnitContainer()
        {
            var remaining = AddToThreeUnitContainer(this.FiveUnitContainer);
            this.FiveUnitContainer = remaining;
        }

        /// <summary>
        /// Prints the current status of the two containers
        /// </summary>
        /// <param name="labelThreeUnit"></param>
        /// <param name="labelFiveUnit"></param>
        public void PrintStatus(string labelThreeUnit, string labelFiveUnit)
        {
            Console.Write(labelThreeUnit + ": " + this.ThreeUnitContainer + " | ");
            Console.WriteLine(labelFiveUnit + ": " + this.FiveUnitContainer);
        }
        #endregion

        #region PrivateMethods
        //Adds given amount to FiveUnitContainer and returns remaining amount
        private int AddToFiveUnitContainer(int amt)
        {
            var freeVolume = 5 - this.FiveUnitContainer;
            if (freeVolume >= amt)
            {
                this.FiveUnitContainer += amt;
                return 0;
            }
            else
            {
                var remaining = amt - freeVolume;
                this.FiveUnitContainer += freeVolume;
                return remaining;
            }
        }

        // Adds given amount to ThreeUnitContainer and returns remaining amt
        private int AddToThreeUnitContainer(int amt)
        {
            var freeVolume = 3 - this.ThreeUnitContainer;
            if (freeVolume >= amt)
            {
                this.ThreeUnitContainer += amt;
                return 0;
            }
            else
            {
                var remaining = amt - freeVolume;
                this.ThreeUnitContainer += freeVolume;
                return remaining;
            }
        }
        #endregion
    }
}
