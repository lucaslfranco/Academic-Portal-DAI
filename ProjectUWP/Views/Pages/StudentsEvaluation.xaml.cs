using Library.BL;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
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
    }
}
