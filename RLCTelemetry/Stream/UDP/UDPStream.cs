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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UDPStream
    {


        // Need to open a config file, read the port. Not this.
        private int listenPort;
        private IPAddress ipAddress;

        // The 4 byte floats are sent here.
        private Dictionary<int, float> stream = new Dictionary<int, float>();

        public UDPStream(IPAddress server, int port)
        {
            this.Stream(server, port);
        }

        public void Stream(IPAddress server, int port)
        {
            this.listenPort = port;
            this.ipAddress = server;


            bool done = false;
            UdpClient listener = new UdpClient(this.listenPort);
            IPEndPoint groupEP = new IPEndPoint(this.ipAddress, this.listenPort);
            byte[] data;
            try
            {
                // To close this thread off, done must return true at some point.
                while (!done)
                {

                    // In here, we need to put all the data into the array.


                    Console.WriteLine("Waiting for broadcast");
                    data = listener.Receive(ref groupEP);
                    Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());

                    // 66 floats.
                    int keys = 65;

                    for (int index = 0; index < keys; index++)
                    {
                        float value = System.BitConverter.ToSingle(data, index * 4);

                        this.stream[index] = value;

                    }
                    Console.WriteLine(stream[7]);


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
