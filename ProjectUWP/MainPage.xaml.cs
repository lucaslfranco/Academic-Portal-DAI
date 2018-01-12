using Library.BL;
using ProjectUWP.Views.ContentDialogs;
using ProjectUWP.Views.Pages;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectUWP
{
    public enum UserType
    {
        Student,
        Teacher,
        Admin,
        NoType
    }

    public sealed partial class MainPage : Page
    {
        public UserType Usertype { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        private Login loginPage;

        public MainPage()
        {
            this.InitializeComponent();
        }

        // Populate and return an array with ContentFrame and an object (Student or Teacher) to send to another pages
        private Object[] ObjectsToSendOnNavigate(Object obj)
        {
            Object[] objects = new Object[2];
            objects[0] = ContentFrame;
            objects[1] = obj;
            return objects;
        }

        private async void CallLogin()
        {
            // Reset the user type
            Usertype = UserType.NoType;
            
            // Call an asynchronous instance of login page
            loginPage = new Login();
            await loginPage.ShowAsync();

            //If primary button is clicked by the user, so the option Student was selected
            if (UserType.Student == (UserType)loginPage.Usertype) 
            {        
                // Stores the student object obtained from the login page
                Student = (Student) loginPage.Content;
              
                // Set user type as Student
                Usertype = UserType.Student;

                // Add NavView items to Student
                NavView.MenuItems.Clear();
                NavView.MenuItems.Add(new NavigationViewItemHeader()
                { Content = "Portal do Aluno"});
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Início", Icon = new SymbolIcon(Symbol.Home), Tag = "home" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Perfil", Icon = new SymbolIcon(Symbol.ContactInfo), Tag = "perfil" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Professores", Icon = new SymbolIcon(Symbol.People), Tag = "teachersView" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Avisos", Icon = new SymbolIcon(Symbol.Message), Tag = "messagesView" });

                ContentFrame.Navigate(typeof(StudentHomeView), ObjectsToSendOnNavigate(Student));
            }
            //If secondary button is clicked by the user, so the option Teacher was selected
            else if(UserType.Teacher == (UserType)loginPage.Usertype)
            {
                // Stores the teacher ID
                Teacher = (Teacher) loginPage.Content;
                // Set user type as Teacher
                Usertype = UserType.Teacher;

                // Add NavView items to Teacher
                NavView.MenuItems.Clear();
                NavView.MenuItems.Add(new NavigationViewItemHeader()
                { Content = "Portal do Professor" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Início", Icon = new SymbolIcon(Symbol.Home), Tag = "home" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Disciplinas", Icon = new SymbolIcon(Symbol.Library), Tag = "subjectsView" });

                ContentFrame.Navigate(typeof(TeacherHomeView), ObjectsToSendOnNavigate(Teacher));
            }
            else if(UserType.Admin == (UserType)loginPage.Usertype)
            {
                // Set user type as Admin
                Usertype = UserType.Admin;

                // Add NavView items to Admin
                NavView.MenuItems.Clear();
                NavView.MenuItems.Add(new NavigationViewItemHeader()
                { Content = "Portal do Admin" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Alunos", Icon = new SymbolIcon(Symbol.People), Tag = "studentsView" });
                NavView.MenuItems.Add(new NavigationViewItem()
                { Content = "Matriculas", Icon = new SymbolIcon(Symbol.Library), Tag = "subjectsAdminPage" });

                ContentFrame.Navigate(typeof(SubjectsAdminPage), ContentFrame);
            }            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {            
            //Call login page
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
                        ContentFrame.Navigate(typeof(StudentHomeView), ObjectsToSendOnNavigate(Student));
                        break;
                    case "perfil":
                        ContentFrame.Navigate(typeof(StudentsView));
                        break;
                    case "teachersView":
                        ContentFrame.Navigate(typeof(TeachersView), ContentFrame);
                        break;
                    case "messagesView":
                        ContentFrame.Navigate(typeof(MessagesView), ObjectsToSendOnNavigate(Student));
                        break;
                   }
            }
            else if(Usertype == UserType.Teacher)
            {
                switch (args.InvokedItem)
                {
                    case "home":
                        ContentFrame.Navigate(typeof(TeacherHomeView), ObjectsToSendOnNavigate(Teacher));
                        break;
                    case "subjectsView":
                        ContentFrame.Navigate(typeof(SubjectsView), ObjectsToSendOnNavigate(Teacher));
                        break;
                }
            }
            else if(Usertype == UserType.Admin)
            {
                switch (args.InvokedItem)
                {
                    case "subjectsAdminPage":
                        ContentFrame.Navigate(typeof(SubjectsAdminPage), ContentFrame);
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

            if (Usertype == UserType.Student)
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                
                if(item != null)
                { 
                    switch (item.Tag)
                    {
                        case "home":
                            ContentFrame.Navigate(typeof(StudentHomeView), ObjectsToSendOnNavigate(Student));
                            break;
                        case "perfil":
                            ContentFrame.Navigate(typeof(StudentsView));
                            break;
                        case "teachersView":
                            ContentFrame.Navigate(typeof(TeachersView), ContentFrame);
                            break;
                        case "messagesView":
                            ContentFrame.Navigate(typeof(MessagesView), ObjectsToSendOnNavigate(Student));
                            break;
                    }
                }
            }
            else if (Usertype == UserType.Teacher)
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                if (item != null)
                {
                    switch (item.Tag)
                    {
                        case "home":
                            ContentFrame.Navigate(typeof(TeacherHomeView), ObjectsToSendOnNavigate(Teacher));
                            break;
                        case "subjectsView":
                            ContentFrame.Navigate(typeof(SubjectsView), ObjectsToSendOnNavigate(Teacher));
                            break;
                    }
                }
            }
            else if (Usertype == UserType.Admin)
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                if (item != null)
                {
                    switch (item.Tag)
                    {
                        case "subjectsAdminPage":
                            ContentFrame.Navigate(typeof(SubjectsAdminPage), ContentFrame);
                            break;
                        case "studentsView":
                            ContentFrame.Navigate(typeof(StudentsView));
                            break;
                    }
                }
            }
        }
    
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // Call login method
            CallLogin();

            // Set selected item
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
