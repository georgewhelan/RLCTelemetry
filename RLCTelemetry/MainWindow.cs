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
using RLCTelemetry.GUI;
using RLCTelemetry.Settings.Localisation;

namespace RLCTelemetry
{
    public partial class MainWindow : Form
    {
        private Thread data;
        private UDPStream stream;

        // The localisation for speed units.
        private Speed speedunits = Speed.MPH;
        public Speed SpeedUnits { get { return this.speedunits; } }
        
        public MainWindow()
        {
            InitializeComponent();
            this.Show();

            int port = 20777;
            IPAddress address = new IPAddress(new byte[] { 127, 0, 0, 1 });
            this.stream = new UDPStream(address, port, this);

            
            
        }

        private void StreamStart()
        {
            // Check config for settings. Example:
            // Configuration config = new Configuration();
            // UDPStream stream = new UDPStream(config.LocalServer, config.LocalPort);


            // When start is pushed, we get a new session.
            Session session = new Session(this);
            // Not sure why, having the data start here it means we can close the app before starting streaming.
            
            this.stream.Start(session);
            
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

        public void UpdateLastLapLabel(string time)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                this.lastLapTime.Text = time;
            });  
        }

        public void AddLapToPreviousLaps(string lap)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                this.previousLaps.Items.Add(lap);
            });
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void mPHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mPHToolStripMenuItem.Checked = true;
            this.kPHToolStripMenuItem.Checked = false;
            this.speedunits = Speed.MPH;
            this.speedunitslabel.Text = "MPH";
        }

        private void kPHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mPHToolStripMenuItem.Checked = false;
            this.kPHToolStripMenuItem.Checked = true;
            this.speedunits = Speed.KPH;
            this.speedunitslabel.Text = "k/ph";
        }


        // this.Closing or something, make the data control bool false here so it shuts the thread off when closing this form.
    }
}
