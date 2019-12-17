using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfCoreTodoListWithDragDropApplication.Diag
{
    /// <summary>
    /// Interaction logic for AddTodoItem.xaml
    /// </summary>
    public partial class AddTodoItemDialog : Window
    {
        public string TodoItemText { get; set; }

        public AddTodoItemDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItemText = addTodoItemText.Text;
            this.DialogResult = true;
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            addTodoItemText.SelectAll();
            addTodoItemText.Focus();
        }
    }
}
