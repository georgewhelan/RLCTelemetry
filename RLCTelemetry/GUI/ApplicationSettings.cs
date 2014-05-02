using RLCTelemetry.Utilities.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLCTelemetry.GUI
{
    public partial class ApplicationSettings : Form
    {
        private F12013Config2 config = new F12013Config2();

        public ApplicationSettings()
        {
            InitializeComponent();
            Console.WriteLine("[GUI] Opening App Settings");

            this.config.ReadConfig();
            this.currentPortTextbox.Text = this.config.Port.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Console.WriteLine("[GUI] Closing App Settings");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // Reset config to 127.0.0.1 and 20777
            if (this.config.Port != 20777)
            {
                config.EditPort(20777);
                this.currentPortTextbox.Text = "20777";
                Console.WriteLine("[Config] Resetting config to default");
            }
            this.portErrorLabel.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Save settings
            int port = 0;
            int.TryParse(this.currentPortTextbox.Text, out port);

            if (port > 0 && port <= 65000)
            {
                Console.WriteLine("[Config] Saving config to user values");
                config.EditPort(port);
                this.currentPortTextbox.Text = port.ToString();
                this.portErrorLabel.Text = "";
                this.Close();
            }
            else
            {
                Console.WriteLine("[Config] Incorrect port entered");
                this.portErrorLabel.Text = "Incorrect port entered.";
                
                // Invalid port provided.
            }
        }

        
    }
}
