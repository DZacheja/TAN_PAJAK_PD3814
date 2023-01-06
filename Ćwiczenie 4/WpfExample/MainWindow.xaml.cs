using System;
using System.IO;
using System.Windows;
using WpfExample.Models;
using WpfExample.ViewModels;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public static int currentIndex;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            _viewModel.Students.Add(new Student
            {
                IdStudent = 1,
                IndexNumber = "s1234",
                FirstName = "John",
                LastName = "Smith",
                Status = "Skreślony",
                BirthDate = new DateTime(1980, 12, 20),
                PhotoPath = Path.Combine(Environment.CurrentDirectory,"Images","photo1.jpg"),
            });
            _viewModel.Students.Add(new Student
            {
                IdStudent = 2,
                IndexNumber = "s1422",
                FirstName = "Andrzej",
                LastName = "Malewski",
                Status = "Aktywny",
                BirthDate = new DateTime(1982, 5, 10),
                PhotoPath = Path.Combine(Environment.CurrentDirectory, "Images", "photo2.jpg"),
            });
            _viewModel.Students.Add(new Student
            {
                IdStudent = 3,
                IndexNumber = "s5422",
                FirstName = "Krzysztof",
                LastName = "Kowalewicz",
                Status = "Skreślony",
                BirthDate = new DateTime(1991, 8, 5),
                PhotoPath = Path.Combine(Environment.CurrentDirectory, "Images", "photo3.jpg"),
            });
            _viewModel.Students.Add(new Student
            {
                IdStudent = 4,
                IndexNumber = "s5322",
                FirstName = "Marcin",
                LastName = "Maciejewski",
                Status = "Aktywny",
                BirthDate = new DateTime(1985, 9, 20),
            });

            currentIndex = 4;
        }

        private void DodajStudentaButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddStudentWindow();
            dialog.ShowDialog();

            var st = dialog.GetStudent();
            if (st != null)
            {
                _viewModel.Students.Add(st);
            }
        }
    }
}
