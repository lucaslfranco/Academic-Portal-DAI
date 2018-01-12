using Library.BL;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public enum UserType
    {
        Student,
        Teacher,
        Admin,
        NoType
    }

    public sealed partial class Login : ContentDialog
    {
        public UserType Usertype = UserType.NoType;
        public Student Student = new Student();
        public Teacher Teacher = new Teacher();

        public Login()
        {
            InitializeComponent();
            EnableUserButtons(false);
        }

        private void DisplayErrorMessage(String errorMessage)
        {
            errorTextBlock.Text = errorMessage;
            errorTextBlock.Visibility = Visibility.Visible;
            idTextBox.Text = "";
            passwordTextBox.Password = "";
        }

        private void studentButton_Click(object sender, RoutedEventArgs e)
        {
            // Set user type as Student 
            this.Usertype = UserType.Student;

            // Set Student ID, instantiate an object and get student from database
            try
            {
                Student.Id = Int32.Parse(idTextBox.Text);
                Student StudentFromDB = Student.GetById();

                // Simulate a authentication with a static value for password
                if (passwordTextBox.Password.CompareTo("student321") == 0)
                {                    
                    if (StudentFromDB != null)
                    {
                        // Set content with the student object
                        this.Content = StudentFromDB;

                        // Close the ContentDialog
                        this.Hide();
                    }
                    else
                    {
                        DisplayErrorMessage("Aluno Não Cadastrado!");
                    }
                }
                else
                {
                    DisplayErrorMessage("Aluno Não Cadastrado ou Senha Inválida!");
                }
            }
            catch(FormatException fe)
            {
                DisplayErrorMessage("O Código deve ser um número inteiro!");
            }
        }

        private void teacherButton_Click(object sender, RoutedEventArgs e)
        {
            // Set user type as Teacher 
            this.Usertype = UserType.Teacher;

            try
            {
                // Set Teacher ID, instantiate an object and get teacher from database
                Teacher.Id = Int32.Parse(idTextBox.Text);
                Teacher TeacherFromDB = Teacher.GetById();

                if(passwordTextBox.Password.CompareTo("teacher321") == 0)
                {

                    if (TeacherFromDB != null)
                    {
                        // Set content with the teacher object
                        this.Content = TeacherFromDB;

                        // Close the ContentDialog
                        this.Hide();
                    }
                    else
                    {
                        DisplayErrorMessage("Professor Não Cadastrado!");
                    }
                }
                else
                {
                    DisplayErrorMessage("Professor Não Cadastrado ou Senha Inválida!");
                }
            }
            catch(FormatException fe)
            {
                DisplayErrorMessage("O Código Deve Ser Um Número Inteiro!");
            }
        }
        
        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            this.Usertype = UserType.Admin;
            Hide();
        }

        private void EnableUserButtons(bool value)
        {
            studentButton.IsEnabled = teacherButton.IsEnabled = value;
        }

        private void idTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        { 
            if (idTextBox.Text.Length == 0)
            {
                EnableUserButtons(false);
            }
            else
            {
                EnableUserButtons(true);
                errorTextBlock.Visibility = Visibility.Collapsed;
            }
        }
    }
}
