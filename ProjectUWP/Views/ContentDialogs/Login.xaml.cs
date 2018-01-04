using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public enum UserType
    {
        Student,
        Teacher,
        Admin
    }

    public sealed partial class Login : ContentDialog
    {
        public UserType Usertype { get; set; }

        public Login()
        {
            InitializeComponent();
            EnableUserButtons(false);
        }

        private void studentButton_Click(object sender, RoutedEventArgs e)
        {
            // Set content with the ID
            this.Content = idTextBox.Text;
            // Set usertype as Student 
            this.Usertype = UserType.Student;
            // Close the ContentDialog
            Hide();

        }

        private void teacherButton_Click(object sender, RoutedEventArgs e)
        {
            // Set content with the ID
            this.Content = idTextBox.Text;
            // Set usertype as Teacher 
            this.Usertype = UserType.Teacher;
            // Close the ContentDialog
            Hide();
        }

        private void EnableUserButtons(bool value)
        {
            studentButton.IsEnabled = value;
            teacherButton.IsEnabled = value;
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
            }
        }
    }
}
