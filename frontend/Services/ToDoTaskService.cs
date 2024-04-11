using DTO;
using System.Net.Http;
using System.Text.Json;

namespace frontend.Services
{
    public class ToDoTaskService
    {
        private HttpClient _httpClient;
        private readonly ILogger<ToDoTaskService> _logger;

        public ToDoTaskService(HttpClient httpClient, ILogger<ToDoTaskService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<List<ToDoTask>> GetToDoTaskListAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/todotask");
                string content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Bad status code {response.StatusCode} in {nameof(GetToDoTaskListAsync)}");
                    return null!;
                }
                
                var taskList = await response.Content.ReadFromJsonAsync(ToDoTaskSerializerContext.Default.ListToDoTask);
                return taskList!;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during GET todo-task list");
            }

            return null!;
        }

        public async Task<ToDoTask> GetToDoTaskAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/todotask/{id}");
                string content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Bad status code {response.StatusCode} in {nameof(GetToDoTaskAsync)}, id {id}");
                    return null!;
                }
                
                var task = await response.Content.ReadFromJsonAsync(ToDoTaskSerializerContext.Default.ToDoTask);
                return task!;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error during GET todo-task with id {id}");
            }

            return null!;
        }

        public async Task PostToDoTaskAsync(ToDoTask task)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/todotask", task);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Bad status code {response.StatusCode} in {nameof(PostToDoTaskAsync)}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error during POST todo-task");
            }
        }
    }
}
