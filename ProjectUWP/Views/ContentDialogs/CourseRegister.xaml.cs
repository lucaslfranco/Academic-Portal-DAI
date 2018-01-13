using Library.BL;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class CourseRegister : ContentDialog
    {
        public Course Course = new Course();
        public School School = new School();
        ObservableCollection<School> Schools;
        
        public CourseRegister()
        {
            this.InitializeComponent();
            
            // Populate ComboBox to Schools
            Schools = new ObservableCollection<School>(School.GetAll());
            schoolComboBox.ItemsSource = Schools;
        }

        private void CourseRegisterButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {   
            //CourseDAL.CreateTable();
            
            try
            {
                Course.Name = nameTextBox.Text;
                Course.Degree = degreeTextBox.Text;
                Course.DurationYears = Int32.Parse(durationYearsTextBox.Text);
                Course.IdSchool = (int)schoolComboBox.SelectedValue;
                
                Course.Create();
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
