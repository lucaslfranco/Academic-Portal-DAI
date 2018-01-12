using Library.BL;
using ProjectUWP.Views.ContentDialogs;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class StudentsView : Page
    {
        public Student Student = new Student();
        public ObservableCollection<Student> Students;

        public StudentsView()
        {
            this.InitializeComponent();
            Students = GetStudents();
        }

        public ObservableCollection<Student> GetStudents()
        {
            return new ObservableCollection<Student>(Student.GetAll());
        }

        public void UpdateListView()
        {
            Students = GetStudents();
            studentsListView.ItemsSource = Students;
        }

        private async void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            StudentRegister studentRegister = new StudentRegister();
            await studentRegister.ShowAsync();
            UpdateListView();
        }

        private void StudentMoreOptions_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private async void StudentUpdateOption_Click(object sender, RoutedEventArgs e)  
        {
            Student selectedStudent = (Student)((MenuFlyoutItem)sender).Tag;

            StudentUpdate studentUpdate = new StudentUpdate(selectedStudent);
            await studentUpdate.ShowAsync();
            UpdateListView();
        }

        private async void StudentDeleteOption_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = (Student) ((MenuFlyoutItem)sender).Tag;

            StudentDeleteConfirmation studentDeleteConfirm = new StudentDeleteConfirmation(selectedStudent);
            await studentDeleteConfirm.ShowAsync();
            UpdateListView();
        }
    }
}
