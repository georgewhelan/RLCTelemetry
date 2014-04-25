// -----------------------------------------------------------------------
// <copyright file="Lap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace F1Data.Data
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Lap
    {

        public int LapTime;
        public int LapNumber;
        public int Sector1;
        public int Sector2;
        public int Position;
        public int TopSpeed;
        public int CurrentFuel;
        //self.packets = list()
        public Lap()
        {
            // Just give these all a value until changed.
            this.LapTime = 0;
            this.LapNumber = 0;
            this.Sector1 = 0;
            this.Sector2 = 0;
            this.Position = 1;
            this.TopSpeed = 1;
            this.CurrentFuel = 0;
        }
    }
}
