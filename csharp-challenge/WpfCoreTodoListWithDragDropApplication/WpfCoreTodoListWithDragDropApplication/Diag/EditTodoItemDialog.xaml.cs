using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCoreTodoListWithDragDropApplication.Models;

namespace WpfCoreTodoListWithDragDropApplication.Diag
{

    /// <summary>
    /// Interaction logic for EditTodoItemDialog.xaml
    /// </summary>
    public partial class EditTodoItemDialog : Window
    {
        public TodoItem TodoItem { get; set; }

        public EditTodoItemDialog(TodoItem todoItem)
        {
            InitializeComponent();

            DataContext = this;

            TodoItem = todoItem;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TodoItem.Title = editTodoItemText.Text;
            RadioButton checkedRadioButton = radioButtons.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);

            if (checkedRadioButton.Content.ToString() == "Yes")
            {
                TodoItem.IsComplete = true;
            }
            else
            {
                TodoItem.IsComplete = false;
            }

            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            editTodoItemText.SelectAll();
            editTodoItemText.Focus();
        }
    }
}
