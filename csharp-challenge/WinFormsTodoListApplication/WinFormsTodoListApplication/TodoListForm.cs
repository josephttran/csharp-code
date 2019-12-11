using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsTodoListApplication
{
    public partial class TodoListForm : Form
    {
        BindingList<TodoItem> todoList = new BindingList<TodoItem>();

        public TodoListForm()
        {
            InitializeComponent();

            TodoCheckBoxList.DataSource = todoList;
            TodoCheckBoxList.DisplayMember = "Name";
            TodoCheckBoxList.ValueMember = "Name";

            AddOneCompletedToCheckBox();
        }

        private void MarkCheckBoxComplete()
        {
            if (todoList.Count > 0)
            {
                for (int i = 0; i < todoList.Count; i++)
                {
                    if (todoList[i].IsCompleted)
                    {
                        TodoCheckBoxList.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void AddOneCompletedToCheckBox()
        {
            TodoItem todoItem = new TodoItem
            {
                Name = "Add first item",
                IsCompleted = true
            };

            todoList.Add(todoItem);

            MarkCheckBoxComplete();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            foreach (int indexChecked in TodoCheckBoxList.CheckedIndices)
            {
                todoList[indexChecked].IsCompleted = true;
            }

            if (!string.IsNullOrWhiteSpace(TodoTextBox.Text))
            {
                TodoItem todoItem = new TodoItem
                {
                    Name = TodoTextBox.Text
                };

                todoList.Add(todoItem);
            }

            MarkCheckBoxComplete();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (TodoCheckBoxList.Items.Count > 0)
            {
                todoList.Remove((TodoItem) TodoCheckBoxList.SelectedItem);
            }

            MarkCheckBoxComplete();
        }
    }
}
