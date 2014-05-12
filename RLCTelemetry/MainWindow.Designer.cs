namespace RLCTelemetry
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authenticationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localisationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mPHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kPHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usingOtherAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authenticatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamingToTheWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.driverhelmetpicture = new System.Windows.Forms.PictureBox();
            this.driverWelcomeLabel = new System.Windows.Forms.Label();
            this.sessionGroupBox = new System.Windows.Forms.GroupBox();
            this.resetsessionbutton = new System.Windows.Forms.Button();
            this.savelogbutton = new RLCTelemetry.Controls.UIButton();
            this.bestlaplabel = new System.Windows.Forms.Label();
            this.speedunitslabel = new System.Windows.Forms.Label();
            this.streamControlButton = new System.Windows.Forms.Button();
            this.topSpeed = new System.Windows.Forms.Label();
            this.topSpeedLabel = new System.Windows.Forms.Label();
            this.lastLapTime = new System.Windows.Forms.Label();
            this.lastLapLabel = new System.Windows.Forms.Label();
            this.previousLapsGroup = new System.Windows.Forms.GroupBox();
            this.previousLaps = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarStreamingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverhelmetpicture)).BeginInit();
            this.sessionGroupBox.SuspendLayout();
            this.previousLapsGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem,
            this.applicationToolStripMenuItem,
            this.forwardingToolStripMenuItem,
            this.localisationToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.helpToolStripMenuItem.Text = "Settings";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationToolStripMenuItem});
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            // 
            // authenticationToolStripMenuItem
            // 
            this.authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
            this.authenticationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.authenticationToolStripMenuItem.Text = "Authentication";
            this.authenticationToolStripMenuItem.Click += new System.EventHandler(this.authenticationToolStripMenuItem_Click);
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.applicationToolStripMenuItem.Text = "Application";
            this.applicationToolStripMenuItem.Click += new System.EventHandler(this.applicationToolStripMenuItem_Click);
            // 
            // forwardingToolStripMenuItem
            // 
            this.forwardingToolStripMenuItem.Name = "forwardingToolStripMenuItem";
            this.forwardingToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.forwardingToolStripMenuItem.Text = "Forwarding";
            // 
            // localisationToolStripMenuItem
            // 
            this.localisationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPHToolStripMenuItem,
            this.kPHToolStripMenuItem});
            this.localisationToolStripMenuItem.Name = "localisationToolStripMenuItem";
            this.localisationToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.localisationToolStripMenuItem.Text = "Localisation";
            // 
            // mPHToolStripMenuItem
            // 
            this.mPHToolStripMenuItem.Checked = true;
            this.mPHToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mPHToolStripMenuItem.Name = "mPHToolStripMenuItem";
            this.mPHToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.mPHToolStripMenuItem.Text = "MPH";
            this.mPHToolStripMenuItem.Click += new System.EventHandler(this.mPHToolStripMenuItem_Click);
            // 
            // kPHToolStripMenuItem
            // 
            this.kPHToolStripMenuItem.Name = "kPHToolStripMenuItem";
            this.kPHToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.kPHToolStripMenuItem.Text = "KPH";
            this.kPHToolStripMenuItem.Click += new System.EventHandler(this.kPHToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem1,
            this.helpToolStripMenuItem1,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem1
            // 
            this.instructionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingUpToolStripMenuItem,
            this.usingOtherAppsToolStripMenuItem,
            this.authenticatingToolStripMenuItem,
            this.streamingToTheWebsiteToolStripMenuItem});
            this.instructionsToolStripMenuItem1.Name = "instructionsToolStripMenuItem1";
            this.instructionsToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem1.Text = "Instructions";
            // 
            // settingUpToolStripMenuItem
            // 
            this.settingUpToolStripMenuItem.Name = "settingUpToolStripMenuItem";
            this.settingUpToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.settingUpToolStripMenuItem.Text = "Setting up";
            // 
            // usingOtherAppsToolStripMenuItem
            // 
            this.usingOtherAppsToolStripMenuItem.Name = "usingOtherAppsToolStripMenuItem";
            this.usingOtherAppsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.usingOtherAppsToolStripMenuItem.Text = "Using other apps";
            // 
            // authenticatingToolStripMenuItem
            // 
            this.authenticatingToolStripMenuItem.Name = "authenticatingToolStripMenuItem";
            this.authenticatingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.authenticatingToolStripMenuItem.Text = "Authenticating";
            // 
            // streamingToTheWebsiteToolStripMenuItem
            // 
            this.streamingToTheWebsiteToolStripMenuItem.Name = "streamingToTheWebsiteToolStripMenuItem";
            this.streamingToTheWebsiteToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.streamingToTheWebsiteToolStripMenuItem.Text = "Streaming to the website";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.driverhelmetpicture);
            this.panel1.Controls.Add(this.driverWelcomeLabel);
            this.panel1.Controls.Add(this.sessionGroupBox);
            this.panel1.Controls.Add(this.previousLapsGroup);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 360);
            this.panel1.TabIndex = 1;
            // 
            // driverhelmetpicture
            // 
            this.driverhelmetpicture.Image = global::RLCTelemetry.Properties.Resources._32x32;
            this.driverhelmetpicture.InitialImage = global::RLCTelemetry.Properties.Resources._32x32;
            this.driverhelmetpicture.Location = new System.Drawing.Point(10, 0);
            this.driverhelmetpicture.Name = "driverhelmetpicture";
            this.driverhelmetpicture.Size = new System.Drawing.Size(32, 32);
            this.driverhelmetpicture.TabIndex = 3;
            this.driverhelmetpicture.TabStop = false;
            // 
            // driverWelcomeLabel
            // 
            this.driverWelcomeLabel.AutoSize = true;
            this.driverWelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverWelcomeLabel.Location = new System.Drawing.Point(45, 6);
            this.driverWelcomeLabel.Name = "driverWelcomeLabel";
            this.driverWelcomeLabel.Size = new System.Drawing.Size(290, 20);
            this.driverWelcomeLabel.TabIndex = 2;
            this.driverWelcomeLabel.Text = "Hello new user, please link your account";
            // 
            // sessionGroupBox
            // 
            this.sessionGroupBox.Controls.Add(this.resetsessionbutton);
            this.sessionGroupBox.Controls.Add(this.savelogbutton);
            this.sessionGroupBox.Controls.Add(this.bestlaplabel);
            this.sessionGroupBox.Controls.Add(this.speedunitslabel);
            this.sessionGroupBox.Controls.Add(this.streamControlButton);
            this.sessionGroupBox.Controls.Add(this.topSpeed);
            this.sessionGroupBox.Controls.Add(this.topSpeedLabel);
            this.sessionGroupBox.Controls.Add(this.lastLapTime);
            this.sessionGroupBox.Controls.Add(this.lastLapLabel);
            this.sessionGroupBox.Location = new System.Drawing.Point(3, 33);
            this.sessionGroupBox.Name = "sessionGroupBox";
            this.sessionGroupBox.Size = new System.Drawing.Size(328, 113);
            this.sessionGroupBox.TabIndex = 1;
            this.sessionGroupBox.TabStop = false;
            this.sessionGroupBox.Text = "Session Statistics";
            // 
            // resetsessionbutton
            // 
            this.resetsessionbutton.Enabled = true;
            this.resetsessionbutton.Location = new System.Drawing.Point(178, 84);
            this.resetsessionbutton.Name = "resetsessionbutton";
            this.resetsessionbutton.Size = new System.Drawing.Size(75, 23);
            this.resetsessionbutton.TabIndex = 8;
            this.resetsessionbutton.Text = "Reset";
            this.resetsessionbutton.UseVisualStyleBackColor = true;
            this.resetsessionbutton.Click += new System.EventHandler(this.resetsessionbutton_Click);
            // 
            // savelogbutton
            // 
            this.savelogbutton.Enabled = false;
            this.savelogbutton.Location = new System.Drawing.Point(97, 84);
            this.savelogbutton.Name = "savelogbutton";
            this.savelogbutton.Size = new System.Drawing.Size(75, 23);
            this.savelogbutton.TabIndex = 7;
            this.savelogbutton.Text = "Save Log";
            this.savelogbutton.UseVisualStyleBackColor = true;
            // 
            // bestlaplabel
            // 
            this.bestlaplabel.AutoSize = true;
            this.bestlaplabel.Location = new System.Drawing.Point(28, 52);
            this.bestlaplabel.Name = "bestlaplabel";
            this.bestlaplabel.Size = new System.Drawing.Size(48, 13);
            this.bestlaplabel.TabIndex = 6;
            this.bestlaplabel.Text = "Best lap:";
            // 
            // speedunitslabel
            // 
            this.speedunitslabel.AutoSize = true;
            this.speedunitslabel.Location = new System.Drawing.Point(186, 37);
            this.speedunitslabel.Name = "speedunitslabel";
            this.speedunitslabel.Size = new System.Drawing.Size(31, 13);
            this.speedunitslabel.TabIndex = 5;
            this.speedunitslabel.Text = "MPH";
            // 
            // streamControlButton
            // 
            this.streamControlButton.Enabled = false;
            this.streamControlButton.Location = new System.Drawing.Point(16, 84);
            this.streamControlButton.Name = "streamControlButton";
            this.streamControlButton.Size = new System.Drawing.Size(75, 23);
            this.streamControlButton.TabIndex = 4;
            this.streamControlButton.Text = "Start";
            this.streamControlButton.UseVisualStyleBackColor = true;
            this.streamControlButton.Click += new System.EventHandler(this.streamControlButton_Click);
            // 
            // topSpeed
            // 
            this.topSpeed.AutoSize = true;
            this.topSpeed.Location = new System.Drawing.Point(163, 37);
            this.topSpeed.Name = "topSpeed";
            this.topSpeed.Size = new System.Drawing.Size(25, 13);
            this.topSpeed.TabIndex = 3;
            this.topSpeed.Text = "000";
            // 
            // topSpeedLabel
            // 
            this.topSpeedLabel.AutoSize = true;
            this.topSpeedLabel.Location = new System.Drawing.Point(13, 37);
            this.topSpeedLabel.Name = "topSpeedLabel";
            this.topSpeedLabel.Size = new System.Drawing.Size(63, 13);
            this.topSpeedLabel.TabIndex = 2;
            this.topSpeedLabel.Text = "Top Speed:";
            // 
            // lastLapTime
            // 
            this.lastLapTime.AutoSize = true;
            this.lastLapTime.Location = new System.Drawing.Point(163, 20);
            this.lastLapTime.Name = "lastLapTime";
            this.lastLapTime.Size = new System.Drawing.Size(49, 13);
            this.lastLapTime.TabIndex = 1;
            this.lastLapTime.Text = "0:00.000";
            // 
            // lastLapLabel
            // 
            this.lastLapLabel.AutoSize = true;
            this.lastLapLabel.Location = new System.Drawing.Point(25, 20);
            this.lastLapLabel.Name = "lastLapLabel";
            this.lastLapLabel.Size = new System.Drawing.Size(51, 13);
            this.lastLapLabel.TabIndex = 0;
            this.lastLapLabel.Text = "Last Lap:";
            // 
            // previousLapsGroup
            // 
            this.previousLapsGroup.Controls.Add(this.previousLaps);
            this.previousLapsGroup.Location = new System.Drawing.Point(3, 152);
            this.previousLapsGroup.Name = "previousLapsGroup";
            this.previousLapsGroup.Size = new System.Drawing.Size(328, 205);
            this.previousLapsGroup.TabIndex = 0;
            this.previousLapsGroup.TabStop = false;
            this.previousLapsGroup.Text = "Previous Laps";
            // 
            // previousLaps
            // 
            this.previousLaps.FormattingEnabled = true;
            this.previousLaps.Location = new System.Drawing.Point(7, 20);
            this.previousLaps.Name = "previousLaps";
            this.previousLaps.Size = new System.Drawing.Size(312, 173);
            this.previousLaps.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarStreamingLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(334, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBarStreamingLabel
            // 
            this.statusBarStreamingLabel.Name = "statusBarStreamingLabel";
            this.statusBarStreamingLabel.Size = new System.Drawing.Size(83, 17);
            this.statusBarStreamingLabel.Text = "Not streaming";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 412);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Racing League Charts Telemetry";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverhelmetpicture)).EndInit();
            this.sessionGroupBox.ResumeLayout(false);
            this.sessionGroupBox.PerformLayout();
            this.previousLapsGroup.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem authenticationToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usingOtherAppsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authenticatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamingToTheWebsiteToolStripMenuItem;
        private System.Windows.Forms.GroupBox sessionGroupBox;
        private System.Windows.Forms.Label topSpeed;
        private System.Windows.Forms.Label topSpeedLabel;
        private System.Windows.Forms.Label lastLapTime;
        private System.Windows.Forms.Label lastLapLabel;
        private System.Windows.Forms.GroupBox previousLapsGroup;
        private System.Windows.Forms.ListBox previousLaps;
        private System.Windows.Forms.Button streamControlButton;
        private System.Windows.Forms.ToolStripStatusLabel statusBarStreamingLabel;
        private System.Windows.Forms.ToolStripMenuItem localisationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mPHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kPHToolStripMenuItem;
        private System.Windows.Forms.Label speedunitslabel;
        private Controls.UIButton savelogbutton;
        private System.Windows.Forms.Label bestlaplabel;
        private System.Windows.Forms.Label driverWelcomeLabel;
        private System.Windows.Forms.Button resetsessionbutton;
        private System.Windows.Forms.PictureBox driverhelmetpicture;
    }
}