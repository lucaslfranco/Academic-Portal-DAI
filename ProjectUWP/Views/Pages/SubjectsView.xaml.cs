using Library.BL;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.Pages
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
    }
}
