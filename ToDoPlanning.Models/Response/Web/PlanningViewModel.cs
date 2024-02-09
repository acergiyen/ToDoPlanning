namespace ToDoPlanning.Models.Response.Web;

public class PlanningViewModel
{

    public List<Developer> Developers { get; set; }
    public int Weeks { get; set; }

    public class Developer
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
    }

    public class Task
    {
        public string Name  { get; set; }
    }
}
