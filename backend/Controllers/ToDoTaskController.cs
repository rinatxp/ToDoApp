using backend.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly ILogger<ToDoTaskController> _logger;
        private readonly ToDoTaskContext _ctx;

        public ToDoTaskController(ILogger<ToDoTaskController> logger, ToDoTaskContext toDoTaskContext)
        {
            _logger = logger;
            _ctx = toDoTaskContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _ctx.ToDoTasks.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var task = await _ctx.ToDoTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, ToDoTask updatedTask)
        {
            var task = await _ctx.ToDoTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            _ctx.ToDoTasks.Update(updatedTask);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ToDoTask task)
        {
            await _ctx.ToDoTasks.AddAsync(task);
            await _ctx.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var task = await _ctx.ToDoTasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            _ctx.ToDoTasks.Remove(task);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
