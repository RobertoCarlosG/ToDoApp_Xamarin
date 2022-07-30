using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoList.App.View;
using ToDoList.App.Data;

namespace ToDoList.App
{
    public partial class App : Application
    {
        public static DataBaseContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            MainPage = new NavigationPage(new HomePage());
        }

        private void InitializeDatabase()
        {
            string folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbPath = System.IO.Path.Combine(folderApp, "ToDo.db3");
            Context = new DataBaseContext(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
