using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class EnrollmentDialog : ContentDialog
    {
        public Subject Subject { get; set; }
        public Student Student = new Student();

        public EnrollmentDialog(){ }

        public EnrollmentDialog(Subject subject)
        {
            this.InitializeComponent();
            this.Subject = subject;
        }

        private void EnrollmentButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.IdSubject = Subject.Id;
            enrollment.IdStudent = Student.Id;

            Grades grades = new Grades();
            grades.Grade1 = 0.0;
            int idNewGrades = grades.Create();

            enrollment.IdGrades = idNewGrades;
            try
            {
                enrollment.Create();
                Hide();
            }
            catch (Exception e) { }
        }

        private void CancelButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }

        private void SearchStudentButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(idTextBox.Text != "")
            {
                Student.Id = Int32.Parse(idTextBox.Text);
                Student studentFromDB = Student.GetById();

                if (studentFromDB != null)
                {
                    Student = studentFromDB;
                    nameTextBox.Text = Student.Name;
                }
            }
        }
    }
}
