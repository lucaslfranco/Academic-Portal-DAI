using Library.BL;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class TeacherHomeView : Page
    {
        public Teacher Teacher { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public Frame ContentFrame { get; private set; }

        public TeacherHomeView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get student object from MainPage
            Object[] objects = (Object[]) e.Parameter;
            ContentFrame = (Frame) objects[0];
            Teacher = (Teacher) objects[1];

            // Get enrolled subjects to this student from database
            Subjects = GetSubjectsByTeacher();

            // Fills the data fields
            idTextBlock.Text = Teacher.Id.ToString();
            nameTextBlock.Text = Teacher.Name;
            emailTextBlock.Text = Teacher.Email;
        }
        
            public ObservableCollection<Subject> GetSubjectsByTeacher()
        {
            return new ObservableCollection<Subject>(Teacher.GetSubjectsByTeacher());
        }
    }
}
