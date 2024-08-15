using MauiToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiToDoList.Data
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
