using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTO
{
    public class ToDoTask
    {
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [MaxLength(100)]
        [JsonPropertyName("description")]
        public string? Decription {  get; set; }
        [Required]
        [JsonPropertyName("priority")]
        public required Priority Priority { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    [JsonSerializable(typeof(List<ToDoTask>))]
    public sealed partial class ToDoTaskSerializerContext : JsonSerializerContext
    {
    }
}
