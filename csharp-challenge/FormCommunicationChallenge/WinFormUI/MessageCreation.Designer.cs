namespace WinFormUI
{
    partial class MessageCreation
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.messageText = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.createMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(159, 71);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(262, 35);
            this.nameText.TabIndex = 0;
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(159, 124);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(262, 35);
            this.messageText.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(40, 74);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(84, 29);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(40, 127);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(118, 29);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = "Message:";
            // 
            // createMessage
            // 
            this.createMessage.Location = new System.Drawing.Point(159, 180);
            this.createMessage.Name = "createMessage";
            this.createMessage.Size = new System.Drawing.Size(184, 61);
            this.createMessage.TabIndex = 2;
            this.createMessage.Text = "Create";
            this.createMessage.UseVisualStyleBackColor = true;
            // 
            // MessageCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 273);
            this.Controls.Add(this.createMessage);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.nameText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "MessageCreation";
            this.Text = "MessageCreation for Weekly Challenge by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button createMessage;
    }
}