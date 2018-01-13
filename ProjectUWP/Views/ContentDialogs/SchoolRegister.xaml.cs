using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class SchoolRegister : ContentDialog
    {
        public School School = new School();
       
        public SchoolRegister()
        {
            this.InitializeComponent();
        }

        private void SchoolRegisterButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //SchoolDAL.CreateTable();

            try
            {
                School.Name = nameTextBox.Text;
                School.PostalCode = postalCodeTextBox.Text;
                School.Phone = phoneTextBox.Text;

                School.Create();
                Hide();
            }
            catch (Exception e) { }
        }

        private void CancelButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }
    }
}
