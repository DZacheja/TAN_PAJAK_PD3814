using System.ComponentModel;
using WpfExample.Models;

namespace WpfExample.ViewModels
{
    public class AddStudentViewModel : INotifyPropertyChanged
    {
        private Student _student = new Student();

        public Student Student
        {
            get { return _student; }
            set
            {
                _student = value;
                NotifyPropertyChanged(nameof(Student));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
