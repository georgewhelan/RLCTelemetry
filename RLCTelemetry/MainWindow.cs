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
        
        public MainWindow()
        {


            InitializeComponent();
            this.Show();
        }

        public bool RecordingStream = false;

        private void StreamStart()
        {
            // Check config for settings
            // Configuration config = new Configuration();
            // UDPStream stream = new UDPStream(config.LocalServer, config.LocalPort);

            // Testing purposes only. Read from config in future.
            int port = 20777;
            IPAddress address = new IPAddress(new byte[] { 127, 0, 0, 1 });

            UDPStream stream = new UDPStream(new IPAddress(new byte[] { 127, 0, 0, 1 }), 20777, this);

            //this.topSpeed.Text = this.Session.TopSpeed.ToInt();

            // Main stream up and running.
            
            
            Session session = new Session();


            
            this.updatesessionvalues(session);
            
            //session.CurrentLap = stream.CurrentLap;
        }

        private void StreamBegin()
        {
            
        }

        private void updatesessionvalues(Session session)
        {
            //this.topSpeed.Text = session.TopSpeed.ToString();
            //this.topSpeed.Text = stream.Speed.ToString();

            //Console.WriteLine(stream.Speed.ToString());
            Console.WriteLine(session.TopSpeed.ToString());

            BeginInvoke((MethodInvoker)delegate
            {
                //this.topSpeed.Text = stream.Speed.ToString();
            });  
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void streamControlButton_Click(object sender, EventArgs e)
        {
            if (this.streamControlButton.Text == "Start")
            {

                this.data = new Thread(new ThreadStart(this.StreamStart));
                this.data.Start();
                this.streamControlButton.Text = "Stop";
                this.statusBarStreamingLabel.Text = "Streaming...";
            }
            else
            {
                this.streamControlButton.Text = "Stopped";
                this.RecordingStream = true;
                this.statusBarStreamingLabel.Text = "Stopped streaming LOL IM LYING I HAVEN'T";
                this.data.Abort();
                // STOP THAT FUCKING THREAD
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
