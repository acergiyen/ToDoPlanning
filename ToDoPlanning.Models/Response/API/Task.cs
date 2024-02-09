using Newtonsoft.Json;

namespace ToDoPlanning.Models.Response.API;

public class Task
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("duration")]
    public int Duration { get; set; }
    [JsonProperty("difficulty")]
    public int Difficulty { get; set; }
}