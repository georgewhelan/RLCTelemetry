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
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
            Console.WriteLine("[GUI] Showing authentication settings");
        }

        private void authCancelButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("[GUI] Closing authentication settings");
            this.Close();
        }

        private void authSaveButton_Click(object sender, EventArgs e)
        {
            // Update settings file with the auth code. Hardcoded for the time being.
        }
    }
}
