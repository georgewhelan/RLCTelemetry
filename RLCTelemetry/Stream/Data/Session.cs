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
    using RLCTelemetry.Utilities;
    using RLCTelemetry.Settings.Localisation;
    using WebAPI;
    using RLCTelemetry.Stream.Http;
    

    public class Session
    {
        // Session ID
        private int id;
        public int ID
        {
            get { return this.id; }
        }

        // List of laps in this session.
        private List<Lap> laps = new List<Lap>();

        // The current lap in this session.
        public Lap CurrentLap = new Lap();

        // The session Top Speed. Do not use this for laps.
        private TopSpeed topspeed = new TopSpeed();
        public int TopSpeed { get { return this.topspeed.ToInt(); } }

        // The parent.
        private MainWindow parent;

        public Session(MainWindow parent, int sessionid)
        {
            this.parent = parent;
            this.id = sessionid;
            //Console.WriteLine("[Session] Starting new session");
        }

        public void UpdateTopSpeed(float speed, int lap)
        {
            this.topspeed.Parse(speed, lap);

            if (this.topspeed.Speed == speed)
            {
                this.updatetopspeedvalue();
            }
        }

        public void AddLap(Lap lap)
        {
            // This method updates the list of laps. It is called when the lap is finished, and can add a lap to the list.

            // I think it should be looping through this.laps and updating that way, not sure tbh.
            this.laps.Add(lap);

            //this.stream.SubmitLap(lap, this.id);

            this.updatelaps(lap);
            
        }

        public void UpdateLastLapTime(float time)
        {
            string stime = TimeFormatter.FormatFloat(time);
            this.parent.UpdateLastLapLabel(stime);
        }

        public void UpdateLastLapTime(string time)
        {
            this.parent.UpdateLastLapLabel(time);
        }

        private void updatetopspeedvalue()
        {
            switch(this.parent.SpeedUnits)
            {
                case Speed.MPH:
                    this.parent.UpdateTopSpeedLabel(Localisation.ToMPH(this.topspeed.Speed).ToString());
                    break;

                case Speed.KPH:
                    this.parent.UpdateTopSpeedLabel(Localisation.ToKPH(this.topspeed.Speed).ToString());
                    break;
            }
        }

        

        private void updatelaps(Lap lap)
        {
            // Updates the list of laps on the MainWindow.

            float num = lap.LapNumber;
            float sec1 = lap.Sector1;
            float sec2 = lap.Sector2;
            float sec3 = lap.Sector3;
            string time = lap.ToString();

            string result = "Lap " + num + ": Time:" + time;


            this.parent.AddLapToPreviousLaps(result);
        }


    }
}
