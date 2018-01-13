using Library.BL;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class TeacherRegister : ContentDialog
    {
        public Teacher Teacher = new Teacher();
        public School School = new School();
        public ObservableCollection<School> Schools;

        public TeacherRegister()
        {
            this.InitializeComponent();
            Schools = new ObservableCollection<School>(School.GetAll());
            schoolComboBox.ItemsSource = Schools;
        }

        private void TeacherRegisterButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //TeacherDAL.CreateTable();
            
            try
            {
                Teacher.Id = Int32.Parse(idTextBox.Text);
                Teacher.Name = nameTextBox.Text;
                Teacher.Condition = conditionTextBox.Text;
                Teacher.Email = emailTextBox.Text;
                Teacher.IdSchool = (int)schoolComboBox.SelectedValue;

                Teacher.Create();
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
