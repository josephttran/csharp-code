﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCoreTodoListWithDragDropApplication.Diag;
using WpfCoreTodoListWithDragDropApplication.Models;

namespace WpfCoreTodoListWithDragDropApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TodoItem> TodoList { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            TodoList = new ObservableCollection<TodoItem>
            {
                new TodoItem { Title = "First Item", IsComplete = true },
                new TodoItem { Title = "Next Item", IsComplete = false }
            };

            for (int index = 0; index < TodoList.Count; index++)
            {
                if (TodoList[index].IsComplete == true)
                {
                    MoveToEnd(index);
                }
            }
        }

        private void AddTodoButton_Click(object sender, RoutedEventArgs e)
        {
            AddTodoItemDialog addTodoItemDialog = new AddTodoItemDialog();

            if (addTodoItemDialog.ShowDialog() == true)
            {
                string text = addTodoItemDialog.TodoItemText;

                if (!string.IsNullOrEmpty(text))
                {
                    TodoList.Add(new TodoItem { Title = text });
                }
            }
        }

        private void RemoveTodoButton_Click(object sender, RoutedEventArgs e)
        {
            int index = todoListBox.SelectedIndex;

            if (index > -1 && index < TodoList.Count)
            {
                TodoList.RemoveAt(index);
            }
        }

        private void ListBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = todoListBox.SelectedIndex;

            if (index > -1 && index < TodoList.Count && TodoList[index].IsComplete == false)
            {
                TodoList[index].IsComplete = true;
                MoveToEnd(index);
            }
        }

        private void EditTodoButton_Click(object sender, RoutedEventArgs e)
        {
            int index = todoListBox.SelectedIndex;

            if (index > -1 && index < TodoList.Count)
            {
                EditTodoItemDialog editTodoItemDialog = new EditTodoItemDialog(TodoList[index]);

                if (editTodoItemDialog.ShowDialog() == true)
                {
                    TodoList[index].Title = editTodoItemDialog.TodoItem.Title;
                    TodoList[index].IsComplete = editTodoItemDialog.TodoItem.IsComplete;

                    if (TodoList[index].IsComplete == true)
                    {
                        MoveToEnd(index);
                    }
                }
            }
        }

        private void MoveToEnd(int index)
        {
            TodoItem todoItem = TodoList[index];

            TodoList.RemoveAt(index);
            TodoList.Insert(TodoList.Count, todoItem);
        }

        private void TodoListBox_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.Source != null)
                {
                    DragDrop.DoDragDrop((ListBox)e.Source, (ListBox)e.Source, DragDropEffects.Move);
                }
            }
        }

        private void TodoListBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent("System.Windows.Controls.ListBox"))
            {
                if (e.Data.GetData("System.Windows.Controls.ListBox") is ListBox source)
                {
                    var todoItemIndex = source.SelectedIndex;

                    if (todoItemIndex != -1)
                    {
                        TodoItem todoItemSelected = source.SelectedItem as TodoItem;
                        Border controlBorder = e.OriginalSource as Border;

                        if (controlBorder?.DataContext != null)
                        {
                            TodoItem target = controlBorder.DataContext as TodoItem;
                            int newIndex = todoListBox.Items.IndexOf(target);

                            TodoList.RemoveAt(todoItemIndex);
                            TodoList.Insert(newIndex, todoItemSelected);
                        }
                    }
                }
            }
        }
    }
}
