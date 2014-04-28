// -----------------------------------------------------------------------
// <copyright file="UDPStream.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Stream.UDP
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Windows.Forms;
    using RLCTelemetry.Stream.Data;
    using RLCTelemetry.Utilities.Factories;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UDPStream
    {
        // Handle on the parent window so it can update it.
        private MainWindow parent;

        // Handle on the session so it can update the session's values.
        private Session session;

        // Need to open a config file, read the port. Not this.
        private int listenPort;
        private IPAddress ipAddress;

        // The 4 byte floats are sent here.
        private Dictionary<int, float> stream = new Dictionary<int, float>();
        private Dictionary<int, string> keys = new Dictionary<int, string>();

        //// Public fields must be read only.
        //private float time = 0;
        //public float Time { get { return this.time; } }

        //private float laptime = 0;
        //public float LapTime { get { return this.laptime; } }

        private Lap currentlap = new Lap();
        public Lap CurrentLap { get { return this.currentlap; } }
        //public float CurrentLap { get { return this.currentlap; }}

        //private float speed = 0;
        //public float Speed { get { return this.speed; } }

        //private float previouslaptime = 0;
        //public float PreviousLapTime { get { return this.previouslaptime; } }

        //private float position = 0;
        //public float Position { get { return this.position; } }

        // While loop manager
        public bool Running = false;

        // The internal lap counter. RESET TO ZERO THIS BETTER BE ZERO.
        private int lapcount = 8;

        private List<bool> sectors = new List<bool>();


        private bool sector1flag = false;
        private bool sector2flag = false;

        private float sector1 = 0;
        private float sector2 = 0;
        private float sector3 = 0;

        public UDPStream(IPAddress server, int port, MainWindow parent)
        {
            this.parent = parent;
            this.listenPort = port;
            this.ipAddress = server;

            this.sectors.Add(false);
            this.sectors.Add(false);
            this.sectors.Add(false);


            //keys = [
            //1'time', 
            //2'lap_time', 
            //3'lap_distance',
            //4//'distance', 
            //5'x',
            //6'y',
            //7'z',
            //8//'speed', 
            //9'world_speed_x', 
            //10'world_speed_y', 
            //11'world_speed_z',
            //12//'xr',
            //13'roll',
            //14'zr',
            //15'xd',
            //16'pitch', 
            //17'zd',
            //18//'suspension_position_rear_left',
            //19//'suspension_position_rear_right',
            //20//'suspension_position_front_left',
            //21//'suspension_position_front_right',
            //22//'suspension_velocity_rear_left',
            //23//'suspension_velocity_rear_right',
            //24//'suspension_velocity_front_left',
            //25//'suspension_velocity_front_right',
            //26//'wheel_speed_back_left',
            //27'wheel_speed_back_right',
            //28//'wheel_speed_front_left',
            //29'wheel_speed_front_right',
            //30//'throttle', 
            //31'steer',
            //32'brake', 
            //33'clutch', 
            //34'gear',
            //35//'lateral_acceleration',
            //36'longitudinal_acceleration',
            //37//'lap_no',
            //38'engine_revs', 
            //39'new_field1',
            //40//'race_position', 
            //41'kers_remaining', 
            //42'kers_recharge', 
            //43'drs_status',
            //44//'difficulty',
            //45'assists', 
            //46'fuel_remaining',
            //47//'session_type', 
            //48'new_field10', 
            //49'sector',
            //50'time_sector1',
            //51'time_sector2',
            //52//'brake_temperature_rear_left',
            //53'brake_temperature_rear_right',
            //54//'brake_temperature_front_left',
            //55'brake_temperature_front_right',
            //56//'new_field18',
            //57'new_field19',
            //58'new_field20', 
            //59'new_field21',
            //60//'completed_laps_in_race',
            //61'total_laps_in_race', 
            //62'track_length', 
            //63'previous_lap_time',
            //64//'new_field_1301', 
            //65'new_field_1302',
            //66'new_field_1303']
        }

        public void Stop()
        {
            Console.WriteLine("Off");
            this.Running = false;
        }

        public void Start(Session session)
        {
            this.session = session;
            this.Running = true;

            Console.WriteLine("Running");

            UdpClient listener = new UdpClient(this.listenPort);
            IPEndPoint groupEP = new IPEndPoint(this.ipAddress, this.listenPort);
            byte[] data;
            try
            {
                // To close this thread off, this.Running must return false at some point.
                while (this.Running)
                {
                    // Check to see if there is data on the stream
                    if (listener.Available > 0)
                    {
                        // and pull it in
                        data = listener.Receive(ref groupEP);
                        //Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());

                        // 66 keys in a packet. 0 - 65.
                        int keys = 65;

                        for (int index = 0; index < keys; index++)
                        {
                            // Making those 4 bytes into a float.
                            float value = System.BitConverter.ToSingle(data, index * 4);

                            // Log it.
                            this.stream[index] = value;

                        }

                        // When we have logged it, bearing in mind this stream is 60 hertz, make a new lap. First lap will be Lap number 1. So in a loop for lapnumber <= total laps
                        // we need to make a new lap every time the lap number changes, all the while logging the data like sector etc for the lap as it goes. When lap number changes, add that lap
                        // to the list of Laps. And make a new lap. Rinse repeat. I think that's how to do it.


                        // Make a new lap when start. Then make a new lap every time lap number changes.
                        // When making a lap, it needs the lap number.
                        // If Sector 1 changes from 0: update the lap record.
                        // ^^ for sector 2.


                        if (this.stream[36] == this.lapcount)
                        {
                            // on this lap yo.

                            // Top speed section.
                            this.session.UpdateTopSpeed(this.stream[7], this.lapcount + 1);


                            // Sector 1 has changed.
                            if (this.stream[49] != 0)
                            {
                                if (this.sector1flag == false)
                                {
                                    this.sector1 = this.stream[49];
                                    this.sector1flag = true;
                                    this.currentlap.Sector1 = this.sector1;
                                    this.Sector(1, this.sector1);
                                }
                                
                                //this.Sector(1, this.stream[49]);
                            }

                            if (this.stream[50] != 0)
                            {
                                if (this.sector2flag == false)
                                {
                                    this.sector2 = this.stream[50];
                                    this.sector2flag = true;
                                    this.currentlap.Sector2 = this.sector2;
                                    this.Sector(2, this.sector2);
                                }
                                //this.Sector(2, this.stream[50]);
                            }
                        }

                        if (this.stream[36] != this.lapcount)
                        {
                            // Crossed the finish line, new lap started.

                            // The previous lap, minus the sector 1 + sector 2 time = sector 3.
                            this.sector3 = stream[62] - (this.sector1 + this.sector2);
                            this.currentlap.Sector3 = this.sector3;

                            // Laptime should be the same as the three sectors.
                            this.currentlap.LapTime = this.stream[62];


                            // Bit of console logging.
                            this.Sector(3, this.sector3);
                            Console.WriteLine("Previous lap: " + stream[62]);


                            this.currentlap.LapNumber = this.lapcount + 1;

                            // Add final values for the lap here.
                            //this.currentlap.CurrentFuel = stream[45];

                            // Add the completed lap to the list of laps in the session.
                            //this.session.Laps.Add(this.currentlap);
                            //this.session.UpdateLaps();
                            this.session.AddLap(this.currentlap);

                            // Reset the currentlap to a brand new lap.
                            this.currentlap = new Lap();
                            this.sectors[0] = false;
                            this.sectors[1] = false;
                            this.sectors[2] = false;
                            this.sector1flag = false;
                            this.sector2flag = false;

                            // Update the lapcount by 1.
                            this.lapcount += 1;


                        }
                        

                        


                       
                        //this.currentlap.LapNumber = stream[37];
                        //this.currentlap.

                        //this.session.UpdateTopSpeed(stream[7], (int)stream[37]);
                        //this.session.CurrentLap =

                        //this.previouslaptime = stream[62];
                        //this.speed = stream[7];

                        //Console.WriteLine(this.Speed);

                        //this.time = stream[0];


                    //this.currentlap.LapNumber = stream[59];
                    //this.currentlap.LapTime = stream[1];
                    //this.position = stream[39];
                    //this.currentlap.Sector1 = stream[50];
                    //this.currentlap.Sector2 = stream[51];
                    //this.currentlap.Speed = stream[7];
                    }
                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.ToString());
            }
            listener.Close();
        }

        private void Sector(int sector, float value)
        {
            if (this.sectors[sector - 1] == false)
            {
                Console.WriteLine("Sector " + sector + ": " + value.ToString());
                this.sectors[sector - 1] = true;
            }

        }
    }
     
}
