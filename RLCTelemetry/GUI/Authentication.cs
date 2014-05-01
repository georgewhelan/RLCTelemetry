using RLCTelemetry.Utilities.Authentication;
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
        private MainWindow parent;

        public Authentication(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            Console.WriteLine("[GUI] Showing authentication settings");

            Authenticator auth = new Authenticator();
            auth.ReadKey();
            this.websiteTokenRichTextBox.Text = auth.Key;
        }

        private void authCancelButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("[GUI] Closing authentication settings");
            this.Close();
        }

        private void authSaveButton_Click(object sender, EventArgs e)
        {
            Authenticator auth = new Authenticator();
            auth.WriteKey(this.websiteTokenRichTextBox.Text, this.parent);
            this.Close();
        }
    }
}
