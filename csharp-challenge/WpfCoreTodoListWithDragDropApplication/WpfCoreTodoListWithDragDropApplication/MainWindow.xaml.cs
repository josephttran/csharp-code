using System;
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

            if (index > -1 && index < TodoList.Count)
            {
                TodoList[index].IsComplete = true;
            }
        }
    }
}
