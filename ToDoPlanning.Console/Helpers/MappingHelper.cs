using ToDoPlanning.Data.Entities;
using Task = ToDoPlanning.Models.Response.API.Task;

namespace ToDoPlanning.Console.Helpers;

public class MappingHelper
{
    public List<TaskItem> MapTaskToTaskItem(List<Task> tasks)
    {
        List<TaskItem> taskItems = new List<TaskItem>();
        foreach (var task in tasks)
        {
            TaskItem taskItem = new TaskItem
            {
                Name = task.Name,
                Duration = task.Duration,
                Difficulty = task.Difficulty

            };
            taskItems.Add(taskItem);
        }

        return taskItems;
    }
}
