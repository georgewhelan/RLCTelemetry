﻿// -----------------------------------------------------------------------
// <copyright file="Session.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Stream.Data
{
    using System;
    using System.Collections.Generic;
    using F1Data.Data;
    using RLCTelemetry.Stream.UDP;
    

    public class Session
    {
        // Session ID
        public int ID;

        // List of laps in this session.
        public List<Lap> Laps = new List<Lap>();

        // Current position
        public int Position;

        // The session Top Speed.
        private TopSpeed topspeed = new TopSpeed();
        
        public int TopSpeed { get { return this.topspeed.ToInt(); } }

        public Session()
        {
            // Make connection with website.
            // Get a session ID.

            // SO as the laps are completed, the lap gets added to the list of laps.
            //this.Laps.Add(lap);

            //this.topspeed.Parse(stream.Speed);

            Console.WriteLine(this.TopSpeed);

            //stream.Handle.

            


        }

        private void updatesessionvalues(Session session)
        {
            //;this.Handle.topSpeed.Text = session.TopSpeed.ToString()
        }


    }
}