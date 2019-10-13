namespace WinFormUI
{
    partial class Dashboard
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
            this.launchMessage = new System.Windows.Forms.Button();
            this.launchSubDashboard = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // launchMessage
            // 
            this.launchMessage.Location = new System.Drawing.Point(75, 88);
            this.launchMessage.Name = "launchMessage";
            this.launchMessage.Size = new System.Drawing.Size(255, 77);
            this.launchMessage.TabIndex = 0;
            this.launchMessage.Text = "Open Message Creation";
            this.launchMessage.UseVisualStyleBackColor = true;
            // 
            // launchSubDashboard
            // 
            this.launchSubDashboard.Location = new System.Drawing.Point(75, 188);
            this.launchSubDashboard.Name = "launchSubDashboard";
            this.launchSubDashboard.Size = new System.Drawing.Size(255, 77);
            this.launchSubDashboard.TabIndex = 0;
            this.launchSubDashboard.Text = "Open Sub-Dashboard";
            this.launchSubDashboard.UseVisualStyleBackColor = true;
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(75, 299);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(255, 35);
            this.messageText.TabIndex = 1;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 439);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.launchSubDashboard);
            this.Controls.Add(this.launchMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "Dashboard";
            this.Text = "Dashboard for Weekly Challenge by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchMessage;
        private System.Windows.Forms.Button launchSubDashboard;
        private System.Windows.Forms.TextBox messageText;
    }
}

