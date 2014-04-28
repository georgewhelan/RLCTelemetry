// -----------------------------------------------------------------------
// <copyright file="Session.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Stream.Data
{
    using System;
    using System.Collections.Generic;
    using RLCTelemetry.Stream.UDP;
    

    public class Session
    {
        // Session ID
        public int ID;

        // List of laps in this session.
        private List<Lap> laps = new List<Lap>();

        // Current position NOT SURE ABOUT THIS.
        public int Position;

        // The current lap in this session.
        public Lap CurrentLap = new Lap();

        // The previous lap, this gets added to the list of laps.
        //public Lap PreviousLap = new Lap();

        // The session Top Speed.
        private TopSpeed topspeed = new TopSpeed();
        
        public int TopSpeed { get { return this.topspeed.ToInt(); } }

        private MainWindow parent;

        public Session(MainWindow parent)
        {
            this.parent = parent;
        }

        public void UpdateTopSpeed(float speed, int lap)
        {
            this.topspeed.Parse(speed, lap);

            if (this.topspeed.Speed == speed)
            {
                this.updatetopspeedvalue();
            }
        }

        private void updatetopspeedvalue()
        {
            this.parent.UpdateTopSpeedLabel(this.topspeed.ToInt().ToString());

            //;this.Handle.topSpeed.Text = session.TopSpeed.ToString()
        }

        public void AddLap(Lap lap)
        {
            // This method updates the list of laps. It is called when the lap is finished, and can add a lap to the list.

            // I think it should be looping through this.laps and updating that way, not sure tbh.
            this.laps.Add(lap);

            this.updatelaps(lap);
        }

        private void updatelaps(Lap lap)
        {
            // Updates the list of laps on the MainWindow.

            float num = lap.LapNumber;
            float sec1 = lap.Sector1;
            float sec2 = lap.Sector2;
            float sec3 = lap.Sector3;
            float time = lap.LapTime;

            string result = num + ": " + sec1 + " " + sec2 + " " + sec3 + " " + time;


            this.parent.AddLapToPreviousLaps(result);
        }


    }
}
