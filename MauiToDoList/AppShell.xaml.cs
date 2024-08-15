namespace MauiToDoList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreateTaskPage), typeof(CreateTaskPage));
            Routing.RegisterRoute(nameof(Map), typeof(Map));
        }
    }
}
