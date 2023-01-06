using System;
using System.ComponentModel;

namespace WpfExample.Models
{
    public class Student : INotifyPropertyChanged
    {
        private int _idStudent;

        public int IdStudent
        {
            get { return _idStudent; }
            set
            {
                _idStudent = value;
                OnPropertyChanged(nameof(IdStudent));
            }
        }

        private string _indexNumber;

        public string IndexNumber
        {
            get { return _indexNumber; }
            set
            {
                _indexNumber = value;
                OnPropertyChanged(nameof(IndexNumber));
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }


        private string _photoPath;

        public string PhotoPath
        {
            get { return _photoPath; }
            set
            {
                _photoPath = value;
                OnPropertyChanged(nameof(PhotoPath));
            }
        }


        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(City);
            }
        }


        private string _street;

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }


        private string _buildingNumber;

        public string BuildingNumber
        {
            get { return _buildingNumber; }
            set
            {
                _buildingNumber = value;
                OnPropertyChanged(nameof(BuildingNumber));
            }
        }


        private string _apartmentNumber;

        public string ApartmentNumber
        {
            get { return _apartmentNumber; }
            set
            {
                _apartmentNumber = value;
                OnPropertyChanged(nameof(ApartmentNumber));
            }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
