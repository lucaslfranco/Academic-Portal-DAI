using Library.BL;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectViewUWP.SubjectsPages
{
    public sealed partial class SubjectsView : Page
    {
        public List<Subject> Subjects;

        public SubjectsView()
        {
            this.InitializeComponent();
            Subjects = GetSubjects();
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            Subject subjectDB = new Subject();

            foreach (Subject subject in subjectDB.GetAll())
            {
                subjects.Add(subject);
            }
            return subjects;
        }

        private void SearchSubjectsBtn_Click(object sender, RoutedEventArgs e)
        {
            Subjects = GetSubjects();
        }
    }
}
