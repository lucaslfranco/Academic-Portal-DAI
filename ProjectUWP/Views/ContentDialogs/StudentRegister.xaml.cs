using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class StudentRegister : ContentDialog
    {
        public StudentRegister()
        {
            this.InitializeComponent();
            birthDatePicker.Date = DateTime.Now;
            enrollDatePicker.Date = DateTime.Now;
        }

        private void StudentRegister_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //StudentDAL.CreateTable();

            Student student = new Student();

            try
            {
                student.Id = Int32.Parse(idTextBox.Text);
                student.Name = nameTextBox.Text;
                student.BirthDate = birthDatePicker.Date.DateTime;
                student.EnrollDate = enrollDatePicker.Date.DateTime;
                student.Country = countryTextBox.Text;
                student.Email = emailTextBox.Text;
                student.Phone = phoneTextBox.Text;

                student.Create();
                Hide();
            }
            catch (Exception e) { }

        }

        private void StudentRegister_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }
    }
}
