namespace WindowsFormsUI
{
    partial class ImageManipulationForm
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
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.ConvertImageComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConvertNowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenFileButton.Location = new System.Drawing.Point(64, 197);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(137, 28);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "Open file";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // ConvertImageComboBox
            // 
            this.ConvertImageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConvertImageComboBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConvertImageComboBox.DropDownHeight = 110;
            this.ConvertImageComboBox.FormattingEnabled = true;
            this.ConvertImageComboBox.IntegralHeight = false;
            this.ConvertImageComboBox.ItemHeight = 13;
            this.ConvertImageComboBox.Location = new System.Drawing.Point(313, 197);
            this.ConvertImageComboBox.Name = "ConvertImageComboBox";
            this.ConvertImageComboBox.Size = new System.Drawing.Size(185, 21);
            this.ConvertImageComboBox.TabIndex = 1;
            this.ConvertImageComboBox.SelectedIndexChanged += new System.EventHandler(this.ConvertImageComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose format to convert";
            // 
            // ConvertNowButton
            // 
            this.ConvertNowButton.AutoSize = true;
            this.ConvertNowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConvertNowButton.Location = new System.Drawing.Point(586, 195);
            this.ConvertNowButton.Name = "ConvertNowButton";
            this.ConvertNowButton.Size = new System.Drawing.Size(79, 23);
            this.ConvertNowButton.TabIndex = 3;
            this.ConvertNowButton.Text = "Convert Now";
            this.ConvertNowButton.UseVisualStyleBackColor = true;
            this.ConvertNowButton.Click += new System.EventHandler(this.ConvertNowButton_Click);
            // 
            // ImageManipulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConvertNowButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConvertImageComboBox);
            this.Controls.Add(this.OpenFileButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ImageManipulationForm";
            this.Text = "Image Manipulation Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.ComboBox ConvertImageComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConvertNowButton;
    }
}

