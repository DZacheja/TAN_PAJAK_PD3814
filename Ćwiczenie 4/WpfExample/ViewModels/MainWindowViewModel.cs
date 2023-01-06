using System.Collections.ObjectModel;
using WpfExample.Models;

namespace WpfExample.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public MainWindowViewModel()
        {

        }

    }
}
