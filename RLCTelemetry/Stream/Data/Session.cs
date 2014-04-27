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
        public List<Lap> Laps = new List<Lap>();

        // Current position
        public int Position;

        // The current lap in this session.
        public Lap CurrentLap = new Lap();

        // The previous lap, this gets added to the list of laps.
        public Lap PreviousLap = new Lap();

        // The session Top Speed.
        private TopSpeed topspeed = new TopSpeed();
        
        public int TopSpeed { get { return this.topspeed.ToInt(); } }

        private MainWindow parent;

        public Session(MainWindow parent)
        {
            this.parent = parent;



            // Make connection with website.
            // Get a session ID.

            // SO as the laps are completed, the lap gets added to the list of laps.
            //this.Laps.Add(lap);

            //this.topspeed.Parse(stream.Speed);


            //stream.Handle.

            


        }

        public void UpdateTopSpeed(float speed, int lap)
        {
            this.topspeed.Parse(speed, lap);
        }

        private void updatesessionvalues()
        {
            this.parent.UpdateTopSpeedLabel(this.topspeed.ToString());

            //;this.Handle.topSpeed.Text = session.TopSpeed.ToString()
        }


    }
}
