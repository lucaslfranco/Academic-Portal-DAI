using Library.BL;
using ProjectUWP.Views.ContentDialogs;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class StudentsView : Page
    {
        public List<Student> Students;

        public StudentsView()
        {
            this.InitializeComponent();
            Students = GetStudents();
        }

        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            Student studentDB = new Student();

            foreach (Student student in studentDB.GetAll())
            {
                students.Add(student);   
            }
            return students;
        }

        private async void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            StudentRegister studentRegister = new StudentRegister();
            await studentRegister.ShowAsync();
        }

        private void SearchStudentsBtn_Click(object sender, RoutedEventArgs e)
        {
            Students = GetStudents();
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
            Students = GetStudents();
        }

        private async void StudentDeleteOption_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = (Student) ((MenuFlyoutItem)sender).Tag;

            StudentDeleteConfirmation studentDeleteConfirm = new StudentDeleteConfirmation(selectedStudent);
            await studentDeleteConfirm.ShowAsync();
            Students = GetStudents();
        }
    }
}
