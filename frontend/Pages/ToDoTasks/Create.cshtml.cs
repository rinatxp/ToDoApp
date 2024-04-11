using DTO;
using frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace frontend.Pages.ToDoTasks
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<GetModel> _logger;
        private readonly ToDoTaskService _toDoTaskService;

        [BindProperty]
        public ToDoTask ToDoTask { get; set; }

        public CreateModel(ILogger<GetModel> logger, ToDoTaskService toDoTaskService)
        {
            _logger = logger;
            _toDoTaskService = toDoTaskService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _toDoTaskService.PostToDoTaskAsync(ToDoTask);
                return Redirect("Get");
            }
            return Page();
        }
    }
}
