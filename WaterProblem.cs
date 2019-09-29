namespace Midterm_Arzola
{
    public class WaterProblem
    {
        #region Properties
        private int _FiveUnitContainer;

        public int FiveUnitContainer
        {
            get { return _FiveUnitContainer; }
        }

        private int _ThreeUnitContainer;

        public int ThreeUnitContainer
        {
            get { return _ThreeUnitContainer; }
        }
        #endregion

        /// <summary>
        /// Empties Five Unit Container
        /// </summary>
        public void EmptyFiveUnitContainer()
        {
            this._FiveUnitContainer = 0;
        }

        /// <summary>
        /// Empties Three Unit Container
        /// </summary>
        public void EmptyThreeUnitContainer()
        {
            this._ThreeUnitContainer = 0;
        }

        public void FillFiveUnitContainer()
        {
            this._FiveUnitContainer = 5;
        }

        public void FillThreeUnitContainer()
        {
            this._ThreeUnitContainer = 3;
        }

        public void PourToFiveUnitContainer()
        {
            var remaining = AddToFiveUnitContainer(this.ThreeUnitContainer);
            this._ThreeUnitContainer = remaining;
        }

        public void PourToThreeUnitContainer()
        {
            var remaining = AddToThreeUnitContainer(this.FiveUnitContainer);
            this._FiveUnitContainer = remaining;
        }

        #region PrivateMethods
        private int AddToFiveUnitContainer(int amt)
        {
            var freeVolume = 5 - this.FiveUnitContainer;
            if (freeVolume >= amt)
            {
                this._FiveUnitContainer += amt;
                return 0;
            }
            else
            {
                var remaining = amt - freeVolume;
                this._FiveUnitContainer += freeVolume;
                return remaining;
            }
        }

        private int AddToThreeUnitContainer(int amt)
        {
            var freeVolume = 3 - this.ThreeUnitContainer;
            if (freeVolume >= amt)
            {
                this._ThreeUnitContainer += amt;
                return 0;
            }
            else
            {
                var remaining = amt - freeVolume;
                this._ThreeUnitContainer += freeVolume;
                return remaining;
            }
        }
        #endregion


    }
}
