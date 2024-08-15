using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiToDoList.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        private ObservableCollection<TaskItem> _tasks;
        public ObservableCollection<TaskItem> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public TaskViewModel()
        {
            LoadTasksAsync().Wait();
            AddTaskCommand = new Command(OnAddTask);


            // Subscribe to messages if needed
            MessagingCenter.Subscribe<CreateTaskViewModel>(this, "TaskAdded", (sender) =>
            {
                LoadTasksAsync().Wait();
            });
        }

        public async Task LoadTasksAsync()
        {
            var tasksFromDb = await App.DbContext.Tasks.ToListAsync();
            Tasks = new ObservableCollection<TaskItem>(tasksFromDb);
        }

        private async void OnAddTask()
        {
            // Navigate to the CreateTaskPage
            await Shell.Current.GoToAsync(nameof(CreateTaskPage));
        }

        public async Task DeleteTaskAsync(int Id)
        {
            var task = await App.DbContext.Tasks.FirstOrDefaultAsync(x => x.Id == Id);
            if (task is not null)
            {
                App.DbContext.Tasks.Remove(task);
                await App.DbContext.SaveChangesAsync();

                this.Tasks.Remove(this.Tasks.FirstOrDefault(x => x.Id == Id));
            }
        }

        // Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GoToMap()
        {
            Shell.Current.GoToAsync(nameof(Map));
        }
    }

}
