using System.Windows.Forms;
namespace RLCTelemetry.GUI
{
    partial class Authentication
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
            this.websiteTokenRichTextBox = new System.Windows.Forms.RichTextBox();
            this.authenticationLabel = new System.Windows.Forms.Label();
            this.authCancelButton = new RLCTelemetry.Controls.UIButton();
            this.authSaveButton = new RLCTelemetry.Controls.UIButton();
            this.SuspendLayout();
            // 
            // websiteTokenRichTextBox
            // 
            this.websiteTokenRichTextBox.Location = new System.Drawing.Point(12, 34);
            this.websiteTokenRichTextBox.Name = "websiteTokenRichTextBox";
            this.websiteTokenRichTextBox.Size = new System.Drawing.Size(260, 109);
            this.websiteTokenRichTextBox.TabIndex = 0;
            this.websiteTokenRichTextBox.Text = "";
            // 
            // authenticationLabel
            // 
            this.authenticationLabel.AutoSize = true;
            this.authenticationLabel.Location = new System.Drawing.Point(10, 18);
            this.authenticationLabel.Name = "authenticationLabel";
            this.authenticationLabel.Size = new System.Drawing.Size(155, 13);
            this.authenticationLabel.TabIndex = 3;
            this.authenticationLabel.Text = "Enter your authentication token";
            // 
            // authCancelButton
            // 
            this.authCancelButton.Location = new System.Drawing.Point(94, 149);
            this.authCancelButton.Name = "authCancelButton";
            this.authCancelButton.Size = new System.Drawing.Size(75, 23);
            this.authCancelButton.TabIndex = 2;
            this.authCancelButton.Text = "Cancel";
            this.authCancelButton.UseVisualStyleBackColor = true;
            this.authCancelButton.Click += new System.EventHandler(this.authCancelButton_Click);
            // 
            // authSaveButton
            // 
            this.authSaveButton.Location = new System.Drawing.Point(13, 149);
            this.authSaveButton.Name = "authSaveButton";
            this.authSaveButton.Size = new System.Drawing.Size(75, 23);
            this.authSaveButton.TabIndex = 1;
            this.authSaveButton.Text = "Save";
            this.authSaveButton.UseVisualStyleBackColor = true;
            this.authSaveButton.Click += new System.EventHandler(this.authSaveButton_Click);
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.authenticationLabel);
            this.Controls.Add(this.authCancelButton);
            this.Controls.Add(this.authSaveButton);
            this.Controls.Add(this.websiteTokenRichTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authentication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox websiteTokenRichTextBox;
        private Controls.UIButton authSaveButton;
        private Controls.UIButton authCancelButton;
        private Label authenticationLabel;

        
    }
}