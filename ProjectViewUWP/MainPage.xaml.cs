using ProjectViewUWP.StudentPages;
using ProjectViewUWP.SubjectsPages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectViewUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                switch (args.InvokedItem)
                {
                    case "homePage":
                        break;
                    case "subjectsView":
                        ContentFrame.Navigate(typeof(SubjectsView));
                        break;
                    case "studentsView":
                        ContentFrame.Navigate(typeof(StudentsView));
                        break;
                }
            }
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "homePage":
                        break;
                    case "subjectsView":
                        ContentFrame.Navigate(typeof(SubjectsView));
                        break;
                    case "studentsView":
                        ContentFrame.Navigate(typeof(StudentsView));
                        break;
                }
            }

        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "subjectsView")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
