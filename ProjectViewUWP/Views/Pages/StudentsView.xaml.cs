using Library.BL;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace ProjectViewUWP.StudentPages
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
            Students = GetStudents();
        }

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
        }

        private void StudentEditOption_Click(object sender, RoutedEventArgs e)  
        {

        }

        private void StudentDeleteOption_Click(object sender, RoutedEventArgs e)
        {
            StudentDeleteConfirmation student = new StudentDeleteConfirmation();

            //Student student = (Student) ((Button)sender).Tag;
            //student.Delete();
        }
    }
}
