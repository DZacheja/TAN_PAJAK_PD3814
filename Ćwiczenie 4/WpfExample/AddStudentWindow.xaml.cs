using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

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
            _viewModel.Student.IdStudent = MainWindow.currentIndex + 1;
            MainWindow.currentIndex++;
            Close();
        }

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Images (*.jpg)|*.jpg";
            fileDialog.RestoreDirectory = true;
            fileDialog.Multiselect = false;
            if(fileDialog.ShowDialog() == true)
            {
                string newFileName = Path.GetFileName(fileDialog.FileName);
                newFileName = Path.Combine(Environment.CurrentDirectory,"Images", newFileName);
                try
                {
                    File.Copy(fileDialog.FileName, newFileName);
                    _viewModel.Student.PhotoPath = newFileName;
                }catch {
                    MessageBox.Show("Nie udało się skopiować pliku do folderu z programem.");
                }

            }
        }
    }
}
