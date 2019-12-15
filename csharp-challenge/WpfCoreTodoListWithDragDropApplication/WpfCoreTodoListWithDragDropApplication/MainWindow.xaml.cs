using System;
using System.Collections.Generic;
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

using WpfCoreTodoListWithDragDropApplication.Models;

namespace WpfCoreTodoListWithDragDropApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TodoItem> TodoList { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            TodoList = new List<TodoItem>
            {
                new TodoItem { Title = "First Item", IsComplete = true },
                new TodoItem { Title = "Next Item", IsComplete = false }
            };

            DataContext = TodoList;
        }
    }
}
