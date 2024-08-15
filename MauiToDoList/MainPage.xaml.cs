using MauiToDoList.Models;
using MauiToDoList.ViewModels;

namespace MauiToDoList
{
    public partial class MainPage : ContentPage
    {
        private TaskViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new TaskViewModel(); // Create an instance of the ViewModel
            BindingContext = _viewModel; // Set the BindingContext for data binding

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.LoadTasksAsync();
        }

        public void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var task = (sender as CheckBox).BindingContext as TaskItem;
            if (task != null)
            {
                task.IsCompleted = e.Value;
                App.DbContext.Tasks.Update(task);
                App.DbContext.SaveChanges();
            }
        }

        public async void DeleteTask(object sender, EventArgs e)
        {
            var button = sender as Button;
            var taskItem = button.BindingContext as TaskItem;
            await _viewModel.DeleteTaskAsync(taskItem.Id);
        }

        public void OnMapClicked(object sender, EventArgs e)
        {
            _viewModel.GoToMap();
        }
    }

}
