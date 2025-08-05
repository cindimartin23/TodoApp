using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TodoApp.Data;

namespace TodoApp.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folder, "todo.db");

            optionsBuilder.UseSqlite($"Filename={dbPath}", b =>
                b.MigrationsAssembly("TodoApp.Migrations"));

            return new TodoDbContext(optionsBuilder.Options);
        }
    }
}
