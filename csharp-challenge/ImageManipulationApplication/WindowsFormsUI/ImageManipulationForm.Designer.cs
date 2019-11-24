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
            this.ChooseFormatLabel = new System.Windows.Forms.Label();
            this.ConvertNowButton = new System.Windows.Forms.Button();
            this.ChnageResolutionLabel = new System.Windows.Forms.Label();
            this.ChangeResolutionComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFileButton.Location = new System.Drawing.Point(98, 195);
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
            this.ConvertImageComboBox.BackColor = System.Drawing.Color.Black;
            this.ConvertImageComboBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ConvertImageComboBox.DropDownHeight = 110;
            this.ConvertImageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConvertImageComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertImageComboBox.ForeColor = System.Drawing.Color.White;
            this.ConvertImageComboBox.FormattingEnabled = true;
            this.ConvertImageComboBox.IntegralHeight = false;
            this.ConvertImageComboBox.ItemHeight = 20;
            this.ConvertImageComboBox.Location = new System.Drawing.Point(304, 195);
            this.ConvertImageComboBox.Name = "ConvertImageComboBox";
            this.ConvertImageComboBox.Size = new System.Drawing.Size(185, 28);
            this.ConvertImageComboBox.TabIndex = 1;
            // 
            // ChooseFormatLabel
            // 
            this.ChooseFormatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ChooseFormatLabel.AutoSize = true;
            this.ChooseFormatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseFormatLabel.Location = new System.Drawing.Point(311, 153);
            this.ChooseFormatLabel.Name = "ChooseFormatLabel";
            this.ChooseFormatLabel.Size = new System.Drawing.Size(167, 17);
            this.ChooseFormatLabel.TabIndex = 2;
            this.ChooseFormatLabel.Text = "Choose format to convert";
            // 
            // ConvertNowButton
            // 
            this.ConvertNowButton.AutoSize = true;
            this.ConvertNowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConvertNowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertNowButton.Location = new System.Drawing.Point(563, 195);
            this.ConvertNowButton.Name = "ConvertNowButton";
            this.ConvertNowButton.Size = new System.Drawing.Size(109, 30);
            this.ConvertNowButton.TabIndex = 3;
            this.ConvertNowButton.Text = "Convert Now";
            this.ConvertNowButton.UseVisualStyleBackColor = true;
            this.ConvertNowButton.Click += new System.EventHandler(this.ConvertNowButton_Click);
            // 
            // ChnageResolutionLabel
            // 
            this.ChnageResolutionLabel.AutoSize = true;
            this.ChnageResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChnageResolutionLabel.Location = new System.Drawing.Point(311, 262);
            this.ChnageResolutionLabel.Name = "ChnageResolutionLabel";
            this.ChnageResolutionLabel.Size = new System.Drawing.Size(128, 17);
            this.ChnageResolutionLabel.TabIndex = 4;
            this.ChnageResolutionLabel.Text = "Change Resolution";
            // 
            // ChangeResolutionComboBox
            // 
            this.ChangeResolutionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeResolutionComboBox.FormattingEnabled = true;
            this.ChangeResolutionComboBox.Location = new System.Drawing.Point(304, 301);
            this.ChangeResolutionComboBox.Name = "ChangeResolutionComboBox";
            this.ChangeResolutionComboBox.Size = new System.Drawing.Size(185, 28);
            this.ChangeResolutionComboBox.TabIndex = 5;
            // 
            // ImageManipulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChangeResolutionComboBox);
            this.Controls.Add(this.ChnageResolutionLabel);
            this.Controls.Add(this.ConvertNowButton);
            this.Controls.Add(this.ChooseFormatLabel);
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
        private System.Windows.Forms.Label ChooseFormatLabel;
        private System.Windows.Forms.Button ConvertNowButton;
        private System.Windows.Forms.Label ChnageResolutionLabel;
        private System.Windows.Forms.ComboBox ChangeResolutionComboBox;
    }
}

