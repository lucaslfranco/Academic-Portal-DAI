using Library.BL;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectViewUWP.SubjectsPages
{
    public sealed partial class SubjectsView : Page
    {
        ObservableCollection<Subject> Subjects;

        public SubjectsView()
        {
            this.InitializeComponent();
            Subjects = GetSubjects();
        }

        public ObservableCollection<Subject> GetSubjects()
        {
            Subject subjectDB = new Subject();
            
            ObservableCollection<Subject> subjects = new ObservableCollection<Subject>(subjectDB.GetAll());

            return subjects;
        }

        private void SearchSubjectsBtn_Click(object sender, RoutedEventArgs e)
        {
            Subjects = GetSubjects();
        }
    }
}
