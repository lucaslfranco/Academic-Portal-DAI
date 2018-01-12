using Library.BL;
using ProjectUWP.Views.ContentDialogs;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class StudentsEvaluation : Page
    {
        public Subject Subject { get; set; }
        public Frame ContentFrame { get; private set; }
        public ObservableCollection<Student> Students { get; set; }

        public StudentsEvaluation()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Student> GetStudentsBySubject()
        {
            return new ObservableCollection<Student>(Subject.GetStudentsBySubject());
        }

        private void UpdateListView()
        {
            Students = GetStudentsBySubject();
            studentsListView.ItemsSource = Students;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get contentFrame and subject objects
            Object[] objects = (Object[]) e.Parameter;
            ContentFrame = (Frame) objects[0];
            Subject = (Subject) objects[1];
            this.subjectNameTextBlock.Text = Subject.Name;

            // Get all the students for this subject from database
            Students = GetStudentsBySubject();
        }

        private void StudentMoreOptions_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private async void StudentGradesUpdate_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Student selectedStudent = (Student)((MenuFlyoutItem)sender).Tag;
            GradesUpdate gradesUpdate = new GradesUpdate(Subject, selectedStudent);
            await gradesUpdate.ShowAsync();
            UpdateListView();
        }

        private async void AddEnrollmentButton_Click(object sender, RoutedEventArgs e)
        {
            EnrollmentDialog enrollmentDialog = new EnrollmentDialog(Subject);
            await enrollmentDialog.ShowAsync();
            UpdateListView();
        }
    }
}
