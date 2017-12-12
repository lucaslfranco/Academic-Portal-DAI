using Library.BL;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
    }
}
