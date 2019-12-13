namespace WinFormsTodoListApplication
{
    partial class TodoListForm
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
            this.TodoHeading = new System.Windows.Forms.Label();
            this.TodoCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.TodoTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TodoHeading
            // 
            this.TodoHeading.AutoSize = true;
            this.TodoHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodoHeading.Location = new System.Drawing.Point(52, 49);
            this.TodoHeading.Name = "TodoHeading";
            this.TodoHeading.Size = new System.Drawing.Size(112, 26);
            this.TodoHeading.TabIndex = 1;
            this.TodoHeading.Text = "Todo Task";
            // 
            // TodoCheckListBox
            // 
            this.TodoCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodoCheckListBox.FormattingEnabled = true;
            this.TodoCheckListBox.Location = new System.Drawing.Point(57, 177);
            this.TodoCheckListBox.Name = "TodoCheckListBox";
            this.TodoCheckListBox.Size = new System.Drawing.Size(595, 235);
            this.TodoCheckListBox.TabIndex = 2;
            this.TodoCheckListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TodoCheckListBox_KeyDown);
            // 
            // TodoTextBox
            // 
            this.TodoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodoTextBox.Location = new System.Drawing.Point(57, 88);
            this.TodoTextBox.Name = "TodoTextBox";
            this.TodoTextBox.Size = new System.Drawing.Size(488, 26);
            this.TodoTextBox.TabIndex = 3;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(544, 88);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(108, 26);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add Task";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(544, 132);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(108, 28);
            this.EditButton.TabIndex = 5;
            this.EditButton.Text = "Edit Selected";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(672, 292);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(117, 23);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete Selected Item";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // EditTextBox
            // 
            this.EditTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditTextBox.Location = new System.Drawing.Point(57, 134);
            this.EditTextBox.Name = "EditTextBox";
            this.EditTextBox.Size = new System.Drawing.Size(488, 26);
            this.EditTextBox.TabIndex = 7;
            // 
            // TodoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 450);
            this.Controls.Add(this.EditTextBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.TodoTextBox);
            this.Controls.Add(this.TodoCheckListBox);
            this.Controls.Add(this.TodoHeading);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TodoListForm";
            this.Text = "Todo List Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TodoHeading;
        private System.Windows.Forms.CheckedListBox TodoCheckListBox;
        private System.Windows.Forms.TextBox TodoTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox EditTextBox;
    }
}

