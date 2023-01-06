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
using System.Windows.Shapes;
using WpfExample.Interfaces;
using WpfExample.Models;
using WpfExample.ViewModels;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window, IAddStudentDialog
    {
        private AddStudentViewModel _viewModel;

        public AddStudentWindow()
        {
            InitializeComponent();
            _viewModel = new AddStudentViewModel();
            DataContext = _viewModel;
        }

        public Student GetStudent()
        {
            return _viewModel.Student;
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Student = null;
            Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
