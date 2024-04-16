using DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class ToDoTaskContext : DbContext
    {
        public ToDoTaskContext(DbContextOptions<ToDoTaskContext> options) : base(options) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>().HasData(
                new ToDoTask
                {
                    Id = 1,
                    Name = "some task",
                    Decription = "some description",
                    Priority = Priority.Medium,
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
