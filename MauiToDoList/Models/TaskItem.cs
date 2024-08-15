namespace MauiToDoList.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int ReminderMinutes { get; set; } = 0;
        public string? ImagePath { get; set; }
    }
}
