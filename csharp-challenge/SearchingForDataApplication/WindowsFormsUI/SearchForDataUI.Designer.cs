namespace WindowsFormsUI
{
    partial class SearchForDataUI
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
            this.listBoxPrimary = new System.Windows.Forms.ListBox();
            this.textBoxPrimarySearch = new System.Windows.Forms.TextBox();
            this.ButtonPrimarySearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxBonus = new System.Windows.Forms.ListBox();
            this.textBoxBonus = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonBonusSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxPrimary
            // 
            this.listBoxPrimary.FormattingEnabled = true;
            this.listBoxPrimary.Location = new System.Drawing.Point(18, 83);
            this.listBoxPrimary.Name = "listBoxPrimary";
            this.listBoxPrimary.Size = new System.Drawing.Size(708, 277);
            this.listBoxPrimary.TabIndex = 0;
            // 
            // textBoxPrimarySearch
            // 
            this.textBoxPrimarySearch.Location = new System.Drawing.Point(18, 32);
            this.textBoxPrimarySearch.Name = "textBoxPrimarySearch";
            this.textBoxPrimarySearch.Size = new System.Drawing.Size(581, 20);
            this.textBoxPrimarySearch.TabIndex = 1;
            // 
            // ButtonPrimarySearch
            // 
            this.ButtonPrimarySearch.Location = new System.Drawing.Point(577, 0);
            this.ButtonPrimarySearch.Name = "ButtonPrimarySearch";
            this.ButtonPrimarySearch.Size = new System.Drawing.Size(131, 20);
            this.ButtonPrimarySearch.TabIndex = 2;
            this.ButtonPrimarySearch.Text = "Search";
            this.ButtonPrimarySearch.UseVisualStyleBackColor = true;
            this.ButtonPrimarySearch.Click += new System.EventHandler(this.ButtonPrimarySearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonPrimarySearch);
            this.panel1.Location = new System.Drawing.Point(18, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 20);
            this.panel1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(33, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 408);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxPrimarySearch);
            this.tabPage1.Controls.Add(this.listBoxPrimary);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(747, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Primary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxBonus);
            this.tabPage2.Controls.Add(this.textBoxBonus);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(747, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Bonus";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxBonus
            // 
            this.listBoxBonus.FormattingEnabled = true;
            this.listBoxBonus.Location = new System.Drawing.Point(22, 82);
            this.listBoxBonus.Name = "listBoxBonus";
            this.listBoxBonus.Size = new System.Drawing.Size(703, 277);
            this.listBoxBonus.TabIndex = 6;
            // 
            // textBoxBonus
            // 
            this.textBoxBonus.Location = new System.Drawing.Point(22, 36);
            this.textBoxBonus.Name = "textBoxBonus";
            this.textBoxBonus.Size = new System.Drawing.Size(576, 20);
            this.textBoxBonus.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ButtonBonusSearch);
            this.panel2.Location = new System.Drawing.Point(22, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 20);
            this.panel2.TabIndex = 5;
            // 
            // ButtonBonusSearch
            // 
            this.ButtonBonusSearch.Location = new System.Drawing.Point(574, 0);
            this.ButtonBonusSearch.Name = "ButtonBonusSearch";
            this.ButtonBonusSearch.Size = new System.Drawing.Size(129, 20);
            this.ButtonBonusSearch.TabIndex = 2;
            this.ButtonBonusSearch.Text = "Search";
            this.ButtonBonusSearch.UseVisualStyleBackColor = true;
            this.ButtonBonusSearch.Click += new System.EventHandler(this.ButtonBonusSearch_Click);
            // 
            // SearchForDataUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "SearchForDataUI";
            this.Text = "Search for Data";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPrimary;
        private System.Windows.Forms.TextBox textBoxPrimarySearch;
        private System.Windows.Forms.Button ButtonPrimarySearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxBonus;
        private System.Windows.Forms.TextBox textBoxBonus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ButtonBonusSearch;
    }
}

