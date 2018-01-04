using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectViewUWP.StudentPages
{
    public sealed partial class StudentRegister : ContentDialog
    {
        public StudentRegister()
        {
            this.InitializeComponent();
        }

        private void StudentRegister_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //StudentDAL.CreateTable();

            Student student = new Student();

            student.Id = Int32.Parse(idTextBox.Text);
            student.Name = nameTextBox.Text;
            student.BirthDate = new DateTime(1996, 10, 20);
            student.EnrollDate = new DateTime(2017, 10, 5);
            student.Country = countryTextBox.Text;
            student.Email = emailTextBox.Text;
            student.Phone = phoneTextBox.Text;

            student.Create();
        }

        private void StudentRegister_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
