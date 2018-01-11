using Library.BL;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class SubjectView : Page
    {
        public Frame ContentFrame { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public Enrollment Enrollment = new Enrollment();

        public SubjectView()
        {
            this.InitializeComponent();
        }

        // Fills the textblocks from the first section
        public void FillInformationFields()
        {
            // Fills the data fields of first section
            idTextBlock.Text = Subject.Id.ToString();
            nameTextBlock.Text = Subject.Name;
            creditsTextBlock.Text = Subject.Credits.ToString();
            yearTextBlock.Text = Subject.Year.ToString();
            semesterTextBlock.Text = Subject.Semester.ToString();
            startTimeTextBlock.Text = Subject.StartTime.ToString("HH:mm");
            endTimeTextBlock.Text = Subject.EndTime.ToString("HH:mm");
            classesHeldTextBlock.Text = Subject.ClassesHeld.ToString();
            
            // Instantiate an object and get teacher from DB
            Teacher teacher = new Teacher
            {
                Id = Subject.IdTeacher
            };
            teacher = teacher.GetById();
            teacherTextBlock.Text = teacher.Name;

            // Instantiate an object and get course from DB
            Course course = new Course
            {
                Id = Subject.IdCourse
            };
            course = course.GetById();
            courseTextBlock.Text = course.Name;
        }

        // Fills the grades table from second section
        public void FillGradesFields()
        {
            Grades grades = new Grades();
            grades.Id = Enrollment.GetById().IdGrades;

            // Using Enrollment object, queries for grades for this student and subject
            grades = grades.GetById();

            // Fills the grades table
            grade1textBlock.Text = grades.Grade1.ToString();
            grade2textBlock.Text = grades.Grade2.ToString();
            grade3textBlock.Text = grades.Grade3.ToString();
            grade4textBlock.Text = grades.Grade4.ToString();
            
            double average = (grades.Grade1 + grades.Grade2 
                + grades.Grade3 + grades.Grade4) / 4;
            
            averageTextBlock.Text = average.ToString();
        }

        // Fills the attendance table from the second section
        public void FillAttendanceFields()
        {
            
            // Calculate attendance and attendance rate
            int attendance = Subject.ClassesHeld - Enrollment.MissedClasses;
            double attendanceRate = ((attendance / Subject.ClassesHeld) * 100);

            // Fills the attendance table
            classesHeldTextBlock2.Text = Subject.ClassesHeld.ToString();
            attendanceTextBlock.Text = attendance.ToString();
            attendanceRateTextBlock.Text = attendanceRate.ToString();

            // Set the student situation textBox
            situationTextBlock.Text = attendanceRate > 75 ? "Regular" : "Reprovado por Faltas";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get frame and subject objects from StudentHomeView
            Object[] objects = (Object[]) e.Parameter;
            ContentFrame = (Frame) objects[0];
            Student = (Student)objects[1];
            Subject = (Subject) objects[2];

            // Instantiates an Enrollment object and populate it with the IDs
            Enrollment enrollment = new Enrollment();
            enrollment.IdStudent = Student.Id;
            enrollment.IdSubject = Subject.Id;

            FillInformationFields();
            FillGradesFields();
            FillAttendanceFields();
        }

        private void BackToMainPageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Object[] objects = new Object[2];
            objects[0] = ContentFrame;
            objects[1] = Student;

            ContentFrame.Navigate(typeof(StudentHomeView), objects);
        }
    }
}
