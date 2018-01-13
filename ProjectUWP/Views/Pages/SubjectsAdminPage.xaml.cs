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
    public sealed partial class SubjectsAdminPage : Page
    {
        public Frame ContentFrame { get; private set; }
        public Subject Subject = new Subject();
        ObservableCollection<Subject> Subjects;

        public SubjectsAdminPage()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Subject> GetSubjects()
        {
            return new ObservableCollection<Subject>(Subject.GetAll());
        }

        public void UpdateListView()
        {
            Subjects = GetSubjects();
            subjectsListView.ItemsSource = Subjects;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get contentFrame and teacher objects from MainPage
            ContentFrame = (Frame) e.Parameter;

            // Get all the subjects from database
            Subjects = GetSubjects();
        }

        private void SubjectMoreOptions_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private void ListStudentsOption_Click(object sender, RoutedEventArgs e)
        {
            Subject selectedSubject = (Subject)((MenuFlyoutItem)sender).Tag;

            Object[] objects = new Object[2];
            objects[0] = ContentFrame;
            objects[1] = selectedSubject;

            ContentFrame.Navigate(typeof(StudentsEvaluation), objects);
        }
        private void DeleteSubjectOption_Click(object sender, RoutedEventArgs e)
        {
            Subject selectedSubject = (Subject)((MenuFlyoutItem)sender).Tag;
            selectedSubject.Delete();
            UpdateListView();
        }

        private async void AddSchoolButton_Click(object sender, RoutedEventArgs e)
        {
            SchoolRegister schoolRegister = new SchoolRegister();

            await schoolRegister.ShowAsync();
            UpdateListView();
        }

        private async void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            CourseRegister courseRegister = new CourseRegister();

            await courseRegister.ShowAsync();
            UpdateListView();
        }

        private async void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            TeacherRegister teacherRegister = new TeacherRegister();

            await teacherRegister.ShowAsync();
            UpdateListView();
        }

        private async void AddSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectRegister subjectRegister = new SubjectRegister();

            await subjectRegister.ShowAsync();
            UpdateListView();
        }
    }
}
