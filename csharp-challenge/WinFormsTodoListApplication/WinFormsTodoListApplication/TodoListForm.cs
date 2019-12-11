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

            TodoCheckListBox.ItemCheck += (sender, e) => {
                todoList[e.Index].IsCompleted = (e.NewValue != CheckState.Unchecked);
            };

            TodoCheckListBox.DataSource = todoList;
            TodoCheckListBox.DisplayMember = "Name";
            TodoCheckListBox.ValueMember = "Name";

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
                        TodoCheckListBox.SetItemChecked(i, true);
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
            if (TodoCheckListBox.Items.Count > 0)
            {
                todoList.Remove((TodoItem) TodoCheckListBox.SelectedItem);
            }

            MarkCheckBoxComplete();
        }
    }
}
