using Library.BL;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class StudentHomeView : Page
    {
        public Student student;
        ObservableCollection<Subject> EnrolledSubjects;

        public StudentHomeView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get student object from MainPage
            student = (Student) e.Parameter;

            // Get enrolled subjects to this student from database
            EnrolledSubjects = GetSubjectsByStudent();

            // Fills the data fields
            idTextBlock.Text = student.Id.ToString();
            nameTextBlock.Text = student.Name;
            emailTextBlock.Text = student.Email;


        }

        public ObservableCollection<Subject> GetSubjectsByStudent()
        {
            return new ObservableCollection<Subject>(student.GetSubjectsByStudent());
        }
    }
}
