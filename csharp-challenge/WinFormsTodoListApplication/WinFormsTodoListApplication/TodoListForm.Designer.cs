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
            this.TodoCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.TodoTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TodoHeading
            // 
            this.TodoHeading.AutoSize = true;
            this.TodoHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodoHeading.Location = new System.Drawing.Point(51, 49);
            this.TodoHeading.Name = "TodoHeading";
            this.TodoHeading.Size = new System.Drawing.Size(112, 26);
            this.TodoHeading.TabIndex = 1;
            this.TodoHeading.Text = "Todo Task";
            // 
            // TodoCheckBoxList
            // 
            this.TodoCheckBoxList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodoCheckBoxList.FormattingEnabled = true;
            this.TodoCheckBoxList.Location = new System.Drawing.Point(57, 177);
            this.TodoCheckBoxList.Name = "TodoCheckBoxList";
            this.TodoCheckBoxList.Size = new System.Drawing.Size(595, 235);
            this.TodoCheckBoxList.TabIndex = 2;
            // 
            // TodoTextBox
            // 
            this.TodoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodoTextBox.Location = new System.Drawing.Point(57, 112);
            this.TodoTextBox.Name = "TodoTextBox";
            this.TodoTextBox.Size = new System.Drawing.Size(488, 26);
            this.TodoTextBox.TabIndex = 3;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(544, 112);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(108, 26);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add Task";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // TodoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 450);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.TodoTextBox);
            this.Controls.Add(this.TodoCheckBoxList);
            this.Controls.Add(this.TodoHeading);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TodoListForm";
            this.Text = "Todo List Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TodoHeading;
        private System.Windows.Forms.CheckedListBox TodoCheckBoxList;
        private System.Windows.Forms.TextBox TodoTextBox;
        private System.Windows.Forms.Button AddButton;
    }
}

