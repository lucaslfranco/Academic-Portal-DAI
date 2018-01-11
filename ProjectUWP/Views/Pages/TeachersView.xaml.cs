using Library.BL;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class TeachersView : Page
    {
        public Frame ContentFrame { get; private set; }
        public Teacher Teacher = new Teacher();
        public ObservableCollection<Teacher> Teachers { get; set; }

        public TeachersView()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return new ObservableCollection<Teacher>(Teacher.GetAll());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get contentFrame object from MainPage
            ContentFrame = (Frame) e.Parameter;

            // Get all the teachers from database
            Teachers = GetAllTeachers();
        }
    }
}
