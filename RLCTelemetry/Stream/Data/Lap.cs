// -----------------------------------------------------------------------
// <copyright file="Lap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Stream.Data
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Lap
    {

        public float LapTime;
        public float LapNumber;
        public float Sector1;
        public float Sector2;
        public float Sector3;
        public float CurrentFuel;
        public float PreviousLapTime;
        public float RacePosition;
        public string LapTimeString;
        
        public Lap()
        {
            // Just give these all a value at the start until changed.
            this.LapTime = 0;
            this.LapNumber = 0;
            this.Sector1 = 0;
            this.Sector2 = 0;
            this.Sector3 = 0;
            this.CurrentFuel = 0;
            this.RacePosition = 1;
            this.LapTimeString = "";
        }
    }
}
