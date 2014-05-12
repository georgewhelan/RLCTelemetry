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
    using RLCTelemetry.Utilities;
using RLCTelemetry.Stream.Http;

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
        private Dictionary<string, int> keys = new Dictionary<string, int>();

        //// Public fields must be read only.
        private Lap currentlap = new Lap();
        public Lap CurrentLap { get { return this.currentlap; } }

        // While loop manager
        public bool Running = false;

        // The internal lap counter. RESET TO ZERO IF YOU CHANGE IT.
        private int lapcount = 0;

        private List<bool> sectors = new List<bool>();

        // Used so the app isn't updating the sectors 60/sec.
        private bool sector1flag = false;
        private bool sector2flag = false;

        // The sector times.
        private float sector1 = 0;
        private float sector2 = 0;
        private float sector3 = 0;

        private WebsiteStream rlcwebsite;

        public UDPStream(IPAddress server, int port, MainWindow parent)
        {
            this.rlcwebsite = new WebsiteStream();

            this.parent = parent;
            this.listenPort = port;
            this.ipAddress = server;

            this.sectors.Add(false);
            this.sectors.Add(false);
            this.sectors.Add(false);


            // Todo, make these
            keys.Add("time", 0);
            keys.Add("lap_time", 1);
            keys.Add("lap_distance", 2);
            keys.Add("distance", 3);
            keys.Add("x", 4);
            keys.Add("y", 5);
            keys.Add("z", 6);
            keys.Add("speed", 7);
            keys.Add("world_speed_x", 8);
            keys.Add("world_speed_y", 9);
            keys.Add("world_speed_z", 10);
            keys.Add("xr", 11);
            keys.Add("roll", 12);
            keys.Add("zr", 13);
            keys.Add("xd", 14);
            keys.Add("pitch", 15);
            keys.Add("zd", 16);
            keys.Add("suspension_position_rear_left", 17);
            keys.Add("suspension_position_rear_right", 18);
            keys.Add("suspension_position_front_left", 19);
            keys.Add("suspension_position_front_right", 20);
            keys.Add("suspension_velocity_rear_left", 21);
            keys.Add("suspension_velocity_rear_right", 22);
            keys.Add("suspension_velocity_front_left", 23);
            keys.Add("suspension_velocity_front_right", 24);
            keys.Add("wheel_speed_back_left", 25);
            keys.Add("wheel_speed_back_right", 26);
            keys.Add("wheel_speed_front_left", 27);
            keys.Add("wheel_speed_front_right", 28);
            keys.Add("throttle", 29);
            keys.Add("steer", 30);
            keys.Add("brake", 31);
            keys.Add("clutch", 32);
            keys.Add("gear", 33);
            keys.Add("lateral_acceleration", 34);
            keys.Add("longitudinal_acceleration", 35);
            keys.Add("lap_no", 36);
            keys.Add("engine_revs", 37);
            keys.Add("new_field1", 38);
            keys.Add("race_position", 39);
            keys.Add("kers_remaining", 40);
            keys.Add("kers_recharge", 41);
            keys.Add("drs_status", 42);
            keys.Add("difficulty", 43);
            keys.Add("assists", 44);
            keys.Add("fuel_remaining", 45);
            keys.Add("session_type", 46);
            keys.Add("new_field10", 47);
            keys.Add("sector", 48);
            keys.Add("time_sector1", 49);
            keys.Add("time_sector2", 50);
            keys.Add("brake_temperature_rear_left", 51);
            keys.Add("brake_temperature_rear_right", 52);
            keys.Add("brake_temperature_front_left", 53);
            keys.Add("brake_temperature_front_right", 54);
            keys.Add("new_field18", 55);
            keys.Add("new_field19", 56);
            keys.Add("new_field20", 57);
            keys.Add("new_field21", 58);
            keys.Add("completed_laps_in_race", 59);
            keys.Add("total_laps_in_race", 60);
            keys.Add("track_length", 61);
            keys.Add("previous_lap_time", 62);
            keys.Add("new_field_1301", 63);
            keys.Add("new_field_1302", 64);
            keys.Add("new_field_1303", 65);

            //Console.WriteLine("[Stream] Starting new stream");

        }

        public void Stop()
        {
            //Console.WriteLine("[Stream] Stream turned off");
            this.Running = false;
        }

        public void Start(Session session)
        {
            this.session = session;
            this.Running = true;

            //Console.WriteLine("[Stream] Stream is running");

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

                        if (this.stream[36] == this.lapcount)
                        {
                            // on this lap yo.

                            // Top speed section.
                            this.session.UpdateTopSpeed(this.stream[7], this.lapcount + 1);
                            this.currentlap.TopSpeed = this.stream[7];


                            // Sector 1 has changed.
                            if (this.stream[49] != 0)
                            {
                                if (this.sector1flag == false)
                                {
                                    this.sector1 = this.stream[49];
                                    this.sector1flag = true;
                                    this.currentlap.UpdateSector(1, this.sector1);
                                    this.Sector(1, this.sector1);
                                }
                                
                            }

                            // Sector 2 has changed.
                            if (this.stream[50] != 0)
                            {
                                if (this.sector2flag == false)
                                {
                                    this.sector2 = this.stream[50];
                                    this.sector2flag = true;
                                    this.currentlap.UpdateSector(2, this.sector2);
                                    this.Sector(2, this.sector2);
                                }
                            }
                        }


                        // Crossed the finish line, new lap started.
                        if (this.stream[36] != this.lapcount)
                        {
                            

                            // The previous lap, minus the sector 1 + sector 2 time = sector 3.
                            this.sector3 = stream[62] - (this.sector1 + this.sector2);
                            this.currentlap.UpdateSector(3, this.sector3);

                            // Laptime should be the same as the three sectors.
                            // Limit this to 3 dp.
                            this.currentlap.LapTime = this.stream[62];

                            // Safely delete this property.
                            //this.currentlap.LapTimeString = TimeFormatter.FormatFloat(this.stream[62]);

                            this.currentlap.FuelRemaining = this.stream[45];
                            this.currentlap.RacePosition = (int)this.stream[39];

                            // Bit of console logging.
                            this.Sector(3, this.sector3);
                            Console.WriteLine("[Stream] Previous lap: " + this.currentlap.LapTime);

                            this.session.UpdateLastLapTime(this.currentlap.LapTime);

                            this.currentlap.UpdateLapNumber(this.lapcount + 1);

                            // Add the completed lap to the list of laps in the session and send it to the website.
                            this.session.AddLap(this.currentlap);
                            // This can actually go inside the AddLap method.
                            this.rlcwebsite.SubmitLap(this.currentlap, this.session.ID);

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
                Console.WriteLine("[Stream] Sector " + sector + ": " + value.ToString());
                this.sectors[sector - 1] = true;
            }

        }
    }
     
}
