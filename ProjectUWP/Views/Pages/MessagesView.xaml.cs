using Library.BL;
using ProjectUWP.Views.ContentDialogs;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectUWP.Views.Pages
{
    public sealed partial class MessagesView : Page
    {
        public Frame ContentFrame { get; private set; }
        public Student Student = new Student();
        public ObservableCollection<Message> Messages { get; set; }

        public MessagesView()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<Message> GetAllMessages()
        {
            return new ObservableCollection<Message>(Student.GetMessagesByStudent());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get contentFrame and student objects from MainPage
            Object[] objects = (Object[]) e.Parameter;
            ContentFrame = (Frame) objects[0];
            Student = (Student) objects[1];
            // Get all the messages for this student from database
            Messages = GetAllMessages();
        }

        private async void MessageContentButton_Click(object sender, RoutedEventArgs e)
        {
            Message selectedMessage = (Message)((Button) sender).Tag;

            MessageContentDialog messageDialog = new MessageContentDialog(selectedMessage);
            await messageDialog.ShowAsync();
        }
    }
}
