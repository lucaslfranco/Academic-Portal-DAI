using Library.BL;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class CourseRegister : ContentDialog
    {
        public School School = new School();
        ObservableCollection<School> Schools;
        
        public CourseRegister()
        {
            this.InitializeComponent();
            Schools = new ObservableCollection<School>(School.GetAll());
        }

        private void CourseRegisterButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void CancelButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
