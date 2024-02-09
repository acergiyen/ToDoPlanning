using Newtonsoft.Json;

namespace ToDoPlanning.Models.Response.API;

public class Model
{
    [JsonProperty("tasks")]
    public List<Task> Tasks { get; set; }
}