using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class StudentUpdate : ContentDialog
    {
        private Student Student { get; set; }
        
        public StudentUpdate()
        {
            this.InitializeComponent();
        }

        public StudentUpdate(Student student)
        {
            this.Student = student;
            this.InitializeComponent();

            idTextBox.Text = student.Id.ToString();
            nameTextBox.Text = student.Name;
            birthDatePicker.Date = student.BirthDate;
            enrollDatePicker.Date = student.EnrollDate;
            countryTextBox.Text = student.Country;
            emailTextBox.Text = student.Email;
            phoneTextBox.Text = student.Phone;
        }

        private void StudentUpdate_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                Student = new Student();

                Student.Id = Int32.Parse(idTextBox.Text);
                Student.Name = nameTextBox.Text;
                Student.BirthDate = birthDatePicker.Date.DateTime;
                Student.EnrollDate = enrollDatePicker.Date.DateTime;
                Student.Country = countryTextBox.Text;
                Student.Email = emailTextBox.Text;
                Student.Phone = phoneTextBox.Text;
            
                Student.Update();
                Hide();
            }
            catch(Exception e) { }
        }

        private void StudentUpdate_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }
    }
}
