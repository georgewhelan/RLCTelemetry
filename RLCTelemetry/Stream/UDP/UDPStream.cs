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

        // Public fields must be read only.
        private float time = 0;
        public float Time { get { return this.time; } }

        private float laptime = 0;
        public float LapTime { get { return this.laptime; } }

        private Lap currentlap = new Lap();
        public Lap CurrentLap { get { return this.currentlap; } }
        //public float CurrentLap { get { return this.currentlap; }}

        private float speed = 0;
        public float Speed { get { return this.speed; } }

        private float previouslaptime = 0;
        public float PreviousLapTime { get { return this.previouslaptime; } }

        private float position = 0;
        public float Position { get { return this.position; } }

        // While loop manager
        public bool Running = false;

        public UDPStream(IPAddress server, int port, MainWindow parent)
        {
            this.parent = parent;
            this.listenPort = port;
            this.ipAddress = server;

            Console.WriteLine("thissing" + parent.ToString());
            
            //this.Start(server, port);

            


            // IM NOT SURE WHY I DID THIS.
            this.keys[1] = "time";
            this.keys[2] = "lapTime";
            this.keys[3] = "lapDistance";
            this.keys[4] = "distance";
            this.keys[5] = "x";
            this.keys[6] = "y";
            this.keys[7] = "z";
            this.keys[8] = "speed";
            this.keys[9] = "worldSpeedX";
            this.keys[10] = "worldSpeedY";
            this.keys[11] = "worldSpeedZ";
            this.keys[12] = "xr";
            this.keys[13] = "roll";
            this.keys[14] = "zr";
            this.keys[15] = "xd";
            this.keys[16] = "pitch";
            this.keys[17] = "zd";
            this.keys[18] = "suspensionPositionRearLeft";
            this.keys[19] = "suspensionPositionRearRight";
            this.keys[20] = "suspensionPositionFrontLeft";
            this.keys[21] = "suspensionPositionFrontRight";

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
            // So this doesn't work. No idea why.
            Console.WriteLine("Off");
            this.Running = false;
        }

        public void Start(Session session)
        {
            this.session = session;
            this.Running = true;

            UdpClient listener = new UdpClient(this.listenPort);
            IPEndPoint groupEP = new IPEndPoint(this.ipAddress, this.listenPort);
            byte[] data;
            try
            {
                // To close this thread off, done must return false at some point.
                while (this.Running)
                {

                    //Console.WriteLine("Waiting for game to broadcast...");
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

                    this.previouslaptime = stream[62];
                    this.speed = stream[7];

                    Console.WriteLine(this.Speed);

                    this.time = stream[0];


                    this.parent.UpdateTopSpeedLabel(this.speed.ToString());

                    //this.currentlap.LapNumber = stream[59];
                    //this.currentlap.LapTime = stream[1];
                    //this.position = stream[39];
                    //this.currentlap.Sector1 = stream[50];
                    //this.currentlap.Sector2 = stream[51];
                    //this.currentlap.CurrentFuel = stream[45];
                    //this.currentlap.Speed = stream[7];




                }
            }
            catch (Exception er)
            {
                Console.WriteLine(er.ToString());
            }
            listener.Close();
        }
    }
     
}
