using DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class ToDoTaskContext : DbContext
    {
        public ToDoTaskContext(DbContextOptions<ToDoTaskContext> options) : base(options) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
