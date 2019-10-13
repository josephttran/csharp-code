namespace WinFormUI
{
    partial class SubDashboard
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
            this.nameAndMessageText = new System.Windows.Forms.TextBox();
            this.launchMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameAndMessageText
            // 
            this.nameAndMessageText.Location = new System.Drawing.Point(99, 159);
            this.nameAndMessageText.Multiline = true;
            this.nameAndMessageText.Name = "nameAndMessageText";
            this.nameAndMessageText.Size = new System.Drawing.Size(255, 115);
            this.nameAndMessageText.TabIndex = 3;
            // 
            // launchMessage
            // 
            this.launchMessage.Location = new System.Drawing.Point(99, 58);
            this.launchMessage.Name = "launchMessage";
            this.launchMessage.Size = new System.Drawing.Size(255, 77);
            this.launchMessage.TabIndex = 2;
            this.launchMessage.Text = "Open Message Creation";
            this.launchMessage.UseVisualStyleBackColor = true;
            // 
            // SubDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 302);
            this.Controls.Add(this.nameAndMessageText);
            this.Controls.Add(this.launchMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "SubDashboard";
            this.Text = "SubDashboard for Weekly Challenge by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameAndMessageText;
        private System.Windows.Forms.Button launchMessage;
    }
}