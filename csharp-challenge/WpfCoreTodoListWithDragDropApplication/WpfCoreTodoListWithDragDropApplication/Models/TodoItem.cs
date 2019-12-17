using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfCoreTodoListWithDragDropApplication.Models
{
    public class TodoItem : INotifyPropertyChanged
    {
        private string TitleValue;
        private bool IsCompleteValue = false;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get => TitleValue;

            set
            {
                TitleValue = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsComplete
        {
            get => IsCompleteValue;

            set
            {
                IsCompleteValue = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
