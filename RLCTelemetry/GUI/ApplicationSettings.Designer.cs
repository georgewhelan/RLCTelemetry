namespace RLCTelemetry.GUI
{
    partial class ApplicationSettings
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
            this.saveButton = new RLCTelemetry.Controls.UIButton();
            this.resetButton = new RLCTelemetry.Controls.UIButton();
            this.cancelButton = new RLCTelemetry.Controls.UIButton();
            this.currentPortLabel = new System.Windows.Forms.Label();
            this.currentPortTextbox = new System.Windows.Forms.TextBox();
            this.portErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 227);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(98, 227);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(182, 227);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Close";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // currentPortLabel
            // 
            this.currentPortLabel.AutoSize = true;
            this.currentPortLabel.Location = new System.Drawing.Point(12, 13);
            this.currentPortLabel.Name = "currentPortLabel";
            this.currentPortLabel.Size = new System.Drawing.Size(29, 13);
            this.currentPortLabel.TabIndex = 3;
            this.currentPortLabel.Text = "Port:";
            // 
            // currentPortTextbox
            // 
            this.currentPortTextbox.Location = new System.Drawing.Point(83, 10);
            this.currentPortTextbox.Name = "currentPortTextbox";
            this.currentPortTextbox.Size = new System.Drawing.Size(100, 20);
            this.currentPortTextbox.TabIndex = 4;
            // 
            // portErrorLabel
            // 
            this.portErrorLabel.AutoSize = true;
            this.portErrorLabel.Location = new System.Drawing.Point(15, 34);
            this.portErrorLabel.Name = "portErrorLabel";
            this.portErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.portErrorLabel.TabIndex = 5;
            // 
            // ApplicationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(269, 262);
            this.Controls.Add(this.portErrorLabel);
            this.Controls.Add(this.currentPortTextbox);
            this.Controls.Add(this.currentPortLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(285, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(285, 300);
            this.Name = "ApplicationSettings";
            this.ShowIcon = false;
            this.Text = "Application Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.UIButton saveButton;
        private Controls.UIButton resetButton;
        private Controls.UIButton cancelButton;
        private System.Windows.Forms.Label currentPortLabel;
        private System.Windows.Forms.TextBox currentPortTextbox;
        private System.Windows.Forms.Label portErrorLabel;
    }
}