

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
//using Microsoft.Maui.Controls;
using MauiToDoList.Models;

using System;
using System.Threading.Tasks;
#if WINDOWS
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Media.MediaProperties;
#elif ANDROID
using Android.App;
using Android.Content;
using Android.Provider;
using AndroidX.Core.Content;
using AndroidX.Core.App;
using Android.OS;
#endif

namespace MauiToDoList.ViewModels
{
    public class CreateTaskViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private DateTime _dueDate = DateTime.Now;
        private TimeSpan _dueTime;
        private int _reminderMinutes;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSaveEnabled));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan DueTime
        {
            get => _dueTime;
            set
            {
                _dueTime = value;
                OnPropertyChanged();
            }
        }

        public int ReminderMinutes
        {
            get => _reminderMinutes;
            set
            {
                _reminderMinutes = value;
                OnPropertyChanged();
            }
        }

        public bool IsSaveEnabled => !string.IsNullOrWhiteSpace(Title);

        public ICommand SaveTaskCommand { get; }

        public CreateTaskViewModel()
        {
            SaveTaskCommand = new Command(OnSaveTask, () => IsSaveEnabled);
        }

        private async void OnSaveTask()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                // Display validation error
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Validation Error", "Title is required.", "OK");
                return;
            }

            var newTask = new TaskItem
            {
                Title = Title,
                Description = Description,
                DueDate = DueDate.Date.Add(DueTime),
                IsCompleted = false,
                ReminderMinutes = ReminderMinutes
            };

            // Save to the database
            App.DbContext.Tasks.Add(newTask);
            await App.DbContext.SaveChangesAsync();

            // Navigate back to the MainPage
            await Shell.Current.GoToAsync("//MainPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

