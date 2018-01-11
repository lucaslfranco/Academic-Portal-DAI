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
    public sealed partial class SubjectsView : Page
    {
        public Frame ContentFrame { get; private set; }
        public Teacher Teacher { get; private set; }
        ObservableCollection<Subject> Subjects;

        public SubjectsView()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Subject> GetSubjectsByTeacher()
        {            
            return new ObservableCollection<Subject>(Teacher.GetSubjectsByTeacher());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get contentFrame and teacher objects from MainPage
            Object[] objects = (Object[]) e.Parameter;
            ContentFrame = (Frame) objects[0];
            Teacher = (Teacher) objects[1];
           
            // Get all the messages for this teacher from database
            Subjects = GetSubjectsByTeacher();
        }

        private void SubjectMoreOptions_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private async void SendMessageOption_Click(object sender, RoutedEventArgs e)
        {
            Subject selectedSubject = (Subject)((MenuFlyoutItem)sender).Tag;

            MessageRegister messageRegister = new MessageRegister(selectedSubject);
            await messageRegister.ShowAsync();
        }

        private void ListStudentsOption_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(StudentsView));
        }
    }
}
