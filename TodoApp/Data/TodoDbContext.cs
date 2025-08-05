using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        private string _dbPath;

        public DbSet<TodoItem> TodoItems { get; set; }

        // Constructor para tiempo de ejecución (MAUI)
        public TodoDbContext()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = System.IO.Path.Combine(folder, "todo.db");
        }

        // Constructor para tiempo de diseño (migraciones)
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Solo configurar si no fue configurado externamente
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Filename={_dbPath}");
            }
        }
    }
}