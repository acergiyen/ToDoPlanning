namespace ToDoPlanning.Data.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Duration { get; set; }
    public int Difficulty { get; set; }
    
    public int? DeveloperId { get; set; }
    
    public Developer Developer { get; set; }
}