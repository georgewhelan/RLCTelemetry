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
using RLCTelemetry.Stream.Data;

namespace RLCTelemetry
{
    public partial class MainWindow : Form
    {
        private Thread data;
        private UDPStream stream;
        
        public MainWindow()
        {
            InitializeComponent();
            this.Show();

            int port = 20777;
            IPAddress address = new IPAddress(new byte[] { 127, 0, 0, 1 });
            this.stream = new UDPStream(address, port, this);

            this.data = new Thread(new ThreadStart(this.StreamStart));
            this.data.Start();
        }

        private void StreamStart()
        {
            // Check config for settings
            // Configuration config = new Configuration();
            // UDPStream stream = new UDPStream(config.LocalServer, config.LocalPort);

            // Testing purposes only. Read from config in future.

            //this.topSpeed.Text = this.Session.TopSpeed.ToInt();

            this.stream.Start();
            

            
            


            //Session session = new Session();
            
            //session.CurrentLap = stream.CurrentLap;
        }

       

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void streamControlButton_Click(object sender, EventArgs e)
        {
            if (this.streamControlButton.Text == "Start")
            {

                //this.stream.Running = true;
                
                this.streamControlButton.Text = "Stop";
                this.statusBarStreamingLabel.Text = "Streaming...";
            }
            else
            {
                this.streamControlButton.Text = "Stopped";
                this.stream.Stop();
                this.statusBarStreamingLabel.Text = "Stopped streaming";
            }
        }

        public void UpdateTopSpeedLabel(string topspeed)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                this.topSpeed.Text = topspeed;
            });  
            
        }
    }
}
