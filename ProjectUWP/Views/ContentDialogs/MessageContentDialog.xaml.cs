using Library.BL;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP.Views.ContentDialogs
{
    public sealed partial class MessageContentDialog : ContentDialog
    {
        public Message Message { get; set; }

        public MessageContentDialog() { }

        public MessageContentDialog(Message message)
        {
            this.Message = message;
            this.InitializeComponent();
            this.Title = Message.Title;
            this.dateTextBlock.Text = Message.Time.ToString("dd/MM/yyyy HH:mm");
            this.contentTextBlock.Text = Message.Content;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
