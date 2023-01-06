using System.ComponentModel;
using WpfExample.Models;

namespace WpfExample.ViewModels
{
    public class AddStudentViewModel : INotifyPropertyChanged
    {
        private Student _student = new Student();
        private bool _status = true;
        public Student Student
        {
            get { return _student; }
            set
            {
                _student = value;
                NotifyPropertyChanged(nameof(Student));
            }
        }

        public bool Status
        {
            get { return _status; }
            set {
                _status = value;
                if (value)
                {
                    Student.Status = "Aktywny";
                }
                else{
                    Student.Status = "Skreślony";
                }
                NotifyPropertyChanged(nameof(Status));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
