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
using RLCTelemetry.Utilities.Configuration;
using RLCTelemetry.Utilities.Authentication;
using RLCTelemetry.Stream.Http;

namespace RLCTelemetry
{
    public partial class MainWindow : Form
    {
        private Thread data;
        private UDPStream stream;

        // The localisation for speed units.
        private Speed speedunits = Speed.MPH;
        public Speed SpeedUnits { get { return this.speedunits; } }

        public List<string> Drivers;
        private List<string> drivers;

        private LoadingForm loading = new LoadingForm();

        public MainWindow()
        {
            InitializeComponent();

            this.Load += MainWindow_Load;

            // Show loading form rather than main GUI.
            Console.WriteLine("[GUI] Showing loading form");
            this.loading.Show();
            // Force the application to render the loading form.
            Application.DoEvents();
        }

        public void UpdateDriverLabel(string name)
        {
            // This needs to actually recheck the auth token.
            this.driverWelcomeLabel.Text = "Welcome back, " + name;
            this.streamControlButton.Enabled = true;
            this.resetsessionbutton.Enabled = true;
            this.savelogbutton.Enabled = true;
        }

        public void UpdateAnonDriverLabel()
        {
            this.driverWelcomeLabel.Text = "Hello new user, please link your account";
            this.streamControlButton.Enabled = false;
            this.resetsessionbutton.Enabled = true;
            this.savelogbutton.Enabled = false;
        }

        public void MainWindow_Load(object sender, EventArgs e)
        {
            F12013Config2 config = new F12013Config2();
            config.ReadConfig();

            Authenticator auth = new Authenticator();

            // New thread needed, or a loading screen.
            if (auth.ReadKey() == true)
            {
                // key has been found. get drivers with that key.
                if (auth.Key != "")
                {
                    this.drivers = auth.GetDriverList();

                    if (this.drivers[0].ToString() != "")
                    {
                        this.UpdateDriverLabel(this.drivers[0].ToString());
                    }
                    else
                    {
                        // No driver name returned.
                        //this.UpdateAnonDriverLabel();
                    }
                }
            }
            else
            {
                // Failed to read auth key.
            }

            if (config.Safe == true)
            {
                this.stream = new UDPStream(config.Server, config.Port, this);
            }
            else
            {
                // Unable to succeed in reading the values from the config file.
            }

            Console.WriteLine("[GUI] Showing main window");
            this.loading.Hide();
            this.Show();

        }

        private void StreamStart()
        {
            // Everything here needs to come from the reset button.

            // When start is pushed, we get a new session.
            //Session session = new Session(this);
            // Not sure why, having the data start here it means we can close the app before starting streaming.
            //this.stream.Start(session);
            
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
            //AboutBoxForm about = new AboutBoxForm();
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
            this.speedunitslabel.Text = "KPH";
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationSettings settings = new ApplicationSettings();
            settings.Show();
        }

        private void authenticationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authentication auth = new Authentication(this);
            auth.Show();
        }

        private void resetsessionbutton_Click(object sender, EventArgs e)
        {
            // Just using this button right now cos it isn't used. All of this needs to go into the Start button.
            // TODO: wire this up.
            WebsiteStream stream = new WebsiteStream();
            int sessionid = stream.NewSession("CarltonLassiter", "4651.133", "177.0", "73", "e5ada1899f82b80bd0a34b8f113f10dfd2afbefb85e8fd884afa31b2a3975497");

            Session session = new Session(this, sessionid);
            this.stream.Start(session);

            Console.WriteLine(sessionid);
        }


        // this.Closing or something, make the data control bool false here so it shuts the thread off when closing this form.
    }
}
