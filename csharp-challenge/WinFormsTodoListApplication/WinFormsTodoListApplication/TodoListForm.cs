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
            TodoCheckListBox.DisplayMember = "DisplayTodo";
            TodoCheckListBox.ValueMember = "Priority";

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
                Priority = 1,
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
                    Priority = TodoCheckListBox.Items.Count + 1,
                    Name = TodoTextBox.Text
                };

                todoList.Add(todoItem);
            }

            MarkCheckBoxComplete();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (TodoCheckListBox.Items.Count > 0)
            {
                todoList[TodoCheckListBox.SelectedIndex].Name = EditTextBox.Text;
            }

            TodoCheckListBox.Refresh();
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
