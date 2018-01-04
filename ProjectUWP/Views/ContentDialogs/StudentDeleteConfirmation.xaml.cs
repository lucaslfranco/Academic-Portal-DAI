using Library.BL;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class StudentDeleteConfirmation : ContentDialog
    {
        private Student student = null;

        public StudentDeleteConfirmation()
        {
            this.InitializeComponent();
        }

        public StudentDeleteConfirmation(Student student)
        {
            this.student = student;
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Student studentDB = this.student;
            studentDB.Delete();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
