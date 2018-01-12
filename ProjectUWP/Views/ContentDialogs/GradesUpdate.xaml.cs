using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class GradesUpdate : ContentDialog
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Enrollment Enrollment { get; set; }
        public Grades Grades = new Grades();

        public GradesUpdate() { }

        public GradesUpdate(Subject subject, Student student)
        {
            this.InitializeComponent();
            Subject = subject;
            Student = student;
            FillGradeFields();
        }
        
        private void FillGradeFields()
        {
            Enrollment = new Enrollment
            {
                IdSubject = Subject.Id,
                IdStudent = Student.Id
            };

            Enrollment = Enrollment.GetById();
            Grades.Id = Enrollment.IdGrades;
            Grades = Grades.GetById();

            studentNameTextBlock.Text = Student.Name;
            grade1TextBox.Text = Grades.Grade1.ToString();
            grade2TextBox.Text = Grades.Grade2.ToString();
            grade3TextBox.Text = Grades.Grade3.ToString();
            grade4TextBox.Text = Grades.Grade4.ToString();
            absenceTextBox.Text = Enrollment.MissedClasses.ToString();
        }

        private void UpdateButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // Ternary Operators to assign only valid values to grades
            Grades.Grade1 = grade1TextBox.Text != "" ? Double.Parse(grade1TextBox.Text) : Grades.Grade1;
            Grades.Grade2 = grade2TextBox.Text != "" ? Double.Parse(grade2TextBox.Text) : Grades.Grade2;
            Grades.Grade3 = grade3TextBox.Text != "" ? Double.Parse(grade3TextBox.Text) : Grades.Grade3;
            Grades.Grade4 = grade4TextBox.Text != "" ? Double.Parse(grade4TextBox.Text) : Grades.Grade4;
            Grades.Update();

            if((absenceTextBox.Text != "") && (Enrollment.MissedClasses != Int32.Parse(absenceTextBox.Text)))
            {
                Enrollment.MissedClasses = Int32.Parse(absenceTextBox.Text);
                Enrollment.Update();
            }
        }

        private void CancelButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }
    }
}
