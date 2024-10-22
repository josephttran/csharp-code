﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsTodoListApplication
{
    public partial class TodoListForm : Form
    {
        private readonly BindingList<TodoItem> todoList = new BindingList<TodoItem>();

        public TodoListForm()
        {
            InitializeComponent();

            /*
             * Set BindingList of TodoItem as data source
             * Set the TodoItem property to be displayed
             */
            TodoCheckListBox.DataSource = todoList;
            TodoCheckListBox.DisplayMember = "DisplayTodo";
            TodoCheckListBox.ValueMember = "Priority";

            // CleckListBox item check event
            TodoCheckListBox.ItemCheck += (sender, e) => todoList[e.Index].IsCompleted = (e.NewValue != CheckState.Unchecked);

            // BindingList list changed event
            todoList.ListChanged += (sender, e) => MarkCheckBoxComplete();

            // Add first test item
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
            TodoCheckListBox.SetItemChecked(0, true);
        }

        /*
         * Priority number is set to index position + 1
         */
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
                TodoTextBox.Text = "";
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (TodoCheckListBox.Items.Count > 0)
            {
                todoList[TodoCheckListBox.SelectedIndex].Name = EditTextBox.Text;

                TodoCheckListBox.Refresh();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (TodoCheckListBox.Items.Count > 0)
            {
                int index = TodoCheckListBox.SelectedIndex;
                TodoItem item = (TodoItem)TodoCheckListBox.SelectedItem;
                todoList.Remove(item);

                for (int i = index; i < todoList.Count; i++)
                {
                    todoList[i].Priority -= 1;
                }
            }
        }

        private void TodoCheckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                int index = TodoCheckListBox.SelectedIndex;

                if (index > 0)
                {
                    TodoItem item = (TodoItem) TodoCheckListBox.SelectedItem;
                    todoList.Remove(item);
                    todoList.Insert(index - 1, item);
                    todoList[index - 1].Priority -= 1;
                    todoList[index].Priority += 1;
                    TodoCheckListBox.SetSelected(index, true);
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                int index = TodoCheckListBox.SelectedIndex;

                if (index < todoList.Count - 1)
                {
                    TodoItem item = (TodoItem) TodoCheckListBox.SelectedItem;
                    todoList.Remove(item);
                    todoList.Insert(index + 1, item);
                    todoList[index + 1].Priority += 1;
                    todoList[index].Priority -= 1;
                    TodoCheckListBox.SetSelected(index, true);
                }
            }
        }
    }
}
