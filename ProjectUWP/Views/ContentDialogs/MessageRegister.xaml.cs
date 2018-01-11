using Library.BL;
using System;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class MessageRegister : ContentDialog
    {
        public Subject Subject { get; set; }
        public Message Message { get; set; }

        public MessageRegister(){ }

        public MessageRegister(Subject subject)
        {
            this.InitializeComponent();
            this.Subject = subject;
            IsPrimaryButtonEnabled = false;
        }

        private void SendMessageButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Message = new Message
            {
                Title = titleTextBox.Text,
                Content = contentTextBox.Text,
                Time = DateTime.Now,
                IdSubject = Subject.Id
            };

            Message.Create();
        }

        private void CancelButton_Click(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void EnableButton(bool value)
        {
        }
        
        private void contentTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (titleTextBox.Text.Length == 0 || contentTextBox.Text.Length == 0)
            {
                IsPrimaryButtonEnabled = false;
            }
            else
            {
                IsPrimaryButtonEnabled = true;
            }

        }
    }
}
