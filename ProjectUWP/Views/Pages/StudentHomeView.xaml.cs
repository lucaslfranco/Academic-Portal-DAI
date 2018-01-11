using Library.BL;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class StudentHomeView : Page
    {
        public Frame ContentFrame { get; set; }
        public Student Student { get; set; }
        ObservableCollection<Subject> EnrolledSubjects { get; set; }
        
        public StudentHomeView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get student object from MainPage
            Object[] objects = (Object[]) e.Parameter;
            ContentFrame = (Frame) objects[0];
            Student = (Student) objects[1];

            // Get enrolled subjects to this student from database
            EnrolledSubjects = GetSubjectsByStudent();

            // Fills the data fields
            idTextBlock.Text = Student.Id.ToString();
            nameTextBlock.Text = Student.Name;
            emailTextBlock.Text = Student.Email;
        }

        public ObservableCollection<Subject> GetSubjectsByStudent()
        {
            return new ObservableCollection<Subject>(Student.GetSubjectsByStudent());
        }

        private void SubjectViewButton_Click(object sender, RoutedEventArgs e)
        {
            Object[] objects = new Object[3];

            Subject subject = (Subject)((Button)sender).Tag;
            objects[0] = ContentFrame;
            objects[1] = Student;
            objects[2] = subject;
            
            ContentFrame.Navigate(typeof(SubjectView), objects);
        }
    }
}
