using MauiToDoList.Data;

namespace MauiToDoList
{
    public partial class App : Application
    {
        public static TaskDbContext DbContext {  get; private set; }
        public App()
        {
            InitializeComponent();

            DbContext = new TaskDbContext();
            DbContext.Database.EnsureCreated();

            MainPage = new AppShell();
        }
    }
}
