using ProjectUWP.Views.ContentDialogs;
using ProjectUWP.Views.Pages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Library.BL;

namespace ProjectUWP
{
    public enum UserType
    {
        Student,
        Teacher,
        Admin
    }

    public sealed partial class MainPage : Page
    {
        public UserType Usertype { get; set; }
        public Student Student { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CallLogin()
        {
            Login loginPage = new Login();
            await loginPage.ShowAsync();
            //If primary button is clicked by the user, so the option Student was selected
            if (UserType.Student == (UserType)loginPage.Usertype) 
            {        
                // Stores the student ID
                int LoginId = Int32.Parse(loginPage.Content.ToString());

                // Instantiate an object and get student from database
                Student = new Student() {
                    Id = LoginId
                };
                Student = Student.GetById();

                // Set user type as Student
                Usertype = UserType.Student;

                // Add NavView items to Student
                NavView.MenuItems.Clear();
                NavView.MenuItems.Add(new NavigationViewItemHeader()
                { Content = "Menu de Navigação" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Início", Icon = new SymbolIcon(Symbol.Home), Tag = "home" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Informações", Icon = new SymbolIcon(Symbol.People), Tag = "perfil" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Disciplinas", Icon = new SymbolIcon(Symbol.Library), Tag = "subjects" });
            }
            //If secondary button is clicked by the user, so the option Teacher was selected
            else if(UserType.Teacher == (UserType)loginPage.Usertype)
            {
                // Stores the teacher ID
                int id = Int32.Parse(loginPage.Content.ToString());
                // Set user type as Teacher
                Usertype = UserType.Teacher;

                // Add NavView items to Teacher
                NavView.MenuItems.Clear();
                NavView.MenuItems.Add(new NavigationViewItemHeader()
                { Content = "Menu de Navigação" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Início", Icon = new SymbolIcon(Symbol.Home), Tag = "home" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Disciplinas", Icon = new SymbolIcon(Symbol.Library), Tag = "subjectsView" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Estudantes", Icon = new SymbolIcon(Symbol.People), Tag = "students" });
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            CallLogin();
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            
            if(Usertype == UserType.Student)
            {
                switch (args.InvokedItem)
                {
                    case "home":
                        ContentFrame.Navigate(typeof(StudentHomeView), Student);
                        break;
                    case "perfil":
                        ContentFrame.Navigate(typeof(SubjectsView));
                        break;
                    case "subjects":
                        ContentFrame.Navigate(typeof(StudentsView));
                        break;
                }
            }
            else if(Usertype == UserType.Teacher)
            {
                switch (args.InvokedItem)
                {
                    case "home":
                        break;
                    case "subjectsView":
                        ContentFrame.Navigate(typeof(SubjectsView));
                        break;
                    case "students":
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

            if (Usertype == UserType.Student)
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "home":
                        ContentFrame.Navigate(typeof(StudentHomeView), Student);
                        break;
                    case "perfil":
                        ContentFrame.Navigate(typeof(SubjectsView));
                        break;
                    case "subjects":
                        ContentFrame.Navigate(typeof(StudentsView));
                        break;
                }
            }
            else if (Usertype == UserType.Teacher)
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "home":
                        break;
                    case "subjectsView":
                        ContentFrame.Navigate(typeof(SubjectsView));
                        break;
                    case "students":
                        ContentFrame.Navigate(typeof(StudentsView));
                        break;
                }
            }

        }
    
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            CallLogin();

            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
