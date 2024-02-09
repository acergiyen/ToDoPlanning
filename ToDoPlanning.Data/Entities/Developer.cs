namespace ToDoPlanning.Data.Entities;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    
    public ICollection<TaskItem> Tasks { get; set; }
}