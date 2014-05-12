// -----------------------------------------------------------------------
// <copyright file="Lap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using RLCTelemetry.Utilities;
namespace RLCTelemetry.Stream.Data
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Lap
    {
        private float laptime;
        public float LapTime
        {
            get { return this.laptime; }
            set { this.laptime = value; }
        }

        private int lapnumber;
        public int LapNumber
        { 
            get { return this.lapnumber; }
            set { this.lapnumber = value; }
        }

        private float sector1;
        public float Sector1 { get { return this.sector1; } }

        private float sector2;
        public float Sector2 { get { return this.sector2; } }

        private float sector3;
        public float Sector3 { get { return this.sector3; } }

        private float previouslaptime;
        public float PreviousLapTime { get { return this.previouslaptime; } }

        private int raceposition;
        public int RacePosition 
        {
            get { return this.raceposition; }
            set { this.raceposition = value; }
        }

        // This needs binning. Safely delete this field.
        public string LapTimeString;

        private float topspeed;
        public float TopSpeed
        {
            get { return this.topspeed; }
            set { if (value > this.topspeed) this.topspeed = value; }
        }
        
        public float FuelRemaining { 
            get { return this.fuelremaining; }
            set { this.fuelremaining = value; }
        }
        private float fuelremaining;
        
        public Lap()
        {
            // Just give these all a value at the start until changed - if they are left unset then a url will still be valid.
            this.laptime = 1.111f;
            this.lapnumber = 1;
            this.sector1 = 11.111f;
            this.sector2 = 11.111f;
            this.sector3 = 1;
            this.fuelremaining = 1;
            this.raceposition = 1;
            this.previouslaptime = 1;
            this.topspeed = 1;
        }

        public override string ToString()
        {
            return TimeFormatter.FormatFloat(this.laptime);
        }

        public void UpdateLapNumber(int number)
        {
            this.lapnumber = number;
        }

        public void UpdateSector(int sector, float time)
        {
            switch(sector)
            {
                case 1:
                    this.sector1 = time;
                    break;
                case 2:
                    this.sector2 = time;
                    break;
                case 3:
                    this.sector3 = time;
                    break;
            }
        }

    }
}
