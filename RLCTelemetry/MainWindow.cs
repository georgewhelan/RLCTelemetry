using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using RLCTelemetry.Stream.UDP;
using System.Threading;

namespace RLCTelemetry
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Show();

            

            // Main data thread.
            new Thread(new ThreadStart(this.StreamStart)).Start();



        }

        private void StreamStart()
        {
            // Check config for settings
            // Configuration config = new Configuration();
            // UDPStream stream = new UDPStream(config.LocalServer, config.LocalPort);

            // Testing purposes only. Read from config in future.
            
            int port = 20777;
            IPAddress address = new IPAddress(new byte[] { 127, 0, 0, 1 });


            // Main stream up and running.
            UDPStream stream = new UDPStream(address, port);
        }
    }
}
