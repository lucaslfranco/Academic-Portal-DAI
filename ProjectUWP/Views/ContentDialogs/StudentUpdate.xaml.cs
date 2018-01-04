using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class StudentUpdate : ContentDialog
    {
        private Student student = null;
        
        public StudentUpdate()
        {
            this.InitializeComponent();
        }

        public StudentUpdate(Student student)
        {
            this.student = student;
            this.InitializeComponent();

            idTextBox.Text = student.Id.ToString();
            nameTextBox.Text = student.Name;
            birthDateTextBox.Text = student.BirthDate.ToString("d");
            enrollDateTextBox.Text = student.EnrollDate.ToString("d");
            countryTextBox.Text = student.Country;
            emailTextBox.Text = student.Email;
            phoneTextBox.Text = student.Phone;
        }

        private void StudentUpdate_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //StudentDAL.CreateTable();

            Student student = new Student
            {
                Id = Int32.Parse(idTextBox.Text),
                Name = nameTextBox.Text,
                BirthDate = new DateTime(1996, 10, 20),
                EnrollDate = new DateTime(2017, 10, 5),
                Country = countryTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            student.Update();
        }

        private void StudentUpdate_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
