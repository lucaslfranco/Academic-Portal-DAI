using Library.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class SubjectRegister : ContentDialog
    {
        public Teacher Teacher = new Teacher();
        public Course Course = new Course(); 
        public ObservableCollection<Teacher> Teachers;
        public ObservableCollection<Course> Courses;

        public SubjectRegister()
        {
            this.InitializeComponent();
            startTimePicker.Date = DateTime.Now;
            endTimePicker.Date = DateTime.Now;

            // Populate ComboBoxes to Teachers and Courses
            Teachers = new ObservableCollection<Teacher>(Teacher.GetAll());
            Courses = new ObservableCollection<Course>(Course.GetAll());

            teacherComboBox.ItemsSource = Teachers;
            courseComboBox.ItemsSource = Courses;

        }

        private void SubjectRegisterButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //StudentDAL.CreateTable();

            Subject subject = new Subject();

            try
            {
                subject.Id = Int32.Parse(idTextBox.Text);
                subject.Name = nameTextBox.Text;
                subject.Credits = Int32.Parse(creditsTextBox.Text);
                subject.Year = Int32.Parse(yearTextBox.Text);
                subject.Semester = (int)semesterComboBox.Tag;
                
                subject.StartTime = startTimePicker.Date.DateTime;
                subject.EndTime = endTimePicker.Date.DateTime;
                subject.ClassesHeld = Int32.Parse(classesHeldTextBox.Text);

                subject.IdTeacher = (int) teacherComboBox.SelectedValue;
                subject.IdCourse = (int) courseComboBox.SelectedValue;

                subject.Create();
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
