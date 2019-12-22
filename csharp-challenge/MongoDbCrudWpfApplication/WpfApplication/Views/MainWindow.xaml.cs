using System.Windows;

using WpfApplication.ViewModels;

namespace WpfApplication.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new PersonViewModel();
        }
    }
}
