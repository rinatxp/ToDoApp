using DTO;
using frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace frontend.Pages.ToDoTasks
{
    public class GetModel : PageModel
    {
        private readonly ILogger<GetModel> _logger;
        private readonly ToDoTaskService _toDoTaskService;

        public List<ToDoTask> ToDoTasks { get; set; }

        public GetModel(ILogger<GetModel> logger, ToDoTaskService toDoTaskService)
        {
            _logger = logger;
            _toDoTaskService = toDoTaskService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ToDoTasks = await _toDoTaskService.GetToDoTaskListAsync() ?? new List<ToDoTask>();
            return Page();
        }
    }
}
